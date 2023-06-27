using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Universities
{
    public class GetUniversityDto
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
