using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BancoExt.Models
{
    public class TipoTransacaoModel
    {
        [Key]
        public int id { get; set; }
        public string nometr { get; set; }

        public List<TransacaoModel> transacao { get; set; }
    }
}
