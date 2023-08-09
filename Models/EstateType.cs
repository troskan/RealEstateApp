using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class EstateType
    {
        [Key]
        public int EstateTypeId { get; set; }
        [Required]
        public string TypeName { get; set; }
    }
}
