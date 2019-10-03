using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using BackEndSocialNetwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BackEndSocialNetwork.DataProvider
{
    public class RedSocialDataProvider:IRedSocialDataProvider
    {
        public IConfiguration Configuration { get; }

        public RedSocialDataProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private SqlConnection sqlConnection;

        public List<Usuario> ListarUsuarios(Usuario usuario)
        {
            string CadenaConexion = Configuration["ConnectionStrings:AzureSQL"];
            var 
                sqlConnection = new SqlConnection(CadenaConexion);

            sqlConnection.Open();

            List<Usuario> Usuarios = sqlConnection.Query<Usuario>("SELECT [Usuario Login] Login FROM USUARIO").ToList();

            return Usuarios;

        }
    }
}
