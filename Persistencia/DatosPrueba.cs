using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Identity;


namespace Persistencia
{
    public class DatosPrueba
    {
        public static async Task InsertarData(IkigaiContext context, UserManager <Usuario> usuarioManager)
        {
            if(!usuarioManager.Users.Any()){
                var usuario=new Usuario{NombreCompleto="José Edet", UserName="joseedet",Email="joseedet@gmail.com"};
                await usuarioManager.CreateAsync(usuario,"Password123.");
            }
        }
        
    }
}