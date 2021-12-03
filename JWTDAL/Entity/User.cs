using AppCore.Entity;
using System.Collections.Generic;

namespace JWTDAL.Entity
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string IdentityNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
