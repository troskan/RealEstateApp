using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class EstateType
    {
        [Key]
        public int EstateTypeId { get; set; }   
        public string TypeName { get; set; }
    }
}
