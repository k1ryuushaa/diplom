using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArtRoyalDetailing.Domain.ViewModels
{
    public class AppointmentViewModel
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public int Hours { get; set; }
        [Required]
        public int Minutes { get; set; }
        [Required]
        public string CarClass { get; set; }
        [Required]
        public List<int> Services { get; set; }

    }
}
