using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using BackEndSocialNetwork.Models;
using Microsoft.Extensions.Configuration;
using BackEndSocialNetwork.DataProvider;

namespace BackEndSocialNetwork.Controllers
{
    [Route("api/[controller]")]
    public class RedSocialController : Controller
    {
        private IRedSocialDataProvider redSocialDataProvider;

        public RedSocialController(IRedSocialDataProvider redSocialDataProvider)
        {
            this.redSocialDataProvider = redSocialDataProvider;
        }

        [HttpPost]
        [Route("[action]")]
        public List<Usuario> ListarUsuarios([FromBody]Usuario usuario)
        {
            return this.redSocialDataProvider.ListarUsuarios(usuario);
        }
    }
}