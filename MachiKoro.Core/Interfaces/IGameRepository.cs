using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachiKoro.Core.Interfaces
{
    public interface IGameRepository
    {
        Task SaveAsync(Game game);
        Task DeleteAsync(Guid gameId);
        Task<Game> GetAsync(Guid gameId);
        Task<List<Game>> GetAllAsync();
    }
}
