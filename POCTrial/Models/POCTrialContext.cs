using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace POCTrial.Models
{
    public partial class POCTrialContext : DbContext
    {
        public POCTrialContext()
        {
        }

        public POCTrialContext(DbContextOptions<POCTrialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeInformation> EmployeeInformations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-2JCLJMC1;Database=POCTrial;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EmployeeInformation>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__Employee__78113481F7F0373E");

                entity.ToTable("Employee_Information");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Employee_ID");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(256)
                    .HasColumnName("Middle_Name")
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.ProjectId)
                    .HasMaxLength(256)
                    .HasColumnName("Project_ID")
                    .HasDefaultValueSql("('NA')");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.Supervisor)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.WorkEmail)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("Work_Email");

                entity.Property(e => e.WorkLocation)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("Work_Location");

                entity.Property(e => e.WorkPhone)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("Work_Phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
