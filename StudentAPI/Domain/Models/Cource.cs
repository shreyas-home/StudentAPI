namespace StudentAPI.Domain.Models
{
    public class Cource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
