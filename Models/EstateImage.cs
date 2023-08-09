using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class EstateImage
    {
        [Key]
        public int EstateImageId { get; set; }
        [Required]
        public int EstateId { get; set; }
        public Estate Estate { get; set; }
        public string Url { get; set; }
    }
}
