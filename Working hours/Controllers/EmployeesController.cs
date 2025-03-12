using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Working_hours.Models;

namespace Working_hours.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            var client = new MongoClient();
            var collection = client.GetDatabase("working_hours").GetCollection<Employee>("employees");

            List<Employee> employees = collection.Find(e => true).ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            var client = new MongoClient();
            var collection = client.GetDatabase("working_hours").GetCollection<Employee>("employees");
            collection.InsertOne(employee);

            return Redirect("/Employees");
        }
        public IActionResult ShowEmployee(string Id)
        {
            ObjectId objectId = new ObjectId(Id);
            var client = new MongoClient();
            var collection = client.GetDatabase("working_hours").GetCollection<Employee>("employees");

            Employee employee = collection.Find(e => e.Id == objectId).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public IActionResult DeleteEmployee(string Id)
        {
            ObjectId objectId = new ObjectId(Id);
            var client = new MongoClient();
            var collection = client.GetDatabase("working_hours").GetCollection<Employee>("employees");
            collection.DeleteOne(e => e.Id == objectId);

            return Redirect("/Employees");
        }
        public IActionResult EditEmployee(string Id)
        {
            ObjectId employeeId = new ObjectId(Id);
            var client = new MongoClient();
            var collection = client.GetDatabase("working_hours").GetCollection<Employee>("employees");

            Employee employee = collection.Find(e => e.Id == employeeId).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public IActionResult EditEmployee(string Id, Employee employee)
        {
            ObjectId employeeId = new ObjectId(Id);
            var client = new MongoClient();
            var collection = client.GetDatabase("working_hours").GetCollection<Employee>("employees");

            employee.Id = employeeId;
            collection.ReplaceOne(e => e.Id == employeeId, employee);
            return Redirect("/Employees");
        }
    }
}
