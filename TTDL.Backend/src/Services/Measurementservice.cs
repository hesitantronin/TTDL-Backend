using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTDL_Backend.Models;

namespace TTDL_Backend.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly T_DbContext _context;

        public MeasurementService(T_DbContext context)
        {
            _context = context;
        }

        public async Task<List<Measurement>> GetMeasurements()
        {
            return await _context.Measurements.ToListAsync();
        }

        public async Task<Measurement> GetMeasurement(int id)
        {
            return await _context.Measurements.FindAsync(id);
        }

        public async Task<int> CreateMeasurement(Measurement measurement)
        {
            _context.Measurements.Add(measurement);
            await _context.SaveChangesAsync();
            return measurement.MeasurementId;
        }

        public async Task<bool> UpdateMeasurement(int id, Measurement measurement)
        {
            if (id != measurement.MeasurementId)
            {
                return false;
            }

            _context.Entry(measurement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementExists(id))
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

        public async Task<bool> DeleteMeasurement(int id)
        {
            var measurement = await _context.Measurements.FindAsync(id);
            if (measurement == null)
            {
                return false;
            }

            _context.Measurements.Remove(measurement);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool MeasurementExists(int id)
        {
            return _context.Measurements.Any(e => e.MeasurementId == id);
        }
    }
}
