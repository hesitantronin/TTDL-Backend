using Microsoft.EntityFrameworkCore;
using TTDL_Backend.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class T_DbContext : DbContext
{
    public T_DbContext(DbContextOptions<T_DbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }


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
            .HasOne(c => c.Patient)
            .WithOne(p => p.CurrentChair)
            .HasForeignKey<Chair>(c => c.PatientId);

        modelBuilder.Entity<Measurement>()
            .HasOne(m => m.Chair)
            .WithMany(c => c.Measurements)
            .HasForeignKey(m => m.ChairId);

        modelBuilder.Entity<Measurement>()
            .HasOne(m => m.CurrentPatient)
            .WithMany()
            .HasForeignKey(m => m.CurrentPatientId);
    }


    public void SeedData()
    {
        if (!Users.Any())
        {
            Users.Add(new User { Uname = "Arie", Password = "Kanarie" });
            SaveChanges();
            System.Console.WriteLine("Data should be checked in now....");
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