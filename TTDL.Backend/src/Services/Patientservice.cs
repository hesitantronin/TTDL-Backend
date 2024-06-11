using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTDL_Backend.Models;

namespace TTDL_Backend.Services
{
    public class PatientService : IPatientService
    {
        private readonly T_DbContext _context;

        public PatientService(T_DbContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatient(string id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<string> CreatePatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient.PatientId;
        }

        public async Task<bool> UpdatePatient(string id, Patient patient)
        {
            if (id != patient.PatientId)
            {
                return false;
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeletePatient(string id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return false;
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool PatientExists(string id)
        {
            return _context.Patients.Any(e => e.PatientId == id);
        }
    }
}
