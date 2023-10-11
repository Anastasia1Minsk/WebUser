namespace WebUser.ModelsDto
{
    public class NewUserDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<int> RolesId { get; set; }
    }
}
