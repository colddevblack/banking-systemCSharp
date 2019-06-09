using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BancoExt.Models
{
    public class TipoContaModel
    {
        [Key]
        public int id { get; set; }
        public string nomeconta { get; set; }

        public List<ContaModel> contas { get; set; }
    }
}
