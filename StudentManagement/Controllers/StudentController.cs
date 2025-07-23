using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using System.Collections.Generic;
using System.Linq;
namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id =1 , Name = "Dikshan KC", Age = 22 },
            new Student { Id= 2, Name ="Sabina KC", Age = 21 },
            new Student { Id = 3, Name ="Aayam KC", Age = 9}
        };

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {
                       return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Any() ? students.Max(s => s.Id) + 1: 1; // Assign a new ID
                students.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
    }
}
