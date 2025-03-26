using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Parky_API.Models.Trail;

namespace Parky_API.Models.Dtos
{
    public class TrailDto
    {
      
        public int Id { get; set; }



        [Required]
        public string Name { get; set; }

        [Required]
        public string Distance { get; set; }



        public DifficultyType Difficulty { get; set; }

        [Required]

        public int NationalParkId { get; set; }

        public NationalParkDto NationalPark { get; set; }
        [Required]
        public string Elevation { get; set; }
    }
}
