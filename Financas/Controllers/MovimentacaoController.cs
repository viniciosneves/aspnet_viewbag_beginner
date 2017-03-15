using Financas.DAO;
using Financas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financas.Controllers
{
    [Authorize]
    public class MovimentacaoController : Controller
    {
        private MovimentacaoDao movimentacaoDao;
        private UsuarioDao usuarioDao;

        public MovimentacaoController(MovimentacaoDao movimentacaoDao, UsuarioDao usuarioDao)
        {

            this.movimentacaoDao = movimentacaoDao;

            this.usuarioDao = usuarioDao;
        }

        // GET: Movimentacao
        public ActionResult Index()
        {
            IList<Movimentacao> movimentacoes = movimentacaoDao.Lista();
            return View(movimentacoes);
        }

        public ActionResult Form()
        {
            ViewBag.Usuarios = usuarioDao.Lista();
            return View();
        }

        public ActionResult Adiciona(Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {

                movimentacaoDao.Adiciona(movimentacao);
                return RedirectToAction("Index");
            } else
            {
                ViewBag.Usuarios = usuarioDao.Lista();
                return View("Form", movimentacao);
            }
        }
    }
}