using AppCore.Entity;

namespace JWTDAL.Entity
{
    public class UserRole : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User UserFK { get; set; }
        public int RoleId { get; set; }
        public Role RoleFK { get; set; }
    }
}
