using Invoice_Generator.Domain.Entities;

namespace Invoice_Generator.Domain.Interfaces;

public interface IRepository
{
    public T Add<T>(T entity) where T : BaseEntity;
    public void Delete<T>(T entity) where T: BaseEntity;
    public List<T> GetAll<T>() where T : BaseEntity;
    public T? GetByID<T>(Guid id) where T : BaseEntity;
    public T Update<T>(T entity) where T: BaseEntity;
}