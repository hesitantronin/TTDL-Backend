using Microsoft.EntityFrameworkCore;
using TTDL_Backend.Models;

public class T_DbContext : DbContext
{
    public T_DbContext(DbContextOptions<T_DbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Patient> Patients { get; set; }

    public void SeedData()
    {
        if (!Users.Any())
        {
            Users.Add(new User{ Uname = "Arie", Password = "Kanarie"});
            SaveChanges();
            System.Console.WriteLine("Data should be checked in now....");
        }
    }
}