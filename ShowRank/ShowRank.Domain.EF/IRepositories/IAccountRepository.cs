using ShowRank.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShowRank.Domain.EF.IRepositories
{
    public interface IAccountRepository<T> where T : BaseAppUser
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
