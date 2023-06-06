using BloknotMVC.Data.Context;
using BloknotMVC.Data.Entities;
using BloknotMVC.Implementation;
using BloknotMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloknotMVC.Controllers
{
    public class RecordsController : Controller
    {
        ILoggerService _logger;
        BloknotDBContext _context;

        // contructor injection
        public RecordsController(ILoggerService loggerService, BloknotDBContext context)
        {
            _logger = loggerService;
            _context = context;
        }

        [HttpPost]
        public IActionResult Add(Record record)
        {
            _context.Records.Add(record);
            _context.SaveChanges();

            _logger.WriteLog($"Record {record.Id} added");

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
            var records = _context.Records.ToList();

            _logger.WriteLog("Records list requested");

            return View(records);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Record? record = await _context.Records.FindAsync(id); // Read/Write (IO)

            await _context.SaveChangesAsync();

            return View(record);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Record record)
        {

            _context.Records.Update(record);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Record? record = await _context.Records.FindAsync(id);

            if (record == null)
                return NotFound();

            _context.Records.Remove(record);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}