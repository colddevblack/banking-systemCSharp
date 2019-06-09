using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BancoExt.Models;
using BancoExt.DataAccess;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


namespace APLICACAO.Controllers
{
    public class TransacaoController : Controller
    {
       

        private BancoContext db;

        public TransacaoController()
        {
            db = new BancoContext();
        }

        public ActionResult ConsultaTransacao()
        {

            
            ViewBag.cliente = new SelectList(db.clientedb.ToList(), "id", "nome");
            ViewBag.conta = new SelectList(db.contadb.ToList(), "id", "numero");
            ViewBag.tipotransacao = new SelectList(db.tipotransacaodb.ToList(), "id", "nometr");

            return View();
        }



        [HttpGet]
        public ActionResult ExecutTransacao()
        {

            ViewBag.clienteid = new SelectList(db.clientedb.ToList(), "id", "nome");
            ViewBag.contaid = new SelectList(db.contadb.ToList(), "id", "numero");
            ViewBag.tipotransacaoid = new SelectList(db.tipotransacaodb.ToList(), "id", "nometr");


            return View();

        }

        [HttpPost]
        public ActionResult ExecutTransacao(TransacaoModel transacao)
        {


            //CREDITO
            if (transacao.tipotransacaoid == 1)
            {
                // salva a primeira transacao
                db.transacaodb.Add(transacao);
                db.SaveChanges();
                // executa credito

                var conta = db.contadb.Find(transacao.contaid);
                conta.saldo += transacao.valor;
                db.Entry(conta).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ConsultaTransacao");



            }

            //DEBITO/SAQUE
            if (transacao.tipotransacaoid == 2 | transacao.tipotransacaoid == 3)
            {
                // salva a primeira transacao
                db.transacaodb.Add(transacao);
                db.SaveChanges();

                // executa Debito/Saque
                var conta = db.contadb.Find(transacao.contaid);

                // condição se saldo for suficiente executa debito
                if (transacao.valor <= conta.saldo)
                {
                    conta.saldo -= transacao.valor;
                    db.Entry(conta).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("ConsultaTransacao");
                }

                //se saldo for insuficiente executa tela de erro
                else
                {

                    ViewBag.clienteid = new SelectList(db.clientedb.ToList(), "id", "nome");
                    ViewBag.contaid = new SelectList(db.contadb.ToList(), "id", "numero");
                    ViewBag.tipotransacaoid = new SelectList(db.tipotransacaodb.ToList(), "id", "nometr");


                    ViewBag.msg = "Não e possivel efetuar saldo insuficiente";
                    return View(transacao);


                }

            }


            //TRANSFERENCIA
            if (transacao.tipotransacaoid == 4)
            {
                // salva a primeira transacao

                db.transacaodb.Add(transacao);
                db.SaveChanges();
                // executa transacao transferencia origem 
                var contaorigem = db.contadb.Find(transacao.contaid);
                contaorigem.saldo -= transacao.valor;
                db.Entry(contaorigem).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                // executa transacao transferencia destino 
                var contadestino = db.contadb.Find(transacao.contaid);
                contadestino.saldo += transacao.valor;
                db.Entry(contadestino).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ConsultaTransacao");



            }

            return RedirectToAction("ConsultaTransacao");

        }
       
        public ActionResult DeletarTransacao(int ID)
        {
            
            var obj = db.transacaodb.Find(ID);
            db.transacaodb.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("ConsultaTransacao");
        }

        //pesquisas com partial view
        [HttpGet]
        public ActionResult _Buscas(int? idconta, int? idcliente, int? idtipotransacao)
        {

         
            
            ViewBag.Transacao = db.transacaodb.Where(p => p.contaid == idconta && p.tipotransacaoid == idtipotransacao).ToList();
           

            return PartialView();

        }



        //metodo listar combos ajax
        public string ListaClientesAjax(int idCliente)
        {

            var modulos = (from p in db.contadb.Where(m => m.clienteid == idCliente).ToList()
                           select new { p.id, p.numero });

            return JsonConvert.SerializeObject(modulos, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

        }
    }
}