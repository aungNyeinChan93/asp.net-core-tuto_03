using System.ComponentModel.DataAnnotations;

namespace asp.net_tuto_03.Models.Users
{
    public class Users
    {
    }

    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(20)]
        public string Password { get; set; } = null!;

        public User() { }

        public User(int id,string name, string email,string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

    }

    public static class UserRepo
    {
        private static List<User> _users = new List<User>()
        {
            new (1,"Chan","chan@123","123123123"),
            new (2,"Susu","susu@123","123123123"),
        };

        public static List<User> GetUsers() => _users;

        public static User? GetUser(int? id) => _users.FirstOrDefault<User>(u => u.Id == id);

        public static void AddUser(User? user) => _users.Add(user!);

        public static User? UpdateUser(int? id ,User? user)
        {
            if(user is not null && id is not null)
            {
                var oldUser = _users.FirstOrDefault(u => u.Id == id);
                if (oldUser is null) return null;
                oldUser.Name = user.Name;
                oldUser.Email = user.Email;
                oldUser.Password = user.Password;
                return oldUser;
            }
            return null;
        }

        public static void DeleteUser(int? id) => _users.Remove(_users.FirstOrDefault(u => u.Id == id)!);
    }
}
