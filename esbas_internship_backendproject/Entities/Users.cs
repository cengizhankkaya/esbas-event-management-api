namespace esbas_internship_backendproject.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Users
    {
#nullable disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public int CardID { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string IsOfficeEmployee { get; set; } 
        public string Gender { get; set; }
        public bool Status { get; set; } = true;



        //public User_Department User_Department { get; set; }
        //public User_Gender User_Gender { get; set; }
        //public User_IsOfficeEmployee User_IsOfficeEmployee { get; set; }

        public Users() { }
    }
}
