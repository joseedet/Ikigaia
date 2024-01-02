using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Persistencia
{
    public class IkigaiContext:IdentityDbContext<Usuario>
    {
       public IkigaiContext(DbContextOptions <IkigaiContext> options):base(options)
            {

            }
        



            public DbSet<Planin> Agendas {get;set;}
            public DbSet<Cliente> Clientes {get;set;}
            public DbSet<DetalleCliente> DetalleClientes {get;set;}
            public DbSet<Tipo> Tipos {get;set;}

    }
}
            

