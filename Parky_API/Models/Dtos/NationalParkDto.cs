using System.ComponentModel.DataAnnotations;

namespace Parky_API.Models.Dtos
{
    public class NationalParkDto

    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string State { get; set; }
        public DateTime Created { get; set; }
        public byte[] Picture { get; set; }
        public DateTime Established { get; set; }

    }
}
