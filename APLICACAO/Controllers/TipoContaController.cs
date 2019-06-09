using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BancoExt.Models;
using BancoExt.DataAccess;

namespace APLICACAO.Controllers
{
    public class TipoContaController : Controller
    {
        private BancoContext db;

        public TipoContaController()
        {
            db = new BancoContext();
        }

        [HttpGet]
        public ActionResult ConsultaTipoConta()
        {
            return View(db.tipocontadb.ToList());
        }

        [HttpGet]
        public ActionResult CadastrarTipoConta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarTipoConta(TipoContaModel tipoconta)
        {
            db.tipocontadb.Add(tipoconta);
            db.SaveChanges();
                return RedirectToAction("ConsultaTipoConta");
        }
        public ActionResult EditarTipoConta(int Id)
        {
            var model = db.tipocontadb.Find(Id);
            
            return View(model);

        }

        [HttpPost]
        public ActionResult EditarTipoConta(TipoContaModel tipoconta)
        {

            db.Entry(tipoconta).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ConsultaTipoConta");
        }


        public ActionResult DeletarTipoConta(int Id)
        {

            var obj = db.tipocontadb.Find(Id);
            db.tipocontadb.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("ConsultaTipoConta");
        }
    }
}