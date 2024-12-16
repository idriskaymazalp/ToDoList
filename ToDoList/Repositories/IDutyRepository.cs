using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public interface IDutyRepository
    {
        Task AddAsync(Duty entity);
        Task AddRangeAsync(IEnumerable<Duty> entities);
        IQueryable<Duty> GetAll();
        Task<IList<Duty>> GetList();
        IList<Duty> GetList(Func<Duty, bool> predicate);
        Task<Duty> GetByIdAsync(int id);
        Task<int> Save();
        Task Remove(Duty entity);
        void RemoveRange(IEnumerable<Duty> entities);
        void Update(Duty entity);
        Task<bool> AnyAsync(Expression<Func<Duty, bool>> expression);
    }
}
