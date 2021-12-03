using AppCore.Entity;
using System.Collections.Generic;

namespace JWTDAL.Entity
{
    //Defines user's role. (Admin, User etc.)
    public class Role : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
