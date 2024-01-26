using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrariesStage01.Interface
{
    public interface IDatabaseRepository
    {
        string GetOutputFromEntity();

        string GetOutputFromAdo();

        List<string> FindPalindromes(string input);

        bool IsPalindrome(string s);
    }
}
