using LibrariesStage01.DBContext;
using LibrariesStage01.Interface;
using LibrariesStage01.Repository;
using Question1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Question1.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IDatabaseRepository _repo;

        public DefaultController()
        {
            _repo = new DatabaseRepository(new DefaultDbContext());
        }
        // GET: Default
        public ActionResult Index()
        {
            string entityResult = _repo.GetOutputFromEntity();
            string adoResult = _repo.GetOutputFromAdo();

            var viewModel = new IndexViewModel
            {
                EntityResult = entityResult,
                AdoResult = adoResult
            };

            return View(viewModel);
        }
    }
}