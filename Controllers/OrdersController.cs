//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using minh.Data;
//using minh.Models;
//using Newtonsoft.Json;
//using minh.Extensions;

//namespace minh.Controllers
//{
//    public class OrdersController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public OrdersController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Orders
//        public List<Book> getAllProduct()
//        {
//            return _context.Book.ToList();
//        }
//        public async Task<IActionResult> Index()
//        {
//            var _product = getAllProduct();
//            ViewBag.product = _product;
//            return View();
//        }
//        public Book getDetailProduct(int id)
//        {
//            var product = _context.Book.Find(id);
//            return product;
//        }
//        public IActionResult addCart(int id)
//        {
//            var cart = HttpContext.Session.GetString("cart");//get key cart
//            if (cart == null)
//            {
//                var product = getDetailProduct(id);
//                List<Cart> listCart = new List<Cart>()
//               {
//                   new Cart
//                   {
//                       Book = product,
//                       Quantity = 1
//                   }
//               };
//                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(listCart));

//            }
//            else
//            {
//                List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
//                bool check = true;
//                for (int i = 0; i < dataCart.Count; i++)
//                {
//                    if (dataCart[i].Book.Id == id)
//                    {
//                        dataCart[i].Quantity++;
//                        check = false;
//                    }
//                }
//                if (check)
//                {
//                    dataCart.Add(new Cart
//                    {
//                        Book = getDetailProduct(id),
//                        Quantity = 1
//                    });
//                }
//                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(dataCart));
//                // var cart2 = HttpContext.Session.GetString("cart");//get key cart
//                //  return Json(cart2);
//            }

//            return RedirectToAction(nameof(Index));

//        }
//        public IActionResult Create()
//        {
//            return View();
//        }

//        public IActionResult ConfirmOrder(Order orderDetails)
//            {
//            if (ModelState.IsValid)
//            {
//                var cart = HttpContext.Session.GetString("cart");
//                double totalPrice = 0;

//                if (cart != null)
//                {
//                    List<Cart> dataCart = JsonConvert.DeserializeObject<List<Cart>>(cart);
//                    if (dataCart.Count > 0)
//                    {
//                        // Tính tổng tiền
//                        foreach (var item in dataCart)
//                        {
//                            totalPrice += item.Book.Price * item.Quantity;
//                        }

//                        // Lưu thông tin vào đối tượng Order
//                        Order order = new Order
//                        {
//                            FullName = orderDetails.FullName,
//                            Address = orderDetails.Address,
//                            Total = totalPrice
//                        };

//                        // Lưu thông tin vào cơ sở dữ liệu
//                        // Code để lưu vào cơ sở dữ liệu sẽ ở đây (sử dụng Entity Framework hoặc phương thức lưu trực tiếp vào DB)
//                        // Ví dụ sử dụng Entity Framework:
//                        _context.Order.Add(order);
//                        _context.SaveChanges();

//                        return RedirectToAction(nameof(ThankYou)); // Chuyển hướng đến trang cảm ơn sau khi lưu thành công
//                    }
//                }

//                return RedirectToAction(nameof(Index)); // Hoặc chuyển hướng đến trang Index nếu không có dữ liệu giỏ hàng
//            }

//            return View(orderDetails);
//        }
//        public IActionResult ThankYou()
//        {
//            // Trả về view cảm ơn sau khi đặt hàng thành công
//            return View();
//        }
//    }
        
//}
