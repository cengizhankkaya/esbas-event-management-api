namespace esbas_internship_backendproject.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class EventTypeDTO
    {
#nullable disable

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int T_ID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; } = true;

    }
}
