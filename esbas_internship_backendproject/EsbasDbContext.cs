using esbas_internship_backendproject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection.Emit;


namespace esbas_internship_backendproject
{
    public class EsbasDbContext : DbContext
    {
#nullable disable
        public DbSet <Users> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Events_Users> Events_Users { get; set; }
        public DbSet<Event_Type> Event_Type { get; set; }
        public DbSet<Event_Location> Event_Location { get; set; }
        public DbSet<User_Department> User_Department { get; set; }
        public DbSet<User_IsOfficeEmployee> User_IsOfficeEmployee { get; set; }
        public DbSet<User_Gender> User_Gender { get; set; }


        public EsbasDbContext(DbContextOptions<EsbasDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder Modelbuilder)
        {
            Modelbuilder.Entity<Users>().HasKey(u => u.UserID);
           // Modelbuilder.Entity<Users>().HasIndex(u => u.CardID).IsUnique(); 
            Modelbuilder.Entity<Users>().ToTable("Users");

            Modelbuilder.Entity<Events>().HasKey(e => e.EventID);
            Modelbuilder.Entity<Events>().ToTable("Events");

            Modelbuilder.Entity<Events_Users>().HasKey(eu => eu.ID);
            Modelbuilder.Entity<Events_Users>().ToTable("Events_Users");

            Modelbuilder.Entity<Event_Type>().HasKey(et => et.T_ID);
            Modelbuilder.Entity<Event_Type>().ToTable("Event_Type");

            Modelbuilder.Entity<Event_Location>().HasKey(el => el.L_ID);
            Modelbuilder.Entity<Event_Location>().ToTable("Event_Location");
            
            Modelbuilder.Entity<User_Department>().HasKey(ud => ud.D_ID);
            Modelbuilder.Entity<User_Department>().ToTable("User_Department");

            Modelbuilder.Entity<User_IsOfficeEmployee>().HasKey(uı => uı.I_ID);
            Modelbuilder.Entity<User_IsOfficeEmployee>().ToTable("User_IsOfficeEmployee");

            Modelbuilder.Entity<User_Gender>().HasKey(ug => ug.G_ID);
            Modelbuilder.Entity<User_Gender>().ToTable("User_Gender");

            Modelbuilder.Entity<Events_Users>()
                 .HasOne(eu => eu.Event)
                 .WithMany()
                 .HasForeignKey(eu => eu.EventID);


            Modelbuilder.Entity<Events_Users>()
                .HasOne(eu => eu.User)
                .WithMany()
                .HasForeignKey(eu => eu.CardID)
                .HasPrincipalKey(u => u.CardID);



            /*Modelbuilder.Entity<EventDTO>()
                .HasOne()
                .WithMany()
                .HasForeignKey(e => e.)

             Modelbuilder.Entity<Events>()
                  .HasOne(e => e.Event_Type)
                  .WithMany()
                  .HasForeignKey(e => e.Event_TypeID);

              Modelbuilder.Entity<Events>()
                  .HasOne(e => e.Event_Location)
                  .WithMany()
                  .HasForeignKey(el => el.Event_LocationID);


              Modelbuilder.Entity<Users>()
                  .HasOne(u => u.User_Gender)
                  .WithMany()
                  .HasForeignKey(u => u.User_GenderID);

              Modelbuilder.Entity<Users>()
                  .HasOne(u => u.User_Department)
                  .WithMany()
                  .HasForeignKey(u => u.User_DepartmentID);

              Modelbuilder.Entity<Users>()
                  .HasOne(u => u.User_IsOfficeEmployee)
                  .WithMany()
                  .HasForeignKey(u => u.User_IsOfficeEmployeeID); */

            base.OnModelCreating(Modelbuilder);
        }
    }
}
