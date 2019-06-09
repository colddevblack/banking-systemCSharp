using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BancoExt.Models;

namespace BancoExt.Models
{
    public class ContaModel
    {
        public int id { get; set; }
        public string numero { get; set; }
        public int agencia { get; set; }
        public double saldo { get; set; }

        //referencias outra model Cliente
        public int clienteid { get; set; }
        public virtual ClienteModel ClienteModel { get; set; }

        //referencias outra model Tipo Conta
        public int tipocontaid { get; set; }
        public virtual TipoContaModel tipocontamodel { get; set; }

        //referencias outra model Transacao
        public int transacaoid { get; set; }
        public virtual TransacaoModel TransacaoModel { get; set; }

        //lista transacoes

        public List<TransacaoModel> transacao { get; set; }

    }
}