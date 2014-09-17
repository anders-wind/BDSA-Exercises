using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using NUnit.Framework;


namespace TextFileReaderProject
{
    /// <summary>
    ///     A utility class that allows the user to search for a single keyword in the text, and then print it in the terminal
    /// </summary>
    class TextSearcher
    {
        public static void Main(string[] args)
        {
            try
            {
                new TextSearcher(args[0]);
            }
            catch (Exception)
            {
                new TextSearcher("");
            }
            
        }

        /// <summary>
        /// The constructor tries to load the textfile 'inputfile' in the debug folder
        /// If inputfile is invalid the default text file 'TestFile.txt' will be loaded.
        /// While running, the user can enter new keywords to search for.
        /// Commands: + between two words, * prefix, * suffix.
        /// </summary>
        /// <param name="inputFile">The text file the class will print and search for keywords in</param>
        public TextSearcher(string inputFile)
        {
            string content = "";
            try
            {
                content = TextFileReader.ReadFile(inputFile) + "\n\n";
            }
            catch (Exception)
            {
                Console.WriteLine("\nCould not load file, therefore the default file is loaded.\nPress any key...");
                content = "\n" + TextFileReader.ReadFile("TestFile.txt") + "\n\n";
                Console.ReadKey();
            }

            print(content, "");

            while (true)
            {
                Console.WriteLine("\n\nCommands: \t+ between two words\n\t\t* prefix\n\t\t* suffix");
                Console.WriteLine("\n> type the string you want to search for and hit enter.");
                string keyword = Console.ReadLine();
                print(content, createRegex(keyword));
            }
        }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public TextSearcher()
        {
            
        }
        
        /// <summary>
        /// Generates a regular expression string based on the user input. Three different commands are available, but there can only be one command pr. regular expression.
        /// Commands: + between two words, * prefix, * suffix.
        /// + means that two adjacent keywords should be present one after the other, e.g. text + file matches “text file” but does not match “text big file”
        /// * after a keyword means search for words starting with keyword e.g. inter* matches “internet”
        /// * before a keyword means search for words ending with keyword e.g. *net matches “internet” and “intranet”
        /// </summary>
        /// <param name="input">The keyword the user searches after</param>
        /// <returns>A regular expression string created from the user input</returns>
        public string createRegex(string input)
        {
            Match match = Regex.Match(input, @" \+ ");
            if (match.Success)
            {
                return input.Substring(0, match.Index) + " " + input.Substring(match.Index+match.Length);
            }
            match = Regex.Match(input, @"\*{1}\w+");
            if (match.Success)
            {
                return @"\w*" + input.Substring(match.Index + 1);
            }
            match = Regex.Match(input, @"\w+\*{1}");
            if (match.Success)
            {
                return input.Substring(0, match.Index + match.Length - 1) + @"\w*";
            }
            return input;
        }

        /// <summary>
        /// Finds matches for URL, DATES and KEYWORD matches. 
        /// Prints URLS with blue font
        /// Prints DATES with green font
        /// Prints KEYWORDS with yellow background.
        /// Cannor handle multiple formattions eg. url and keyword matches.
        /// </summary>
        /// <param name="content">The text that needs to be printed</param>
        /// <param name="keyword">The search keyword in a regular expression format</param>
        public void print(string content, string keyword)
        {
            MatchCollection matchesKeywords = null;
            if (keyword != null || !keyword.Equals(""))
            {
                matchesKeywords = Regex.Matches(content, keyword, RegexOptions.IgnoreCase);
            }

            MatchCollection matchesURLs = Regex.Matches(content, @"http(s)?:\/\/([\w\d~\-\?\=]+(\.|\/){0,1})+", RegexOptions.IgnoreCase);
            MatchCollection matchesDates = Regex.Matches(content, @"(\w){3}, (\d){2} (\w){3} (\d){4} (\d){2}:(\d){2}:(\d){2} -?(\d){4}", RegexOptions.IgnoreCase);

            #region Put all MatchCollections into a List<Match> and sort
            Match[] keyWords = new Match[matchesKeywords.Count];
            matchesKeywords.CopyTo(keyWords, 0);
            Match[] urls = new Match[matchesURLs.Count];
            matchesURLs.CopyTo(urls, 0);
            Match[] dates = new Match[matchesDates.Count];
            matchesDates.CopyTo(dates, 0);
            List<Match> keywordsList = keyWords.ToList();
            List<Match> urlsList = urls.ToList();
            List<Match> datesList = dates.ToList();

            List<Match> sortedMatches = new List<Match>();
            sortedMatches.AddRange(keywordsList);
            sortedMatches.AddRange(urlsList);
            sortedMatches.AddRange(datesList);
            sortedMatches.Sort(Comparison);
            #endregion

            //OLD IMPLEMENTATION - Faster but cannot take two formattings at the same time.
            int currentIndex = 0;
            foreach (Match match in sortedMatches)
            {
                if (match.Success && match.Index > currentIndex)
                {
                    Console.Write(content.Substring(currentIndex, match.Index - currentIndex));
                    if (datesList.Contains(match))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(match.ToString());
                    }
                    else if (urlsList.Contains(match))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(match.ToString());
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(match.ToString());
                    }
                    Console.ResetColor();
                    currentIndex = match.Index + match.Length;
                }
            }
            Console.Write(content.Substring(currentIndex));


            //// new implementation - probably slower but can handle two formattings at a time
            //for (int i = 0; i < content.Length; i++)
            //{
            //    foreach (Match match in sortedMatches)
            //    {
            //        if (match.Index <= i && match.Index + match.Length > i)
            //        {
            //            if (datesList.Contains(match))
            //            {
            //                Console.ForegroundColor = ConsoleColor.Green;
            //            }
            //            else if (urlsList.Contains(match))
            //            {
            //                Console.ForegroundColor = ConsoleColor.Blue;
            //            }
            //            else
            //            {
            //                Console.BackgroundColor = ConsoleColor.Yellow;
            //            }
            //        }
            //    }
            //    Console.Write(content.Substring(i, 1));
            //    Console.ResetColor();
            //}
        }

        /// <summary>
        /// A comparator method which compares two match objects on their Index
        /// </summary>
        /// <param name="match"></param>
        /// <param name="match1"></param>
        /// <returns>1 if match's index is smaller than match1's\n1 if match's index is larger than match1's \n0 if they are equal</returns>
        private static int Comparison(Match match, Match match1)
        {
            if (match.Index < match1.Index) return -1;
            if (match.Index > match1.Index) return 1;
            return 0;
        }
    }
}