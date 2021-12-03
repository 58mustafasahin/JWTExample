namespace JWTDAL.Entity.Dto
{
    public class UserRegisterDto
    {
        public string IdentityNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int UserRole { get; set; }
    }
}
