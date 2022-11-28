using System;
using System.ComponentModel.DataAnnotations; // Needed for the [Key] attribute 

namespace TourismAPI.Models
{
    public class AttractionDesc
    {
        [Key] // To declare a field with a custom name as primary key
        public int AttractionId { get; set; }
        public string? Description { get; set; }
        public string? DateOpened { get; set; }
        public string? Phone { get; set; }
        public string? VisitorsAnnually { get; set; }
    }
}
