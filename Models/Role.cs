namespace WebUser.Models
{
    public class Role : Model
    {
        public string Name { get; set; }

        public ICollection<Relationship> Relations { get; set; }
    }
}
