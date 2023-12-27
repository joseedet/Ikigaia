using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Interface
{
    public interface IAplicationContext:IUnitOfWork
    {
            public DbSet<Planin> Agendas { get;  }
            public DbSet<Cliente>Clientes { get; }
            public DbSet<DetalleCliente>DetalleClientes{get;}
            public DbSet<Tipo>Tipos{get;}
    }
}