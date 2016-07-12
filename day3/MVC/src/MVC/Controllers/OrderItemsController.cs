using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Data;

namespace MVC.Controllers
{
    public class OrderItemsController : Controller
    {
        private ApplicationDbContext _context;
        public OrderItemsController(ApplicationDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index()
        {
            var items = _context.OrderItems.ToList();
            return View(items);
        }

        public IActionResult Update(int id)
        {
            var itemToUpdate = _context.OrderItems.SingleOrDefault(x => x.Id == id);
            if (itemToUpdate == null)
            {
                return RedirectToAction("Index");
            }

            return View(itemToUpdate);
        }

        [HttpPost]
        public IActionResult Update(OrderItem updatedOrderItem)
        {
            if (ModelState.IsValid)
            {
                _context.OrderItems.Update(updatedOrderItem);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(updatedOrderItem);
            }
        }

        public IActionResult Delete(int id)
        {
            var itemToDelete = _context.OrderItems.SingleOrDefault(x => x.Id == id);

            if (itemToDelete != null)
            {
                _context.OrderItems.Remove(itemToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderItem newOrderItem)
        {
            if (ModelState.IsValid)
            {
                _context.OrderItems.Add(newOrderItem);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(newOrderItem);
            }
        }
    }
}