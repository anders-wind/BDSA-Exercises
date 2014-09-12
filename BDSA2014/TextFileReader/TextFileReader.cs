using System;
using System.IO;
using System.Text.RegularExpressions;


namespace TextFileReader
{
    /// <summary>
    ///   Utility class for reading text files into a single string.
    /// </summary>
    static class TextFileReader
    {

        public static void Main()
        {
            string content = TextFileReader.ReadFile("TestFile.txt");

            string keyword = "to";
            keyword = keyword.ToLower();

            print(content, keyword);
        }


        static void print(string content, string keyword)
        {
            MatchCollection matches = Regex.Matches(content, keyword, RegexOptions.IgnoreCase);
            int currentIndex = 0;
            foreach(Match match in matches)
            {
                if (match.Success)
                {
                    Console.Write(content.Substring(currentIndex, match.Index));
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write(match.ToString());
                    Console.ResetColor();
                    currentIndex = match.Index + match.Length;
                }
            }
            Console.Write(content.Substring(currentIndex));
        }




        /// <summary>
        /// Reads a text file and returns its content as a string.
        /// </summary>
        /// <param name="filename">The file name to be read, including the path.</param>
        /// <returns>A string representing the content of the file</returns>
        public static string ReadFile(string filename)
        {
            try
            {
                using (var reader = new StreamReader(filename))
                {
                    //This reads the entire file
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                //Might happen if the file is not text or non-existent
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}