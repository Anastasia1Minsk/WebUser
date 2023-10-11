namespace WebUser.ModelsDto
{
    public class UserReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public List<RoleReturnDto> Roles { get; set; }
    }
}
