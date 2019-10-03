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

    }
}
