using SpeakHub.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpeakHub.DataAccess.Interfaces.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<T?> FindByIdAsync(int id);

        public Task<T?> FirstOrDefault(Expression<Func<T, bool>> expression);

        public T Add(T entity);

        public void Update(int id, T entity);

        public void Delete(int id);
        public void TrackingDeteched(T entity);
    }
}