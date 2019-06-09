using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BancoExt.Models;
using BancoExt.DataAccess;

namespace APLICACAO.Controllers
{
    public class ContaController : Controller


    {
        private BancoContext db;

        public ContaController()
        {
            db = new BancoContext();
        }

        [HttpGet]
        public ActionResult ConsultaConta()
        {
            return View(db.contadb.ToList());
        }

        [HttpGet]
        public ActionResult CadastrarConta()
        {
            
            ViewBag.tipocontaid = new SelectList(db.tipocontadb.ToList(), "id", "nomeconta");
            ViewBag.clienteid = new SelectList(db.clientedb.ToList(), "id", "nome");
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarConta(ContaModel contaref)
        {
            db.contadb.Add(contaref);
            db.SaveChanges();
            return RedirectToAction("ConsultaConta");
        }

        [HttpGet]
        public ActionResult EditarConta(int id)
        {
            var model = db.contadb.Find(id);
            ViewBag.tipocontaid = new SelectList(db.tipocontadb.ToList(), "id", "nomeconta");
            ViewBag.clienteid = new SelectList(db.clientedb.ToList(), "id", "nome");

            return View(model);

        }



        [HttpPost]
        public ActionResult EditarConta(ContaModel conta)
        {

            db.Entry(conta).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexConta");
        }


        public ActionResult DeletarConta(int id)
        {

            var obj = db.contadb.Find(id);
            db.contadb.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("ConsultaConta");
        }

    }
}