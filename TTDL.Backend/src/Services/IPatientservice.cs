using System.Collections.Generic;
using System.Threading.Tasks;
using TTDL_Backend.Models;

namespace TTDL_Backend.Services
{
    public interface IPatientService
    {
        Task<List<Patient>> GetPatients();
        Task<Patient> GetPatient(string id);
        Task<string> CreatePatient(Patient patient);
        Task<bool> UpdatePatient(string id, Patient patient);
        Task<bool> DeletePatient(string id);
    }
}
