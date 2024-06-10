using System.Security.Cryptography.X509Certificates;
using TTDL_Backend.Models;

namespace TTDL_Backend.Services
{
    public interface IMeasurementservice
    {
        public bool RegisterMeasurementToDatabase(Measurement measurementToRegister);

        public Measurement GetMeasurement(string searchKey);
        
        public bool DeleteMeasurement(string searchKey);
    }
}