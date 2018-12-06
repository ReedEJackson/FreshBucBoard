using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BucBoard.Models
{
    public class AppointmentModel
    {
        [DataType(DataType.EmailAddress), Display(Name = "To")]
        [Required]
        public string Sender { get; set; }

        [Display(Name = "ApptNumber")]
        [Required]
        public string ApptNumber { get; set; }

        [Display(Name = "StuId")]
        [DataType(DataType.MultilineText)]
        public string ID { get; set; }
    }
}