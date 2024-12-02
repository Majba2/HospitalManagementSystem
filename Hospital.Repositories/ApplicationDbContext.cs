using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hospital.Model;

namespace Hospital.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Appointment Relationships
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(a => a.ID);

                // Doctor relationship (Cascade Delete)
                entity.HasOne(a => a.Doctor)
                      .WithMany()
                      .HasForeignKey(a => a.DoctorId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Patient relationship (Restrict Delete)
                entity.HasOne(a => a.Patient)
                      .WithMany()
                      .HasForeignKey(a => a.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            // PatientReport Relationships
            modelBuilder.Entity<PatientReport>(entity =>
            {
                entity.HasOne(pr => pr.Doctor)
                      .WithMany()
                      .HasForeignKey(pr => pr.ID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pr => pr.Patient)
                      .WithMany()
                      .HasForeignKey(pr => pr.ID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Other Foreign Key Relationships (as per your models)

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasOne(b => b.Patient)
                      .WithMany()
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.Insurance)
                      .WithMany(i => i.Bill)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Lab>(entity =>
            {
                entity.HasOne(l => l.Patient)
                      .WithMany()
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<MedicineReport>(entity =>
            {
                entity.HasOne(mr => mr.Supplier)
                      .WithMany(s => s.MedicineReport)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(mr => mr.Medicine)
                      .WithMany(m => m.MedicineReport)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PrescribedMedicine>(entity =>
            {
                entity.HasOne(pm => pm.Medicine)
                      .WithMany(m => m.PrescribedMedicine)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(pm => pm.PatientReport)
                      .WithMany(pr => pr.PrescribedMedicine)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        // DbSet declarations
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<HospitalInfo> HospitalInfos { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineReport> MedicineReports { get; set; }
        public DbSet<PatientReport> PatientReports { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TestPrice> TestPrices { get; set; }
    }
}
