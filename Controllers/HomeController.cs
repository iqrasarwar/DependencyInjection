using Dependency_Injection.Models;
using Microsoft.AspNetCore.Mvc;
using Dependency_Injection.Models.Interfaces;
using System.Diagnostics;

namespace Dependency_Injection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployee empRepo;
        private readonly IWebHostEnvironment Environment;
        public HomeController(ILogger<HomeController> logger, IEmployee e, IWebHostEnvironment environment)
        {
            _logger = logger;
            empRepo = e;
            Environment = environment;
        }

        public IActionResult Index(List<IFormFile> postedFiles)
        {
            string wwwPath = this.Environment.WebRootPath;
            string path = Path.Combine(wwwPath, "Uploads");
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach(var file in postedFiles)
            {
                var fileName = Path.GetFileName(file.FileName);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    ViewBag.Message = "file Uploaded Successfully";
                }
            }
            return View();
        }

        public IActionResult EmployeeList()
        {
            return View(empRepo.GetAllEmployee());
        }

        /*public IActionResult CreateStudent(Student student)
        {

        }*/
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
