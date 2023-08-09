using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class Estate
    {
        [Key]
        public int EstateId { get; set; }
        [Required]
        public int EstateTypeId { get; set; }
        public EstateType EstateType { get; set; }



        public ICollection<EstateImage>? Images { get; set; } = new List<EstateImage>();

        [Required]
        public string Address { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public bool IsSold { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
