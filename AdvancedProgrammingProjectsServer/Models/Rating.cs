﻿using System.ComponentModel.DataAnnotations;

namespace AdvancedProgrammingProjectsServer.Models {

    public class Rating {

        public int Id { get; set; }

        [Required(ErrorMessage = "You must rate in order to submit your review")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Stars { get; set; }

        [StringLength(1000, ErrorMessage = "Review must not exceed 1000 characters")]
        public string? Feedback { get; set; }

        [Required(ErrorMessage = "You must input a name in order to submit your review")]
        [StringLength(100, ErrorMessage = "Name must not exceed 100 characters")]
        public string? Name { get; set; }

        [Required]
        [Display(Name="Time submitted")]
        public DateTime TimeSubmitted { get; set; }
    }
}
