using System.Threading.Tasks;
using System.Collections.Generic;

namespace Petaverse.Interfaces.PetaverseAPI
{
    public interface IAPIBaseService<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> CreateAsync(T dto);
        Task<T?> UpdateAsync(T dto);
        Task<T?> DeleteAsync(T dto);
    }
}
