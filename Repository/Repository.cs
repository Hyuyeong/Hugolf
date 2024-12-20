using System;
using System.Linq.Expressions;
using Hugolf.Data;
using Hugolf.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Hugolf.Repository;

public class Repository<T> : IRepository<T>
    where T : class
{
    private readonly ApplictionDbContext _db;
    internal DbSet<T> dbSet;

    public Repository(ApplictionDbContext db)
    {
        _db = db;
        this.dbSet = db.Set<T>();
    }

    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public T Get(Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = dbSet;
        query = query.Where(filter);
        return query.FirstOrDefault();
    }

    public IEnumerable<T> GetAll()
    {
        IQueryable<T> query = dbSet;
        return query.ToList();
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        dbSet.RemoveRange(entity);
    }
}
