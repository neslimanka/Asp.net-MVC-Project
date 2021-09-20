using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TabimApplication.Models.Model
{

    [Table("Authorization")]
    public class Authorization
    {
        [Key]
        public int AuthorizationId { get; set; }
        public string AuthorizationName { get; set; }
        public ICollection<User> User { get; set; }


    }
}