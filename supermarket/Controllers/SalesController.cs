using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using supermarket.Data;
using supermarket.Models;
using supermarket.Models.ViewModels;

namespace supermarket.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sales = _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.SaleDetails)
                .ThenInclude(d => d.Product)
                .ToList();

            return View(sales);
        }

        public IActionResult Create()
        {
            ViewBag.Products = _context.Products.ToList();
            return View(new SaleViewModel());
        }

        [HttpPost]
        public IActionResult FindCustomer(string identificationNumber)
        {
            var customer = _context.Customers
                .FirstOrDefault(c => c.IdentificationNumber == identificationNumber);

            return Json(customer);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] AddProductRequest request)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == request.ProductId);
            if (product == null)
                return Json(new { success = false, message = "Product not found." });

            if (product.StockQuantity < request.Quantity)
                return Json(new { success = false, message = "Not enough stock available." });

            var subtotal = product.UnitPrice * request.Quantity;
            return Json(new
            {
                success = true,
                productId = product.Id,
                productName = product.Name,
                quantity = request.Quantity,
                unitPrice = product.UnitPrice,
                subtotal = subtotal
            });
        }

        [HttpPost]
        public IActionResult SaveSale([FromBody] SaveSaleRequest request)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == request.CustomerId);
            if (customer == null)
                return Json(new { success = false, message = "Customer not found." });

            decimal total = 0;
            foreach (var item in request.Products)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == item.ProductId);
                if (product == null || product.StockQuantity < item.Quantity)
                    return Json(new { success = false, message = $"Not enough stock for {product?.Name}" });

                total += product.UnitPrice * item.Quantity;
            }

            var sale = new Sale
            {
                CustomerId = customer.Id,
                SaleDate = DateTime.Now,
                TotalAmount = total
            };

            _context.Sales.Add(sale);
            _context.SaveChanges();

            foreach (var item in request.Products)
            {
                var product = _context.Products.First(p => p.Id == item.ProductId);

                var detail = new SaleDetail
                {
                    SaleId = sale.Id,
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.UnitPrice,
                    Subtotal = product.UnitPrice * item.Quantity
                };

                _context.SaleDetails.Add(detail);

                product.StockQuantity -= item.Quantity;
                _context.Products.Update(product);
            }

            _context.SaveChanges();

            return Json(new { success = true, message = "Sale successfully recorded." });
        }
    }
}
