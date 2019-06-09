using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BancoExt.Models;
using BancoExt.DataAccess;

namespace APLICACAO.Controllers
{
    public class TipoTransacaoController : Controller
    {
        private BancoContext db;

        public TipoTransacaoController()
        {
            db = new BancoContext();
        }

        [HttpGet]
        public ActionResult ConsultaTipoTransacao()
        {
            return View(db.tipotransacaodb.ToList());
        }

        [HttpGet]
        public ActionResult CadastrarTipoTransacao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarTipoTransacao(TipoTransacaoModel tipotransacao)
        {
            db.tipotransacaodb.Add(tipotransacao);
            db.SaveChanges();
            return RedirectToAction("ConsultaTipoTransacao");
        }

        [HttpGet]
        public ActionResult EditarTipoTransacao(int Id)
        {
            var model = db.tipotransacaodb.Find(Id);
            
            return View(model);

        }

        [HttpPost]
        public ActionResult EditarTipoTransacao(TipoTransacaoModel tipotransacao)
        {

            db.Entry(tipotransacao).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ConsultaTipoTransacao");
        }


        public ActionResult DeletarTipoTransacao(int Id)
        {

            var obj = db.tipotransacaodb.Find(Id);
            db.tipotransacaodb.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("IndexTipoTransacao");
        }

    }
}