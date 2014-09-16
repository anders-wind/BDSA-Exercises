using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
