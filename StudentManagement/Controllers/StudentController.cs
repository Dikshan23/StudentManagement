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
            new Student { Id =1 , Name = "Dikshan KC",Email ="dixan294@gmail.com", Age = 22 },
            new Student { Id= 2, Name ="Sabina KC",Email ="Sabina23@gmail.com", Age = 21 },
            new Student { Id = 3, Name ="Aayam KC",Email = "aayam13@gmail.com",Age = 9}
        };

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Confirmation(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            return View(student);
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
                return RedirectToAction(nameof(Confirmation), new { id = student.Id });
            }
            return View(student);
        }
    }
}
