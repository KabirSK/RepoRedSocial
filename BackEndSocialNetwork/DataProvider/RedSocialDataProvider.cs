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
    public class RedSocialDataProvider : IRedSocialDataProvider
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

        public List<Resultados> InsertarNuevoUsuario(Usuario usuario)
        {
            string CadenaConexion = Configuration["ConnectionStrings:AzureSQL"];
            IEnumerable<Resultados> Resultado;
            List<Resultados> Lista;
            using (var sqlConection = new SqlConnection(CadenaConexion))
            {
                sqlConection.Open();
                var dynamicParameters = new DynamicParameters();

                dynamicParameters.Add("@P_LOGIN", usuario.LOGIN);
                dynamicParameters.Add("@P_PRIMERNOMBRE", usuario.P_PRIMERNOMBRE);
                dynamicParameters.Add("@P_SEGUNDONOMBRE", usuario.P_SEGUNDONOMBRE);
                dynamicParameters.Add("@P_PRIMERAPELLIDO", usuario.P_PRIMERAPELLIDO);
                dynamicParameters.Add("@P_SEGUNDOAPELLIDO", usuario.P_SEGUNDOAPELLIDO);
                dynamicParameters.Add("@P_FECHANACIMIENTO", usuario.P_FECHANACIMIENTO);
                dynamicParameters.Add("@P_FECHACREACION", usuario.P_FECHACREACION);
                dynamicParameters.Add("@P_SEXO", usuario.P_SEXO);
                dynamicParameters.Add("@P_EMAIL", usuario.P_EMAIL);
                dynamicParameters.Add("@P_ROL", usuario.P_ROL);
                dynamicParameters.Add("@P_VALIDADOFACEBOOK", usuario.P_VALIDADOFACEBOOK);
                dynamicParameters.Add("@P_PASSWORD", usuario.P_PASSWORD);
                dynamicParameters.Add("@RETURN", null, System.Data.DbType.String, System.Data.ParameterDirection.Output, 100);

                Lista = sqlConection.Query<Resultados>(
                    "SP_InsertarUsuarioNuevo",
                    dynamicParameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
                    
                /*sqlConection.Execute(
                    "SP_InsertarUsuarioNuevo",
                    dynamicParameters,
                    commandType: System.Data.CommandType.StoredProcedure
                    );*/
                
                sqlConection.Close();
                return Lista;
            }
        }
    }
}
