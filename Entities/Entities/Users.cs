namespace Entities.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Users")]
    public partial class Users
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
