using Invoice_Generator.Domain.Entities;
using Invoice_Generator.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Invoice_Generator.Infrastructure.Data;

public class EntityFrameworkRepository(AppDBContext appDBContext) : IRepository
{
    private readonly AppDBContext _appDBContext = appDBContext;

    public T Add<T>(T entity) where T : BaseEntity
    {
        _appDBContext.Set<T>().Add(entity);
        _appDBContext.SaveChanges();
        return entity;
    }

    public void Delete<T>(T entity) where T : BaseEntity
    {
        _appDBContext.Set<T>().Remove(entity);
        _appDBContext.SaveChanges();
    }

    public List<T> GetAll<T>() where T : BaseEntity => _appDBContext.Set<T>().ToList();

    public T? GetByID<T>(Guid id) where T : BaseEntity => _appDBContext.Set<T>().SingleOrDefault(entity => entity.Id == id);

    public T Update<T>(T entity) where T : BaseEntity
    {
        _appDBContext.Entry(entity).State = EntityState.Modified;
        _appDBContext.SaveChanges();
        return entity;
    }
}
