using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarPhotoAPI.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public string Name { get; set; } = String.Empty;
        public bool Status { get; set; }
        [ForeignKey("PhotoId")]
        public Photo Photo { get; set; }
    }
}
