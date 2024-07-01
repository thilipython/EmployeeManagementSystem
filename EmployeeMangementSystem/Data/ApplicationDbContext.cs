using System;
using EmployeeMangementSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangementSystem.Data
{
	public class ApplicationDbContext : DbContext 
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }
	}
}

