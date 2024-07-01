using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMangementSystem.Data;
using EmployeeMangementSystem.Models;
using EmployeeMangementSystem.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeMangementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> Add(AddEmployeeViewModel viewModel)
        {
            var employee = new Employee
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Salary = viewModel.Salary,
                DateOfBirth = viewModel.DateOfBirth,
                Department = viewModel.Department,
            };

            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]

        public async Task<IActionResult> List()
        {
            var employees = await dbContext.Employees.ToListAsync();

            return View(employees);
        }


        [HttpGet]

        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            return View(employee);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Employee viewModel)
        {
           var employee = await dbContext.Employees.FindAsync(viewModel.Id);

            if (employee is not null)
            {
                employee.Name = viewModel.Name;
                employee.Email = viewModel.Email;
                employee.Salary = viewModel.Salary;
                employee.DateOfBirth = viewModel.DateOfBirth;
                employee.Department = viewModel.Department;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employees");
        }


        [HttpPost]

        public async Task<IActionResult> Delete(Employee viewModel)
        {
            
            var employee = await dbContext.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if(employee is not null)
            {
                dbContext.Employees.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Employees");
        }
    }
}

