using System.ComponentModel.DataAnnotations;

namespace Qalakar.Data
{
    public class Gig
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; } = "";
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; } = "";
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Service type is required")]
        [StringLength(50, ErrorMessage = "Service type cannot be longer than 50 characters")]
        public string ServiceType { get; set; } = "";
        [Required(ErrorMessage = "City is required")]
        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters")]
        public string City { get; set; } = "";
        [Required(ErrorMessage = "Image URL is required")]
        [Url(ErrorMessage = "Invalid URL format")]
        [StringLength(500, ErrorMessage = "Image URL cannot be longer than 500 characters")]
        public string ImageUrl { get; set; } = "";
        public int UserId { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(20, ErrorMessage = "Phone number cannot be longer than 20 characters")]
        public string PhoneNumber { get; set; } = "";
        public string Availability { get; set; } = "";
        [StringLength(100, ErrorMessage = "User name cannot be longer than 100 characters")]
        public string UserName { get; set; } = "";
    }
}