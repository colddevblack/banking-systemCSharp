using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BancoExt.Models
{
    public class TransacaoModel
    {
       

        [Key]
        public int id { get; set; }
        public double valor { get; set; }
        //referencias outra model Conta FKs
        //FK1
        public int contaid { get; set; }
        public virtual ContaModel ContaModel { get; set; }

        //referencia TipoTransacaoModel
        public int tipotransacaoid { get; set; }
        public virtual TipoTransacaoModel TipoTransacaoModel { get; set; }

        // Listas de relacionamento
        public List<ContaModel> contas { get; set; }

        public List<TipoTransacaoModel> tipotransacao { get; set; }
    }
}
