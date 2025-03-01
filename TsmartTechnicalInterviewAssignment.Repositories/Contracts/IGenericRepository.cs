using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsmartTechnicalInterviewAssignment.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<List<T>> GetAllAsync();
        ValueTask<T> GetByIdAsync(int id);


    }
}
