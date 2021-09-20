using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TabimApplication.Models.Model
{

    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required,StringLength(50,ErrorMessage ="50 karakter olmalıdır")]
        public string Email { get; set; }
        [Required,StringLength(50, ErrorMessage = "50 karakter olmalıdır")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Telephone { get; set; }

        public int? AuthorizationId { get; set; }
        public Authorization Authorization { get; set; }
       

    }
}