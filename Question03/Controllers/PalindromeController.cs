using LibrariesStage01.DBContext;
using LibrariesStage01.Interface;
using LibrariesStage01.Models;
using LibrariesStage01.Repository;
using Question03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Question03.Controllers
{
    public class PalindromeController : Controller
    {
        private readonly IDatabaseRepository _repo;

        private readonly Q2DbContext _dbContext;

        private readonly int ApplicationId = 1;

        public PalindromeController()
        {
            _repo = new DatabaseRepository(new DefaultDbContext());
            _dbContext = new Q2DbContext();
        }

        public ActionResult Index()
        {
            var model = new PalindromeViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult FindAndStorePalindromes(PalindromeViewModel model)
        {
            List<string> palindromes = _repo.FindPalindromes(model.InputString);
            SaveToDatabase(model.InputString, string.Join(",", palindromes),ApplicationId);
            model.Palindromes = palindromes;
            return View("Index",model);
        }

        [HttpGet]
        public ActionResult GetStoredData()
        { 
            var storedData = RetrieveFromDatabase(ApplicationId);

            var viewModel = new PalindromeViewModel
            {
                StoredData = storedData.Select(item => new TableLogicViewModel
                {
                    ID = item.ID,
                    InputValue = item.InputValue,
                    OutputValue = item.OutputValue
                }).ToList()
            };

            return View("StoredData", viewModel);
        }

        private void SaveToDatabase(string input, string output, int applicationId)
        {
            _dbContext.tableLogics.Add(new TableLogic { InputValue = input, OutputValue = output, ApplicationId = applicationId });
            _dbContext.SaveChanges();
        }

        private List<TableLogic> RetrieveFromDatabase(int applicationId)
        {
            return _dbContext.tableLogics.Where(x=>x.ApplicationId == applicationId).ToList();
        }
    }
}