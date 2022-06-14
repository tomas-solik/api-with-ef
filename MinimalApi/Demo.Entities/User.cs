using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities
{
    [Table("Users")]
    public class User
    {
        //[Key]
        public virtual string Username { get; set; }

        //[MaxLength(255)]
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        //[MaxLength(255)]
        //[Required]
        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual bool IsBlocked { get; set; }
    }
}