using System.ComponentModel.DataAnnotations;

namespace esbas_internship_backendproject.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserGenderDTO
    {
#nullable disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int G_ID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; } = true;
    }
}
