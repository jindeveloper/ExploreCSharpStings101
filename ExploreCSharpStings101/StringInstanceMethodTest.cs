using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ExploreCSharpStings101
{
    public static class StringExtension
    {
        public static string ReplaceIndexWith(this string value, int index, string replacement)
        {
            string result = value;

            result = value.Insert((index + 1), replacement);
            result = result.Remove(index, 1);

            return result;
        }

        public static bool IsAllUpper(this string value)
        {
            bool result = true;

            foreach (var item in value.ToCharArray())
            {
                if (!Char.IsUpper(item))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public static bool IsAllLower(this string value)
        {
            bool result = true;

            foreach (var item in value.ToCharArray())
            {
                if (!Char.IsLower(item))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }
    }

    [TestClass]
    public class StringInstanceMethodTest
    {
        #region Define A String

        [TestMethod]
        public void Test_String_Define_New_String()
        {
            char[] characterCollection = new char[] { 'i', 'l','o','v', 'e','c','s','h','a','r','p' };

            string statement = new string(characterCollection);

            string newStatement = "ilovecsharp";

            Assert.AreEqual(statement, newStatement);
        }

        [TestMethod]
        public void Test_String_Define_New_String_Via_Console_ReadLine()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                Console.WriteLine("What is your favorite language?");

                using (var reader = new StringReader("C# language"))
                {
                    Console.SetIn(reader);

                    string fromInput = reader.ReadLine();

                    Console.WriteLine($"Your favorite programming language is {fromInput}");

                    string totalWrite = writer.ToString();

                    string assumption = $"What is your favorite language?{Environment.NewLine}Your favorite programming language is {fromInput}{Environment.NewLine}";

                    Assert.IsTrue(totalWrite.Equals(assumption));
                }
            }
        }

        #region Strings are arrays of characters
        [TestMethod]
        public void Test_String_To_Get_Character_At_Specified_Position()
        {
            string newCountry = "";

            string country = "Philippines";

            for (int i = 0; i < country.Length; i++)
            {
                newCountry += country[i];
            }

            Assert.AreEqual(newCountry, country);
        }
        #endregion

        #endregion

        #region String Instance Methods

        #region Other Methods Not Used Much 

        [TestMethod]
        public void Test_String_Clone_Method()
        {
            string toBeCloned = "CSharp Rocks";

            string newString = toBeCloned.Clone().ToString();

            Assert.IsTrue(toBeCloned == newString);
        }

        #endregion 

        #region Equality 

        #region CompareTo Method 

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_String_CompareTo_Method_Throws_ArgumentException()
        {
            int birthMonth = 3;

            string statement = "CSharp Rocks";

            statement.CompareTo(birthMonth);

            //throws an argumentexception whenever you are comparting string to non-string type.
        }

        [TestMethod]
        public void Test_String_CompareTo()
        {
            string[] programmingLanguages = new string[] { "C", "C++", "C#", "Java", "Python", null };

            string favoriteLanguage = "C#";

            foreach (var item in programmingLanguages)
            {
                //compares in a default settings for string comparison. 

                int result = favoriteLanguage.CompareTo(item);

                switch (result)
                {
                    case -1:
                        Console.WriteLine($"Is {item} your favorite language?");
                        break;
                    case 0:
                        Console.WriteLine("The comparison are equal");
                        Console.WriteLine($"You got it. My favorite language is {item}");
                        break;
                    case 1:
                        Console.WriteLine($"Is {(item == null ? "null" : item)} your favorite language?");
                        break;
                }

                Assert.IsTrue((result >= -1 & result <= 1));
            }
        }

        #endregion

        #region Equals Method 

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Test_String_Equals_Method_Throws_NullReferenceException()
        {
            string laptop = null;

            laptop.Equals("DELL");
        }

        [TestMethod]
        public void Test_String_Equals_Method()
        {
            string[] countries = new string[] { "Philippines", "PHILIPPINES", "philippines", "USA", "usa", "Korea", "KOREA" };

            string country = "Philippines";

            foreach (var item in countries)
            {
                if (country.Equals(item))   
                {
                    Console.WriteLine($"{item} is equals {country}");
                }
                else
                {
                    if (country.Equals(item, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"{item} is equals {country} case being ignored");
                    }
                }
            }
        }

        #endregion 

        #endregion

        #region String characters cases (lower or UPPER) 

        [TestMethod]
        public void Test_String_ToUpper()
        {
            string statement = "developers like to code people like to talk";

            statement.ToUpper(); //i didn't assign the result to any variable

            foreach (var item in statement.ToCharArray())
            {
                if (char.IsLower(item) & !char.IsWhiteSpace(item))
                {
                    Console.WriteLine($"{item} is not in upper-case");
                    Assert.IsTrue(char.IsLower(item));
                    Assert.IsTrue(!char.IsWhiteSpace(item));
                }
            }

            string resultStatementToUpper = statement.ToUpper(); //assigned the result to a variable

            foreach (var item in statement.ToCharArray())
            {
                if (char.IsUpper(item) & !char.IsWhiteSpace(item))
                {
                    Console.WriteLine($"{item} is in upper-case");
                    Assert.IsTrue(char.IsUpper(item));
                    Assert.IsTrue(!char.IsWhiteSpace(item));
                }
            }
        }

        [TestMethod]
        public void Test_String_ToLower()
        {
            string statement = "DEVELOPERS LIKE TO CODE PEOPLE LIKE TO TALK";

            statement.ToLower();

            foreach (var item in statement.ToCharArray())
            { 
                if (char.IsUpper(item) & !char.IsWhiteSpace(item))
                {
                    Console.WriteLine($"{item} is not in upper-case");
                    Assert.IsTrue(char.IsUpper(item));
                    Assert.IsTrue(!char.IsWhiteSpace(item));
                }
            }

            string resultStatementToLower = statement.ToLower();

            foreach (var item in statement.ToCharArray())
            {
                if (char.IsLower(item) & !char.IsWhiteSpace(item))
                {
                    Console.WriteLine($"{item} is in upper-case");
                    Assert.IsTrue(char.IsLower(item));
                    Assert.IsTrue(!char.IsWhiteSpace(item));
                }
            }
        }

        #endregion

        #region StartsWith and EndsWith Method

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_String_EndsWith_Throws_ArgumentNullException()
        {
            string statement = "I didn't end with null";

            statement.EndsWith(null);
        }

        [TestMethod]
        public void Test_String_EndsWith_Using_Default_StringComparison()
        {
            string[] vowels = new string[] { "a", "e", "i", "o", "u" };

            string statement = "I love .NET Framework. How about you";

            foreach (var item in vowels)
            {
                var result=  statement.EndsWith(item);

                Assert.IsInstanceOfType(result, typeof(bool));
            }
        }


        [TestMethod]
        public void Test_String_EndsWith_Passing_Different_StringComparison()
        {
            string[] vowels = new string[] { "a", "e", "i", "o", "u" };

            string statement = "I love .NET Framework. How about you".ToUpper();

            foreach (var item in vowels)
            {
                var result = statement.EndsWith(item, StringComparison.CurrentCultureIgnoreCase);

                if (result) Console.WriteLine($"Yes it ends with {item}");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_String_StartsWith_Method_Throws_ArgumentNullException()
        {
            string myParagraph = "Introduction to C# programmIng.";

            myParagraph.StartsWith(null);

        }

        [TestMethod]
        public void Test_String_StartsWith_Method()
        {
            string myParagraph = "Introduction to C# programmIng.";

            string[] startsWithTheWord = new string[] { "Introduction", "introduction" };

            foreach (var word in startsWithTheWord)
            {
                var result = myParagraph.StartsWith(word);

                Assert.IsInstanceOfType(result, typeof(bool));

                var resultIgnoredCase = myParagraph.StartsWith(word, StringComparison.OrdinalIgnoreCase);

                Assert.IsInstanceOfType(resultIgnoredCase, typeof(bool));
            }
        }


        #endregion

        #region Getting element index of a string 

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_String_IndexOf_Method_Throws_Argument_Exception()
        {
            string myParagraph = "Introduction to C# programmIng.";

            int length = myParagraph.Length;

            int index = -1;

            index = myParagraph.IndexOf('a', (length + 1));

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test_String_LastIndexOf_Method_Throws_Argument_Exception()
        {
            string myParagraph = "Introduction to C# programmIng.";

            int length = myParagraph.Length;

            int index = -1;

            index = myParagraph.LastIndexOf('I', (length + 1));

        }

        [TestMethod]
        public void Test_String_IndexOf_And_LastIndexOf_Method()
        {
            string[] vowels = new string[] { "a", "e", "i", "o", "u" };

            string[] vowelsUpper = new string[] { "A", "E", "I", "O", "U" };

            string myParagraph = "Introduction to C# programmIng.";

            int index = -1;

            foreach (var item in vowels)
            {
                index = myParagraph.IndexOf(item);

                if (index != -1)
                {
                    string result = myParagraph.ReplaceIndexWith(index, item.ToUpper());

                    Console.WriteLine(result);
                }
            }

            foreach (var item in vowelsUpper)
            {
                index = myParagraph.LastIndexOf(item);

                if (index != -1)
                {
                    string result = myParagraph.ReplaceIndexWith(index, item.ToLower());

                    Console.WriteLine(result);
                }
            }
        }




        #endregion

        #region Trimming String Characters/Elements

        [TestMethod]
        public void Test_String_TrimStart()
        {
            string paragraph = "     Hello World  ";

            string trimTheHead = paragraph.TrimStart();
            Assert.IsTrue(trimTheHead == "Hello World  ");

            string trimTheTail = paragraph.TrimEnd();
            Assert.IsTrue(trimTheTail == "     Hello World");

            string trimHeadAndTail = paragraph.Trim();
            Assert.IsTrue(trimHeadAndTail == "Hello World");
        }

        #endregion

        #region Replace And Contains 

        [TestMethod]
        public void Test_String_Replace_And_Contains()
        {
            string[] heroes = new string[] { "Batman", "Superman", "Robin" };

            foreach (var item in heroes)
            {
                if (item.Contains("n"))
                {
                    string newHeroName = item.Replace("n", "x");

                    Assert.IsTrue(newHeroName.Contains("x"));
                }
            }
        }

        #endregion

        #region Split

        [TestMethod]
        public void Test_String_Split_Method()
        {
            string countries = "Philippines,Korea,Japan,Indonesia,Australia";

            var arrayOfCountries = countries.Split(',');

            Assert.IsInstanceOfType(arrayOfCountries, typeof(string[]));
        }

        #endregion
        
        #endregion
    }
}
