using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Working_hours.Models;

namespace Working_hours.Controllers
{
    public class JobsController : Controller
    {
        public IActionResult Index()
        {
            var client = new MongoClient();
            var collection = client.GetDatabase("working_hours").GetCollection<Job>("jobs");

            List<Job> jobs = collection.Find(j => true).ToList();
            return View(jobs);
        }
        public IActionResult CreateJob()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateJob(Job job)
        {
            var client = new MongoClient();
            var collection = client.GetDatabase("working_hours").GetCollection<Job>("jobs");
            collection.InsertOne(job);

            return Redirect("/Jobs");
        }
        public IActionResult ShowJob(string Id)
        {
            ObjectId objectId = new ObjectId(Id);
            var client = new MongoClient();
            var collection = client.GetDatabase("working_hours").GetCollection<Job>("jobs");

            Job job =collection.Find(j => j.Id == objectId).FirstOrDefault();
            return View(job);
        }

        [HttpPost]
        public IActionResult DeleteJob(string Id)
        {
            ObjectId objectId = new ObjectId(Id);
            var client = new MongoClient();
            var collection = client.GetDatabase("working_hours").GetCollection<Job>("jobs");

            collection.DeleteOne(j => j.Id == objectId);
            return Redirect("/Jobs");
        }
        public IActionResult EditJob(string Id)
        {
            ObjectId jobId = new ObjectId(Id);
            var client = new MongoClient();
            var collection = client.GetDatabase("working_hours").GetCollection<Job>("jobs");

            Job job = collection.Find(j => j.Id == jobId).FirstOrDefault();
            return View(job);
        }

        [HttpPost]
        public IActionResult EditJob(string Id, Job job)
        {
            ObjectId jobId = new ObjectId(Id);
            var client = new MongoClient();
            var collection = client.GetDatabase("working_hours").GetCollection<Job>("jobs");

            job.Id = jobId;
            collection.ReplaceOne(j => j.Id == jobId, job);
            return Redirect("/Jobs");
        }
    }
}
