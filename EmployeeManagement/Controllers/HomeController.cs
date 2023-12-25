﻿using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
	public class HomeController : Controller
	{
		private readonly IEmployeeRepository _employeeRepository;

		public HomeController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		[Route("")]
		[Route("Home")]
		[Route("Home/Index")]
		public ViewResult Index()
		{
			var model = _employeeRepository.GetAllEmployee();
			return View(model);
		}

		[Route("Home/Details/{id?}")]
		public ViewResult Details(int? id)
		{

			HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
			{
				Employee = _employeeRepository.GetEmployee(id??101),
				PageTitle ="Employee Details"
			};

			return View(homeDetailsViewModel);
		}

		[HttpPost]
		public IActionResult Create(Employee employee)
		{
			if (ModelState.IsValid)
			{
				Employee newEmployee = _employeeRepository.Add(employee);
				return RedirectToAction("details", new { id = newEmployee.Id });
			}
			return View();
		}
	}
}
