﻿using System.ComponentModel.DataAnnotations;

namespace Parky_API.Models
{
    public class NationalPark
    {

        [Key]   
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string State { get; set; }
        public DateTime Created { get; set; }
       
        public byte[]? Picture { get; set; }
        public DateTime Established { get; set; }

    }
}
