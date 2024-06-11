using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTDL_Backend.Models;

namespace TTDL_Backend.Services
{
    public class ChairService : IChairService
    {
        private readonly T_DbContext _context;

        public ChairService(T_DbContext context)
        {
            _context = context;
        }

        public async Task<List<Chair>> GetChairs()
        {
            return await _context.Chairs.ToListAsync();
        }

        public async Task<Chair> GetChair(string id)
        {
            return await _context.Chairs.FindAsync(id);
        }

        public async Task<string> CreateChair(Chair chair)
        {
            _context.Chairs.Add(chair);
            await _context.SaveChangesAsync();
            return chair.ChairId;
        }

        public async Task<bool> UpdateChair(string id, Chair chair)
        {
            if (id != chair.ChairId)
            {
                return false;
            }

            _context.Entry(chair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChairExists(id))
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

        public async Task<bool> DeleteChair(string id)
        {
            var chair = await _context.Chairs.FindAsync(id);
            if (chair == null)
            {
                return false;
            }

            _context.Chairs.Remove(chair);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool ChairExists(string id)
        {
            return _context.Chairs.Any(e => e.ChairId == id);
        }
    }
}
