using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventPlanner.Mvc.Models
{
    public class EventModel
    {
        public EventModel()
        { }

        [Range(0, Int32.MaxValue)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        public string Name
        {
            get => _name ?? "";
            set => _name = value;
        }
        private string _name;

        public string Description
        {
            get => _description ?? "";
            set => _description = value;
        }
        private string _description;

        [Display(Name = "Start Date")]
        []
        public DateTime StartDate { get; set; }
      
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public bool IsPublic { get; set; }
    }
}