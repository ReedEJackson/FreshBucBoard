using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BucBoard.Models
{
    public class SendEmailModel
    {
        [DataType(DataType.EmailAddress), Display(Name = "To")]
        [Required]
        public string Sender { get; set; }

        [Display(Name = "Subject")]
        [Required]
        public string Subject { get; set; }

        [Display(Name = "Body")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }



    }
}