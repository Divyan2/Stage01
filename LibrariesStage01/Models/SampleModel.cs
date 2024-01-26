using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesStage01.Models
{
    public class SampleModel
    {
        public SampleModel()
        {
            
        }
        [Key]
        public int Id { get; set; }
        public string DatabaseVersion { get; set; }
    }
}
