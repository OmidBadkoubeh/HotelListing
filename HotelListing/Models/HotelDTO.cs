using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class CreateHotelDTO
    {
        [Required]
        [StringLength(150, ErrorMessage = "Hotel name is too long!")]
        public string Name { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Hotel address is too long!")]
        public string Address { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rate is invalid! it must a double between 1 to 5")]
        public double Rating { get; set; }

        [Required] public int CountryId { get; set; }
    }

    public class HotelDTO : CreateHotelDTO
    {
        public int Id { get; set; }

        public CountryDTO Country { get; set; }
    }
}