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

        public EventModel( ScheduledEvent item)
        {
            if (item != null)
            {
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
                StartDate = item.StartDate;
                EndDate = item.EndDate;
                IsPublic = item.IsPublic;
            };
        }

        public ScheduledEvent ToDomain()
        {
            return new ScheduledEvent()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                StartDate = StartDate,
                EndDate = EndDate,
                IsPublic = IsPublic,
            };
        }

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
        public DateTime StartDate { get; set; }
      
        [Display(Name = "End Date")]
        public DateTime EndDate
        {
            get => _endDate;
            set { _endDate = (value >= StartDate) ? value : StartDate; } //If the End Date they provided was invalid just set it as StartDate
        }
        private DateTime _endDate;

        [Display(Name = "Public?")]
        public bool IsPublic { get; set; }
    }
}