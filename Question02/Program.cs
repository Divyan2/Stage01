using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using LibrariesStage01.DBContext;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Question02
{
    public class Program
    {
        private readonly Q2DbContext _context;
        private readonly int ApplicationId = 2;
        public Program()
        {
            _context = new Q2DbContext();
        }

        public Program(Q2DbContext context)
        {
            _context = context;
        }
        static void Main(string[] args)
        {
            string output;
            string input;
            do
            {
                Console.WriteLine("Enter the input string:");
                input = Console.ReadLine();
                output = GetLongestAlphabeticWord(input);

                if (string.IsNullOrEmpty(output))
                {
                    Console.WriteLine("No valid word starting with a capital letter found. Please try again.");
                }

            } while (string.IsNullOrEmpty(output));



            Program program = new Program();
            program.SaveToDatabase(input, output);

            Console.WriteLine("Output: " + output);
            Console.ReadLine();
        }

        static string GetLongestAlphabeticWord(string input)
        {
            string[] words = Regex.Split(input, @"[^a-zA-Z]+");

            string longestWord = "";
            foreach (string word in words)
            {
                if (IsAlphabetic(word) && word.Length > longestWord.Length && char.IsUpper(word[0])) //validation for considering string starting from Capital letter
                {
                    longestWord = word;
                }
            }

            return longestWord;
        }

        static bool IsAlphabetic(string input)
        {
            foreach (char c in input)
            {
                if (!Char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        public void SaveToDatabase(string input, string output)
        {
            string connectionString = _context.Database.Connection.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO tblLogic (InputValue, OutputValue,ApplicationId) VALUES (@input, @output, @applicationId)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@input", input);
                    command.Parameters.AddWithValue("@output", output);
                    command.Parameters.AddWithValue("@applicationId", ApplicationId);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

