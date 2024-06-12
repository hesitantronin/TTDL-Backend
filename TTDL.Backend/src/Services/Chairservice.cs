using System.Collections.Generic;
using System.Threading.Tasks;
using TTDL_Backend.Models;
using TTDL_Backend.Repositories;

namespace TTDL_Backend.Services
{
    public class ChairService : IChairService
    {
        private readonly IChairRepository _chairRepository;

        public ChairService(IChairRepository chairRepository)
        {
            _chairRepository = chairRepository;
        }

        public async Task<List<Chair>> GetChairs()
        {
            return await _chairRepository.GetChairs();
        }

        public async Task<Chair> GetChair(string id)
        {
            return await _chairRepository.GetChair(id);
        }

        public async Task<string> CreateChair(Chair chair)
        {
            return await _chairRepository.CreateChair(chair);
        }

        public async Task<bool> UpdateChair(string id, Chair chair)
        {
            return await _chairRepository.UpdateChair(id, chair);
        }

        public async Task<bool> DeleteChair(string id)
        {
            return await _chairRepository.DeleteChair(id);
        }
    }
}
