using System;
using System.ComponentModel.DataAnnotations; // Needed for the [Key] attribute

namespace TourismAPI.Models
{
    public class TouristAttract
    {
        [Key] // To declare a field with a custom name as primary key
        public int PlaceId { get; set; }
        public string Place { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? ZipCode { get; set; }
        public int AttractionId { get; set; }
    }
}
