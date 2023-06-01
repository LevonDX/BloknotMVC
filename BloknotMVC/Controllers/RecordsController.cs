using BloknotMVC.Data.Context;
using BloknotMVC.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BloknotMVC.Controllers
{
    public class RecordsController : Controller
    {
        [HttpPost]
        public IActionResult Add(Record record)
        {
            using var context = new BloknotDBContext();
            context.Records.Add(record);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            using var context = new BloknotDBContext();
            var records = context.Records.ToList();

            return View(records);
        }
    }
}