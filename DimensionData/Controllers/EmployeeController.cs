using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DimensionData.Models;
using Microsoft.AspNetCore.Mvc;

namespace DimensionData.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL employeeDal = new EmployeeDAL();
        public IActionResult Index()
        {
            List<EmployeeInfo> empList = new List<EmployeeInfo>();
            empList = employeeDal.GetAllEmployee().ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EmployeeInfo objEmp)
        {
            if (ModelState.IsValid)
            {
                employeeDal.AddEmployee(objEmp);
                return RedirectToAction("Index");
            }
            return View(objEmp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeInfo emp = employeeDal.GetEmployeeById(id);
            if (id == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id,[Bind] EmployeeInfo ojbEmp)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeDal.UpdateEmployee(ojbEmp);
                return RedirectToAction("Index");
            }
            return View(employeeDal);
        }
    }
}
