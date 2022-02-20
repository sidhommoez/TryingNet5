using System.ComponentModel.DataAnnotations;
using TryingNet5.data;

namespace TryingNet5.Models
{
    public class HotelDTO : CreateHotelDTO
    {
        public int Id { get; set; }
        public Country Country { get; set; }
    }

    public class CreateHotelDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(1,5)]
        public double Rating { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
