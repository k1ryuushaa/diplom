using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArtRoyalDetailing.Domain.ViewModels
{
    public class AddServiceViewModel
    {
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public int ServiceType { get; set; }
        [Required]
        public string CostOne { get; set; }
        [Required]
        public string CostTwo { get; set; }
        [Required]
        public string CostThree { get; set; }
        [Required]
        public string CostFour { get; set; }
        [Required]
        public string CostFive { get; set; }
    }
}
