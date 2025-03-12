using MongoDB.Bson;

namespace Working_hours.Models
{
    public class Job
    {
        public ObjectId Id { get; set; }
        public string Time { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
    }
}
