using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoShop.Models;

namespace AutoShop.Controllers
{
  
    public class WorkOrderController : Controller
    {
        private readonly AutoRepairDbContext _context;

        public WorkOrderController(AutoRepairDbContext context)
        {
            _context = context;
        }

        // -------------------------
        // INDEX
        // -------------------------
        public IActionResult Index()
        {
            var list = _context.WorkOrders.ToList();
            return View(list);
        }

        // -------------------------
        // CREATE
        // -------------------------
        public IActionResult Create()
        {
            var vm = new WorkOrderView
            {
                WorkOrder = new WorkOrder(),
                Details = new List<WorkOrderDetail>
                {
                    new WorkOrderDetail()
                }
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(WorkOrderView vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            _context.WorkOrders.Add(vm.WorkOrder);
            _context.SaveChanges();

            foreach (var d in vm.Details)
            {
                d.WorkOrder_Id = vm.WorkOrder.Id;
                _context.WorkOrderDetails.Add(d);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // -------------------------
        // EDIT
        // -------------------------
        public IActionResult Edit(int id)
        {
            var wo = _context.WorkOrders.Find(id);

            if (wo == null)
            {
                return NotFound();
            }

            var vm = new WorkOrderView
            {
                WorkOrder = wo,
                Details = _context.WorkOrderDetails?
                            .Where(d => d.WorkOrder_Id == id)
                            .ToList() ?? new List<WorkOrderDetail>()
            };

            return View(vm);
        }


        [HttpPost]
        public IActionResult Edit(WorkOrderView vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            _context.WorkOrders.Update(vm.WorkOrder);

            var old = _context.WorkOrderDetails
                .Where(d => d.WorkOrder_Id == vm.WorkOrder.Id);
            _context.WorkOrderDetails.RemoveRange(old);

            foreach (var d in vm.Details)
            {
                d.WorkOrder_Id = vm.WorkOrder.Id;
                _context.WorkOrderDetails.Add(d);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //---------------------------
        //Details
        //---------------------------
        public IActionResult Details(int id)
        {
            var workOrder = _context.WorkOrders.FirstOrDefault(w => w.Id == id);

            if (workOrder == null)
                return NotFound();

            var details = _context.WorkOrderDetails
                .Where(d => d.WorkOrder_Id == id)   // Use your actual FK property name
                .ToList();

            var vm = new WorkOrderView
            {
                WorkOrder = workOrder,
                Details = details
            };

            return View(vm);
        }


        // GET: WorkOrder/Delete/5
        public IActionResult Delete(int id)
        {
            var workOrder = _context.WorkOrders.FirstOrDefault(w => w.Id == id);

            if (workOrder == null)
                return NotFound();

            var details = _context.WorkOrderDetails
                .Where(d => d.WorkOrder_Id == id)   // <-- use your actual FK property name
                .ToList();

            var vm = new WorkOrderView
            {
                WorkOrder = workOrder,
                Details = details
            };

            return View(vm);
        }

        // POST: WorkOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var workOrder = _context.WorkOrders.FirstOrDefault(w => w.Id == id);

            if (workOrder == null)
                return NotFound();

            // Delete details first
            var details = _context.WorkOrderDetails
                .Where(d => d.WorkOrder_Id == id)   // <-- use your actual FK property name
                .ToList();

            _context.WorkOrderDetails.RemoveRange(details);

            // Delete work order
            _context.WorkOrders.Remove(workOrder);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
