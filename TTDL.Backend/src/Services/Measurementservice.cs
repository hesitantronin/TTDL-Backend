using Microsoft.EntityFrameworkCore;
using TTDL_Backend.Models;

namespace TTDL_Backend.Services
{
    public class MeasurementService : IMeasurementservice
    {

        private T_DbContext _DbContext;

        public MeasurementService(T_DbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public bool DeleteMeasurement(string searchKey)
        {
            if (searchKey == null) return false;

            searchKey = searchKey.ToLower();

            throw new NotImplementedException();
        }

        public Measurement GetMeasurement(string searchKey)
        {
            throw new NotImplementedException();
        }

        public bool RegisterMeasurementToDatabase(Measurement measurementToRegister)
        {
            throw new NotImplementedException();
        }
    }
}