using LibrariesStage01.DBContext;
using LibrariesStage01.Interface;
using LibrariesStage01.Models;
using Microsoft.Win32.SafeHandles;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibrariesStage01.Repository
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly DefaultDbContext _context; 

        //intializing dbcontext(default)
        public DatabaseRepository()
        {
            _context = new DefaultDbContext();
        }

        //intializing dbcontext when it is received as an argument.(parameterized)
        public DatabaseRepository(DefaultDbContext context)
        {
            _context = context;
        }

        public List<string> FindPalindromes(string input)
        {
            List<string> palindromes = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j <= input.Length; j++)
                {
                    string substring = input.Substring(i, j - i);
                    if (IsPalindrome(substring) && substring.Length > 2)
                    {
                        palindromes.Add(substring);
                    }
                }
            }

            return palindromes;
        }

        public string GetOutputFromAdo()
        {
            string version = "Unknown";
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using(SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT @@version";

                        version = (string)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                version = $"Error: {ex.Message}";
            }

            return version;
        }

        public string GetOutputFromEntity()
        {
            string version = "Unknown";
            try
            {
                var databaseVersion = _context.Database.SqlQuery<string>("Select @@version").FirstOrDefault();
                if (databaseVersion != null)
                {
                    version = databaseVersion.ToString();

                }
            }
            catch (Exception ex)
            {
                version = $"Error: {ex.Message}";
            }

            return version;
        }

        public bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }

                left++;
                right--;
            }

            return true;
        }


    }
}
