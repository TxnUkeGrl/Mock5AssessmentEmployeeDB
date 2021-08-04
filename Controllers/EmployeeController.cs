using Assessment5Mock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment5Mock.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            return View(employees);
        }

        public IActionResult DeleteEmployee(int Id)
        {
            var foundEmployee = _context.Employees.Find(Id);
            if (foundEmployee != null)
            {
                _context.Employees.Remove(foundEmployee);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult EmployeeForm(int Id)
        {
            if (Id == 0)
            {
                return View(new Employee());
            }
            else
            {
                Employee foundEmployee = _context.Employees.Find(Id);
                return View(foundEmployee);
            }
        }

        public IActionResult SaveEmployee(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                if (newEmployee.Id == 0)
                {
                    _context.Employees.Add(newEmployee);
                    _context.SaveChanges();
                }
                else
                {
                    Employee dbEmployee = _context.Employees.Find(newEmployee.Id);
                    dbEmployee.FirstName = newEmployee.FirstName;
                    dbEmployee.Age = newEmployee.Age;
                    dbEmployee.Salary = newEmployee.Salary;

                    _context.Entry(dbEmployee).State = EntityState.Modified;
                    _context.Update(dbEmployee);
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
