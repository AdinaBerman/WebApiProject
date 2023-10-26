using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        public string UserName { get; set; }
        //[EmailAddress] add validation
        public string Password { get; set; }
        public string FirstName { get; set; }
        //[StringLength(15)]
        public string LastName { get; set; }
        //[StringLength(15)]
        public int UserId { get; set; }
    }
}
