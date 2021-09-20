using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TabimApplication.Models.Model
{

    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Required, StringLength(50, ErrorMessage = "5 karakter olmalıdır")]
        public string Name { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakter olmalıdır")]
        public string Email { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakter olmalıdır")]
        public string ReceiveMail { get; set; }
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}