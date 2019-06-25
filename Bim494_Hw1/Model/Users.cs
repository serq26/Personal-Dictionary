using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;
namespace Bim494_Hw1.Model
{
    [Table("Users")]
    public class Users
    {
        
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Email { get; set; }

        [MaxLength(200)]
        public string Password { get; set; }

        
    }
}
