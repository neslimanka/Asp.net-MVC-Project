using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TabimApplication.Models.Model
{

    [Table("RequestState")]
    public class RequestState
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }

    }
}