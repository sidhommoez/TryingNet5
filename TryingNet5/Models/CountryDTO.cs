﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TryingNet5.data;

namespace TryingNet5.Models
{
    public class CountryDTO : CreateCountryDTO
    {
        public int Id { get; set; }

        public IList<HotelDTO> Hotels { get; set; }
    }

    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country Name is Too Long")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "Country ShortName is Too Long")]
        public string ShortName { get; set; }
    }
}
