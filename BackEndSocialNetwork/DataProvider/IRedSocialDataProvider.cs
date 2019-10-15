using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndSocialNetwork.Models;

namespace BackEndSocialNetwork.DataProvider
{
    public interface IRedSocialDataProvider
    {
        List<Usuario> ListarUsuarios(Usuario usuario);
        List<Resultados> InsertarNuevoUsuario(Usuario usuario);
    }
}
