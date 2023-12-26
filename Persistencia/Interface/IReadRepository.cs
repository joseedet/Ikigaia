using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.Interface
{
    public interface IReadRepository<TEntity> : IReadRepositoryBase<TEntity> where TEntity : class { }
    
}