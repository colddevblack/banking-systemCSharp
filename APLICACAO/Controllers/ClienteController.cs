using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BancoExt.Models;
using BancoExt.DataAccess;

namespace APLICACAO.Controllers
{
    public class ClienteController : Controller
    {

        private BancoContext db;

        public ClienteController()
        {
            db = new BancoContext();
        }
      
        public ActionResult ConsultaClientes()

        {
            ViewBag.cliente = new SelectList(db.clientedb.ToList(), "id", "nome");
            ViewBag.cpf = new SelectList(db.clientedb.ToList(), "id", "cpf");
            ViewBag.dataNascimento = new SelectList(db.clientedb.ToList(), "id", "dataNascimento");
            return View(db.clientedb.ToList());
        }

        [HttpGet]
        public ActionResult CadastroCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastroCliente(ClienteModel clientemodref)
        {
            clientemodref.dataCriacao = DateTime.Now;
            db.clientedb.Add(clientemodref);
            db.SaveChanges();
            return RedirectToAction("ConsultaClientes");
        }

        [HttpGet]
        public ActionResult EditarCliente(int id)
        {
            var model = db.clientedb.Find(id);
            

            return View(model);
        }



        [HttpPost]
        public ActionResult EditarCliente(ClienteModel cliente)
        {

            db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("ConsultaClientes");
        }


        public ActionResult DeletarCliente(int Id)
        {
            var tr = db.transacaodb.Find(Id);
            db.transacaodb.Remove(tr);
            var obj = db.clientedb.Find(Id);
            db.clientedb.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("ConsultaClientes");
        }

        [HttpGet]
        public ActionResult _BuscasCliente(int? idcliente, string idcpf, DateTime? dataNasc )
        {
            {
                // consulta linq
                List<ClienteModel> cliente = (from u in db.clientedb
                               where (idcliente != null ? u.id == idcliente : 0 == 0)
                               && (idcpf != null ? u.cpf == idcpf : 0 == 0)
                               && (dataNasc != null ? u.dataNascimento == dataNasc : 0 == 0)
                               select u
                               ).ToList();

                return PartialView(cliente);
            }
        }
    }
}
