﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeProdutos.Models
{
    [Table("Usuario")]
    public class UserModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    
    }
}
