using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Question03.Models
{
    public class PalindromeViewModel
    {
        public string InputString { get; set; }
        public List<string> Palindromes { get; set; }
        public List<TableLogicViewModel> StoredData { get; set; } 
    }
}