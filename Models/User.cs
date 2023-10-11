namespace WebUser.Models
{
    public class User : Model
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public ICollection<Relationship> Relations { get; set; }
    }
}
