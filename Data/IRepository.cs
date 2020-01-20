using System.Linq;
using System.Threading.Tasks;

namespace questions4me_apirestful_net.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
         IQueryable<TEntity> GetAll();
         Task Create(TEntity entity);
         Task Update(TEntity entity);
         Task Delete(TEntity entity);
    }
}