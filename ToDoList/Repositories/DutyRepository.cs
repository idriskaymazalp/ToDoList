using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public class DutyRepository : IDutyRepository
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<Duty> _dbSet;

        public DutyRepository(AppDbContext context) 
        {
            _context = context;
            _dbSet = _context.Set<Duty>();

        }

        public async Task AddAsync(Duty entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Duty> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Duty> GetAll()
        {
            return _dbSet.AsNoTracking();
            
        }

        public async Task<IList<Duty>> GetList()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public IList<Duty> GetList(Func<Duty, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public async Task<Duty> GetByIdAsync(int id)
        {
            var gorev = await _dbSet.FindAsync(id);
            if (gorev == null)
            {
                throw new Exception($"{typeof(Duty).Name}({id}) not found");
            }
            return gorev;
        }

        public void RemoveRange(IEnumerable<Duty> entities)
        {
            _dbSet.RemoveRange(entities);
            _context.SaveChanges();

        }

        public void Update(Duty entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();

        }

        public async Task<bool> AnyAsync(Expression<Func<Duty, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public async Task Remove(Duty entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
