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
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Required]
        public string CarClass { get; set; }
        [Required]
        public List<int> Services { get; set; }

    }
}
