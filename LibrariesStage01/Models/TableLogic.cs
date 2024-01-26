using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesStage01.Models
{
    [Table("tblLogic")]
    public class TableLogic
    {
        [Key]
        public int ID { get; set; }

        [MaxLength]
        public string InputValue { get; set; }

        [MaxLength]
        public string OutputValue { get; set; }

        public int ApplicationId { get; set; }
    }
}
