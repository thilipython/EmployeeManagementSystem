﻿using System;
namespace EmployeeMangementSystem.Models
{
	public class AddEmployeeViewModel
	{
        public string Name { get; set; }

        public string Email { get; set; }

        public long Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        public String Department { get; set; } 
    }
}

