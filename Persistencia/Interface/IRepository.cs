using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia.Interface
{
    public interface IRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class { }
    
        
    
}