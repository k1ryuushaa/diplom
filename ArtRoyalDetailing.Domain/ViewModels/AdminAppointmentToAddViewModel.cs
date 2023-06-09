using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArtRoyalDetailing.Domain.ViewModels
{
    public class AdminAppointmentToAddViewModel
    {
        [Required]
        public string ClientNumber { get; set; }
        [Required]
        public string CarClass { get; set; }
        [Required]
        public string GosNumber { get; set; }
        [Required]
        public int AppointmentStatus { get; set; }
        [Required]
        public int IdAdmin { get; set; }
        [Required]
        public string DateAppointment { get; set; }
        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        [Required]
        public List<int> ServicesList { get; set; }
        [Required]
        public List<int> WorkersList { get; set; }
        [Required]
        public List<int> CostList { get; set; }
    }
}
