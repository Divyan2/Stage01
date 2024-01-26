using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesStage01.Models
{
    public class Student
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        public string Lname { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Age must be greater than or equal to 1.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
