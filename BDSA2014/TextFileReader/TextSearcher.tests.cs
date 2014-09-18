using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TextFileReaderProject
{
    /// <summary>
    /// A testclass that tests the TestSearcher class' methods.
    /// </summary>
    [TestFixture]
    class TextSearcherTests
    {
        /// <summary>
        /// Test the CreateEgex method for empty input. 
        /// Expected "";
        /// </summary>
        [Test]
        public void TestCreateRegexEmptyInput()
        {
            TextSearcher ts = new TextSearcher();
            Assert.AreEqual("", ts.createRegex(""));
        }

        /// <summary>
        /// Tests the CreateRegex method for a few inputs which has multiple keywords or commands.
        /// </summary>
        [Test]
        public void TestCreateRegexTwoCommandsInput()
        {
            TextSearcher ts = new TextSearcher();
            Assert.AreEqual(@"\w*one", ts.createRegex("**one"));
            Assert.AreEqual(@"two\w*", ts.createRegex("two**"));
            Assert.AreEqual(@"\w*three*", ts.createRegex("*three*"));
            Assert.AreEqual(@"four ++ four", ts.createRegex("four ++ four"));
            Assert.AreEqual(@"five + five", ts.createRegex("five + + five"));
            Assert.AreEqual(@"six six", ts.createRegex("six six"));
        }

        /// <summary>
        /// Tests the CreateRegex method's ability to create plus command regex when input is correct.
        /// </summary>
        [Test]
        public void TestCreateRegexPlusCommand()
        {
            TextSearcher ts = new TextSearcher();
            Assert.AreEqual(@"hey you", ts.createRegex("hey + you"));
            Assert.AreEqual(@"hey you you", ts.createRegex("hey you + you"));
        }

        /// <summary>
        /// Tests the CreateRegex method's ability to create * prefix command regex when input is correct.
        /// </summary>
        [Test]
        public void TestCreateRegexStarPrefixCommand()
        {
            TextSearcher ts = new TextSearcher();
            Assert.AreEqual(@"\w*hey", ts.createRegex("*hey"));
            Assert.AreEqual(@"\w*hey you", ts.createRegex("*hey you"));
        }

        /// <summary>
        /// Tests the CreateRegex method's ability to create * suffix command regex when input is correct.
        /// </summary>
        [Test]
        public void TestCreateRegexStarSuffixCommand()
        {
            TextSearcher ts = new TextSearcher();
            Assert.AreEqual(@"hey\w*", ts.createRegex("hey*"));
            Assert.AreEqual(@"hey you\w*", ts.createRegex("hey you*"));
        }

        /// <summary>
        /// Tests the Regex which is supposed to find urls in a text.
        /// Only URLs starting with http(s):// are accepted.
        /// </summary>
        [Test]
        public void TestURLRegex()
        {
            TextSearcher ts = new TextSearcher();
            var content = new Stack<string>();
            var expected = new Stack<string>();
            content.Push("hey 1 2 you http://www.test.dk lol"); expected.Push("http://www.test.dk");
            content.Push("Heyya 2 http://www.test.dk/dada.htm 2 da"); expected.Push("http://www.test.dk/dada.htm");
            content.Push("tadadada asmdoasf www.e.dk asdau http://msdn.microsoft.com/en-us/library/aa288470.aspx lol"); expected.Push("http://msdn.microsoft.com/en-us/library/aa288470.aspx");
            content.Push("hej 1 2 dig https://www.test.dk lol"); expected.Push("https://www.test.dk");
            content.Push("hej 1 2 dig www.test.dk lol"); expected.Push("");

            while (content.Count != 0 && expected.Count != 0)
            {
                Match match = Regex.Match(content.Pop(), ts.urlRegex);
                Assert.AreEqual(expected.Pop(), match.ToString());
            }
        }


        /// <summary>
        /// Tests the Regex which is supposed to find dates in a text.
        /// The only date format that it supports is the one given in the TestFile.txt
        /// </summary>
        [Test]
        public void TestDateRegex()
        {
            TextSearcher ts = new TextSearcher();
            var content = new Stack<string>();
            var expected = new Stack<string>();
            content.Push("posted Sun, 26 Aug 2012 04:06:16 0400"); expected.Push("Sun, 26 Aug 2012 04:06:16 0400");
            content.Push("Heyya Sun, 26 Aug 2012 04:06:16 -9999 2 da"); expected.Push("Sun, 26 Aug 2012 04:06:16 -9999");
            content.Push("tadadada 2 Sun, 26 Aug 2012 04:06:16 -0400 2"); expected.Push("Sun, 26 Aug 2012 04:06:16 -0400");
            content.Push("Sun, 26 Aug 2012 04:06:16"); expected.Push("Sun, 26 Aug 2012 04:06:16");
            content.Push("lol Sun, 26 Aug 2012 lol"); expected.Push("Sun, 26 Aug 2012");

            while (content.Count != 0 && expected.Count != 0)
            {
                Match match = Regex.Match(content.Pop(), ts.dateRegex);
                Assert.AreEqual(expected.Pop(), match.ToString());
            }
        }


    }
}
