using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace taller_registrate.Model
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }

        [MaxLength(40)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength (20)]
        public string Password { get; set; }

    }
}
