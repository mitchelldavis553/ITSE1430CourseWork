using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib.Sql
{
    public class SqlMovieDatabase : MovieDatabase
    {
        public SqlMovieDatabase (string connectionString) // Constructor to initialize connectionString
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (connectionString == "")
                throw new ArgumentException("Connection string cannot be empty.", nameof(connectionString));

            _connectionString = connectionString;
        }
        private readonly string _connectionString;

        protected override void AddCore( Movie movie )
        {
            using ( var conn = CreateConnection())
            {
                var cmd = new SqlCommand("AddMovie", conn); // Overload: (String command, Connection)
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@title", movie.Name);
                cmd.Parameters.AddWithValue("@length", movie.RunLength);
                cmd.Parameters.AddWithValue("@isOwned", movie.IsOwned);
                cmd.Parameters.AddWithValue("@description", movie.Description);

                conn.Open();
                var result = cmd.ExecuteScalar();
                var id = Convert.ToInt32(result); //converts an object to a type you know it is
            };
        }

        private SqlConnection CreateConnection() => new SqlConnection(_connectionString);

        protected override void EditCore( Movie oldMovie, Movie newMovie )
        {
            using (var conn = CreateConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UpdateMovie";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var id = GetMovieId(oldMovie); 
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@title", newMovie.Name);
                cmd.Parameters.AddWithValue("@length", newMovie.RunLength);
                cmd.Parameters.AddWithValue("@isOwned", newMovie.IsOwned);
                cmd.Parameters.AddWithValue("@description", newMovie.Description);

                conn.Open();
                cmd.ExecuteNonQuery();
            };
        }

        private object GetMovieId( Movie movie )
        {
            var sql = movie as SqlMovie;

            return sql?.Id ?? 0;
        }

        protected override Movie FindByName( string name )
        {
            //use a data reader
            using (var conn = CreateConnection())
            {
                var cmd = new SqlCommand("GetAllMovies", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (var reader = cmd.ExecuteReader()) // data readers use idisposable u have to wrap them in a using block
                {
                    while (reader.Read())
                    {
                        var movieName = reader.GetString(1);
                        if (String.Compare(movieName, name, true) != 0)
                            continue;

                        //reader.GetOrdinal("Id");

                        return new SqlMovie()
                        {
                            Id = reader.GetFieldValue<int>(0),
                            Name = movieName,
                            Description = Convert.ToString(reader.GetValue(2)),
                            ReleaseYear = 1900,
                            RunLength = reader.GetFieldValue<int>(3),
                            IsOwned = reader.GetBoolean(4),
                        };
                    };
                };
            };

            return null;
        }

        protected override IEnumerable<Movie> GetAllCore()
        {
            var ds = new DataSet();

            using (var conn = CreateConnection())
            {
                var da = new SqlDataAdapter();
                var cmd = new SqlCommand("GetAllMovies", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmd;
                da.Fill(ds);
            };
            //Read data
            //if (!ds.Tables.OfType<DataTable>().Any())
                //return Enumerable.Empty<Movie>();

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table == null)
                return Enumerable.Empty<Movie>();

            var movies = new List<Movie>();

            foreach (var row in table.Rows.OfType<DataRow>())
            {
                var movie = new SqlMovie() {
                    Id = Convert.ToInt32(row["Id"]), // different ways of accessing the rows
                    Name = row.Field<string>("Title"),
                    Description = Convert.ToString(row[2]),
                    ReleaseYear = 1900,
                    RunLength = row.Field<int>(3),
                    IsOwned = Convert.ToBoolean(row[4]),
                };
                movies.Add(movie);
            };

            return movies;
            //return new Movie[0];
            //throw new NotImplementedException();
        }

        protected override void RemoveCore( string name )
        {
            var movie = FindByName(name);
            if (movie == null)
                return;

            using (var conn = CreateConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "RemoveMovie";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var id = GetMovieId(movie);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            };
        }
    }
}
