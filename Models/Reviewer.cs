using System;
using System.ComponentModel.DataAnnotations;


namespace Restauranter.Models

{
    public class Reviewer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter between 3 and 255 characters")]
        [MinLength(3),MaxLength(45)]
        public string user { get; set; }

        [Required(ErrorMessage = "Please enter between 10 and 255 characters")]
        [MinLength(3),MaxLength(45)]
        public string restaurant { get; set; }

        [Required(ErrorMessage = "Please enter between 10 and 255 characters")]
        [MinLength(10),MaxLength(255)]
        public string rev_desc { get; set; }


        public int stars { get; set; }

        [Required]
        public DateTime visit { get; set; }
    }
}