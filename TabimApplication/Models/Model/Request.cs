using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TabimApplication.Models.Model
{

    [Table("Request")]
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakter olmalıdır")]
        public string RequestName { get; set; }
        [Required, StringLength(50, ErrorMessage = "50 karakter olmalıdır")]
        public string RequestSurname { get; set; }
        public string RequestDescription { get; set; }
        [Required, StringLength(50, ErrorMessage = "Belge Ekleyiniz")]
        public string  DocumentPath { get; set; }
        public DateTime EvaluationTime { get; set; }
        public string AssessmentStatus { get; set; }
        public string Email { get; set; }
        [StringLength(50, ErrorMessage = "50 karakter olmalıdır")]
        public string FeedBack { get; set; }
    }
}