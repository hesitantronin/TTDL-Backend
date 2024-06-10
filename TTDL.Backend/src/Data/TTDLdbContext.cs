using Microsoft.EntityFrameworkCore;
using TTDL_Backend.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using CsvHelper;
using System.Globalization;

public class T_DbContext : DbContext
{
    public T_DbContext(DbContextOptions<T_DbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    public DbSet<Chair> Chairs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var intListComparer = new ValueComparer<List<int>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());

        modelBuilder.Entity<Chair>()
            .HasKey(c => c.ChairId);

        modelBuilder.Entity<Measurement>()
            .HasKey(m => m.MeasurementId);

        modelBuilder.Entity<Measurement>()
            .Property(m => m.Data)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList())
            .Metadata.SetValueComparer(intListComparer);

        modelBuilder.Entity<Patient>()
            .HasKey(p => p.PatientId);

        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);

        modelBuilder.Entity<Chair>()
            .HasOne(c => c.CurrentPatient)
            .WithOne(p => p.CurrentChair)
            .HasForeignKey<Patient>(p => p.CurrentChairId);

        modelBuilder.Entity<Measurement>()
            .HasOne(m => m.Chair)
            .WithMany(c => c.Measurements)
            .HasForeignKey(m => m.ChairId);

        modelBuilder.Entity<Measurement>()
            .HasOne(m => m.CurrentPatient)
            .WithMany()
            .HasForeignKey(m => m.CurrentPatientId);
    }

    public void SeedData(string chairsPath, string patientsPath)
    {
        SeedChairs(chairsPath);
        SeedPatients(patientsPath);
    }

    public void SeedChairs(string chairsDataPath)
    {
        if (!Patients.Any())
        {
            using (var reader = new StreamReader(chairsDataPath))
            using (var csvContents = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var chairs = csvContents.GetRecords<Chair>().ToList();
                Chairs.AddRange(chairs);
                SaveChanges();
            }
        }
    }

    public void SeedPatients(string patientsDataPath)
    {
        if (!Patients.Any())
        {
            using (var reader = new StreamReader(patientsDataPath))
            using (var csvContents = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var patients = csvContents.GetRecords<Patient>().ToList();
                Patients.AddRange(patients);
                SaveChanges();
            }
        }
    }

    public void ClearDb()
    {
        foreach (var entity in this.Model.GetEntityTypes())
        {
            this.Database.ExecuteSqlRaw($"DELETE FROM {entity.GetTableName()}");
        }
    }
}
