using HomeStyler.Api.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeStyler.Api.Data.Entities
{
    [Table(nameof(User))]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string? FullName { get; set; }

        [Required, MaxLength(100)]
        public string? Email { get; set; }

        [Required, MaxLength(25)]
        public string? Password { get; set; }

        public static IEnumerable<User> GetInitialUsers() =>
           new List<User>
           {
                new User
                {
                    Id = 1,
                    FullName = "admin",
                    Email = "admin@gmail.com",
                    Password = "123",
                    
                }
           };

    }
}
