using System.Collections.Generic;
using System.Threading.Tasks;
using TTDL_Backend.Models;

namespace TTDL_Backend.Repositories
{
    public interface IChairRepository
    {
        Task<List<Chair>> GetChairs();
        Task<Chair> GetChair(string id);
        Task<string> CreateChair(Chair chair);
        Task<bool> UpdateChair(string id, Chair chair);
        Task<bool> DeleteChair(string id);
        Task<bool> ChairExists(string id);
    }
}
