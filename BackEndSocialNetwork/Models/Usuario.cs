using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEndSocialNetwork.Models
{
    public class Usuario
    {
        [Key]
        public string LOGIN { get; set; }
        public string P_PRIMERNOMBRE { get; set; }
	    public string P_SEGUNDONOMBRE { get; set; }
	    public string P_PRIMERAPELLIDO { get; set; }
	    public string P_SEGUNDOAPELLIDO { get; set; }
	    public string P_FECHANACIMIENTO { get; set; }
        public string P_FECHACREACION { get; set; }
	    public string P_SEXO { get; set; }
        public string P_EMAIL { get; set; }
	    public string P_ROL { get; set; }
        public string P_VALIDADOFACEBOOK { get; set; }
        public string P_PASSWORD { get; set; }

    }
}
