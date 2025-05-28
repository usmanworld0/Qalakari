using System.ComponentModel.DataAnnotations;

namespace Qalakar.Data
{
    public class Opportunity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; } = "";
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; } = "";
        [Required(ErrorMessage = "Budget is required")]
        [Range(0.01, 100000, ErrorMessage = "Budget must be greater than 0")]
        public decimal Budget { get; set; }
        [Required(ErrorMessage = "Event type is required")]
        [StringLength(50, ErrorMessage = "Event type cannot be longer than 50 characters")]
        public string EventType { get; set; } = "";
        [Required(ErrorMessage = "Location is required")]
        [StringLength(50, ErrorMessage = "Location cannot be longer than 50 characters")]
        public string Location { get; set; } = "";
        [Required(ErrorMessage = "Contact email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Contact email cannot be longer than 100 characters")]
        public string ContactEmail { get; set; } = "";
        public int UserId { get; set; }
        public string EventDates { get; set; } = "";
        [StringLength(100, ErrorMessage = "User name cannot be longer than 100 characters")]
        public string UserName { get; set; } = "";
    }
}