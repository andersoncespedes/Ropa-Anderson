using System.Linq.Expressions;
using Dominio.Entities;

namespace Dominio.Interfaces;

public interface IGenericRepo<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<(int totalRegistros, IEnumerable<T> registros)> paginacion(int pageIndex, int pageSize, string _search);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
}