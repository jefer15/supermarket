using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using supermarket.Data;
using supermarket.Models;

namespace supermarket.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            var sales = _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.SaleDetails)
                .ThenInclude(d => d.Product)
                .AsQueryable();

            if (startDate.HasValue && endDate.HasValue)
            {
                sales = sales.Where(s => s.SaleDate.Date >= startDate.Value.Date &&
                                         s.SaleDate.Date <= endDate.Value.Date);
            }

            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");

            return View(sales.ToList());
        }


        public IActionResult ExportPDF(DateTime? startDate, DateTime? endDate)
        {
            var sales = _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.SaleDetails)
                .ThenInclude(d => d.Product)
                .AsQueryable();

            if (startDate.HasValue && endDate.HasValue)
            {
                sales = sales.Where(s => s.SaleDate.Date >= startDate.Value.Date &&
                                         s.SaleDate.Date <= endDate.Value.Date);
            }

            var list = sales.ToList();

            return new ViewAsPdf("ReportPDF", list)
            {
                FileName = "SalesReport.pdf"
            };
        }
    }
}
