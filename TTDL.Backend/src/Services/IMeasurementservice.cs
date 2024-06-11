using System.Collections.Generic;
using System.Threading.Tasks;
using TTDL_Backend.Models;

namespace TTDL_Backend.Services
{
    public interface IMeasurementService
    {
        Task<List<Measurement>> GetMeasurements();
        Task<Measurement> GetMeasurement(int id);
        Task<int> CreateMeasurement(Measurement measurement);
        Task<bool> UpdateMeasurement(int id, Measurement measurement);
        Task<bool> DeleteMeasurement(int id);
    }
}
