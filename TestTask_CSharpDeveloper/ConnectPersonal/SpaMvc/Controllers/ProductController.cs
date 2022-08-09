using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SpaMvc.DAL;
using SpaMvc.Infrastructure.Abstract;
using SpaMvc.Models;
using SpaMvc.ViewModels;
using System.Data;
using Newtonsoft.Json;

namespace SpaMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly IDataRepository<Product> _productDataRepository;
        private readonly IServerConnect _serverConnect;
        private Int32 _category = -1;

        public ProductController(ApplicationContext context, IDataRepository<Product> dataRepository, IServerConnect serverConnect)
        {
            _context = context;
            _productDataRepository = dataRepository;
            _serverConnect = serverConnect;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> GetProducts(List<Product>? products, Int32 category = 62000, Int32? page = 1,
            SortState sortState = SortState.NameAsc)
        {
            Int32 pageSize = 30;

            List<Product> _products = new List<Product>();
            if (products == null || category == _category)
                _products = products;
            else
            {
                using (SqlConnection? conn = _serverConnect.Connect())
                {
                    conn.Open();
                    String sqlExpression =
                    @$"
                    declare @cId int
                    set @cId = {category}
                    select p.Id, Product, Cost, Descriptions, Color from Products p inner join CategoryProduct cp on p.Id = cp.ProductId
                    inner join Category c on c.Id = cp.CategoriesId where c.Id = @cId";

                    SqlCommand command = new(sqlExpression, conn);
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                            while (await reader.ReadAsync())
                                _products.Add(new Product
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Cost = reader.GetInt32(2),
                                    Descriptions = reader.GetString(3),
                                    Color = reader.GetString(4)
                                });
                    }
                }
            }

            switch (sortState)
            {
                case SortState.NameDesc:
                    _products = _products.OrderByDescending(s => s.Name).ToList();
                    break;
                case SortState.CostAsc:
                    _products = _products.OrderBy(s => s.Cost).ToList();
                    break;
                case SortState.CostDesc:
                    _products = _products.OrderByDescending(s => s.Cost).ToList();
                    break;
                default:
                    _products = _products.OrderBy(s => s.Name).ToList();
                    break;
            };

            var count = _products.Count();
            var items = _products.Skip(((Int32)page - 1) * pageSize).Take(pageSize);

            GetSortedViewModel viewModel = new GetSortedViewModel
            {
                PageViewModel = new PageViewModel(count, (Int32)page, pageSize),
                SortViewModel = new SortViewModel(sortState),
                FilterViewModel = new FilterViewModel(_context.Category.AsNoTracking().ToList(), category),
                Products = items
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
            => View();
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetProducts");
        }
        [HttpGet]
        public async Task<IActionResult> GetJson(Int32 category, Int32 page = 1)
        {
            Int32 pageSize = 100;
            var _products = new List<Product>();

            using (SqlConnection? conn = _serverConnect.Connect())
            {
                conn.Open();
                String sqlExpression =
                @$"
                    declare @cId int
                    set @cId = {category}
                    select p.Id, Product, Cost, Descriptions, Color from Products p inner join CategoryProduct cp on p.Id = cp.ProductId
                    inner join Category c on c.Id = cp.CategoriesId where c.Id = @cId";

                SqlCommand command = new(sqlExpression, conn);
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                        while (await reader.ReadAsync())
                            _products.Add(new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Cost = reader.GetInt32(2),
                                Descriptions = reader.GetString(3),
                                Color = reader.GetString(4)
                            });
                }
            }
            var count = _productDataRepository.GetHashCode();
            var items = _products.Skip(((Int32)page - 1) * pageSize).Take(pageSize);


            JsonViewModel viewModel = new JsonViewModel
            {
                PageViewModel = new PageViewModel(count, (Int32)page, pageSize),
                JsonResult = JsonConvert.SerializeObject(items, Formatting.Indented),
                SelectedCategory = category
            };
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id != null)
            {
                Product product = await _context.Products.FindAsync(id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetProducts");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Product product = new Product { Id = id.Value };
                _context.Entry(product).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return RedirectToAction("GetProducts");
            }
            return NotFound();
        }
    }
}
