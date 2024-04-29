using Humanizer;
using Microsoft.Extensions.Logging;
using Moq;
using System.ComponentModel.Design;
using Xunit;

namespace StringManipulation.Test
{
    public class StringManipulationTests
    {
        /// <summary>
        /// // Tests for the first option of menu.
        /// </summary>
        [Fact]
        public void ConcatenateStrings_Test_1_Equal()
        {
            // Arrange
            StringOperations StringsFunctions = new StringOperations();
            string input_1 = "xUnit";
            string input_2 = "Tests";
            string expectedResult = "xUnit Tests";

            // Act
            string ResultOfFunction = StringsFunctions.ConcatenateStrings(input_1, input_2);

            // Assert
            Assert.Equal(expectedResult, ResultOfFunction);
        }

        [Fact(Skip = "This unit tests is not required")]
        public void ConcatenateStrings_Test_2_True()
        {

            // Arrange
            string input_1 = "";
            string input_2 = "";

            // Assert
            Assert.True(string.IsNullOrEmpty(input_1) ? string.IsNullOrEmpty(input_2) : false);
        }


        /// <summary>
        /// // Tests for the second option of menu.
        /// </summary>
        [Fact]
        public void ReverseString_Test_1_Equal()
        {
            // Arrange
            StringOperations StringsFunctions = new StringOperations();
            string input_1 = "Tests";
            string expectedResult = "stseT";

            // Act
            string ResultOfFunction = StringsFunctions.ReverseString(input_1);

            // Assert
            Assert.Equal(expectedResult, ResultOfFunction);
        }


        [Fact]
        public void ReverseString_Test_2_NotNull()
        {
            // Arrange
            string input_1 = "";

            // Assert
            Assert.NotNull(input_1);
        }

        /// <summary>
        /// // Tests for the third option of menu.
        /// </summary>

        [Fact]
        public void GetStringLength_Test_1_Equal()
        {
            // Arrange
            StringOperations StringsFunctions = new StringOperations();
            string input_1 = "Tests";
            int expectedResult = 5;

            // Act
            int ResultOfFunction = StringsFunctions.GetStringLength(input_1);

            // Assert
            Assert.Equal(expectedResult, ResultOfFunction);
        }

        [Fact]
        public void GetStringLength_Test_2_Exception()
        {
            //Arrange
            StringOperations StringsFunctions = new StringOperations();

            // Assert
            Assert.Throws<ArgumentNullException>(() => StringsFunctions.GetStringLength(null));
        }


        /// <summary>
        /// // Tests for the fourth option of menu.
        /// </summary>
        [Fact]
        public void RemoveWhitespace_Test_1_Equal()
        {

            // Arrange
            StringOperations StringsFunctions = new StringOperations();
            string input_1 = "Tests xUnit";
            string expectedResult = "TestsxUnit";

            // Act
            string ResultOfFunction = StringsFunctions.RemoveWhitespace(input_1);

            // Assert
            Assert.Equal(expectedResult, ResultOfFunction);
        }


        /// <summary>
        /// Tests for the fifth option of menu.
        /// </summary>
        [Theory]
        [InlineData("Testing", 5, "Testi")]
        [InlineData("Testing", 10, "Testing")]
        public void TruncateString_Test_1_Equal(string str, int maxlength, string expected)
        {
            // Arrange
            StringOperations StringsFunctions = new StringOperations();
            // Act
            string ResultOfFunction = StringsFunctions.TruncateString(str, maxlength);

            // Assert
            Assert.Equal(expected, ResultOfFunction);
        }

        [Fact]
        public void TruncateString_Test_2_Exception()
        {
            // Arrange
            StringOperations StringsFunctions = new StringOperations();
            string input_1 = "Testing";

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => StringsFunctions.TruncateString(input_1, -1));
        }



        /// <summary>
        /// Tests for the sixth option of menu
        /// 
        /// Esta funci�n no esta elaborada correctamente, ya que solo debe tomar una palabra y mediante esta determinar 
        /// si la palabra palindroma o no.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("amar rama", true)]
        [InlineData("No is palindrome", false)]
        [InlineData("amar", false)]
        public void IsPalindrome_Test_1_Equal(string str, bool expected)
        {
            // Arrange
            StringOperations StringsFunctions = new StringOperations();

            // Act
            bool ResultOfFunction = StringsFunctions.IsPalindrome(str);

            // Assert
            Assert.Equal(expected, ResultOfFunction);
        }

        /// <summary>
        /// Tests for the seventh option of menu
        /// 
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="expected"></param>

        [Theory]
        [InlineData("Hola mundo", 'o', 2)]
        [InlineData("Testing para p�ginas web", 'a', 3)]
        public void CountOccurrences_Test_1_Equal(string str, char chr, int expect)
        {
            // Arrange
            var mockServiceLogger = new Mock<ILogger<StringOperations>>();
            StringOperations StringsFunctions = new StringOperations(mockServiceLogger.Object);

            // Act
            int ResultOfFunction = StringsFunctions.CountOccurrences(str, chr);

            // Assert
            Assert.Equal(expect, ResultOfFunction);

        }


        /// <summary>
        /// Tests for the eighth option of menu
        /// 
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="expected"></param>

        [Theory]
        [InlineData("Hola mundo", "Hola mundos")]
        [InlineData("Testing para p�ginas web", "Testing para p�ginas webs")]
        public void Pluralize_Test_1_Equal(string str, string expect)
        {
            // Arrange
            StringOperations StringsFunctions = new StringOperations();

            // Act
            string ResultOfFunction = StringsFunctions.Pluralize(str);

            // Assert
            Assert.Equal(expect, ResultOfFunction);

        }


        /// <summary>
        /// Tests for the nineth option of menu
        /// 
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="expected"></param>

        [Theory]
        [InlineData("Hola mundo", 10, "diez Hola mundos")]
        [InlineData("Testing para p�ginas web", 3, "tres Testing para p�ginas webs")]
        public void QuantityInWords_Test_1_Equal(string str, int quantity, string expect)
        {
            // Arrange
            StringOperations StringsFunctions = new StringOperations();

            // Act
            string ResultOfFunction = StringsFunctions.QuantintyInWords(str, quantity);

            // Assert
            Assert.Equal(expect, ResultOfFunction);
        }

        /// <summary>
        /// Tests for the tenth option of menu
        /// </summary>
        [Fact]
        public void FromRomanToNumber_Test_1_Equal()
        {
            //Arrange
            StringOperations StringsFunctions = new StringOperations();
            string input = "M";
            int expected = 1000;
            //Act
            int ResultOfFunction = StringsFunctions.FromRomanToNumber(input);

            //Assert
            Assert.Equal(expected, ResultOfFunction);
        }


        [Fact]
        public void FromRomanToNumber_Test_2_Exception()
        {
            //Arrange
            StringOperations StringsFunctions = new StringOperations();
            string input = "A";

            //Act
            Assert.Throws<ArgumentException>(() => StringsFunctions.FromRomanToNumber(input));
        }

        /// <summary>
        /// Tests for the eleventh option of menu
        /// </summary>

        [Fact]
        public void ReadFile_Test_1_Equal() 
        {
            //Arrange
            StringOperations StringsFunctions = new StringOperations();
            IFileReaderConector fileReader = new FileReaderConector();
            string file = "information.txt";
            string expected = "This is an information example";

            //Act
            string resultOfFunction = StringsFunctions.ReadFile(fileReader, file);

            //Assert
            Assert.Equal(expected, resultOfFunction);
        }

        [Fact]
        public void ReadFile_Test_2_exception()
        {
            //Arrange
            StringOperations StringsFunctions = new StringOperations();
            IFileReaderConector fileReader = new FileReaderConector();
            string file = "informaion.txt";

            //Act
            //Assert
            Assert.Throws<FileNotFoundException>(() => StringsFunctions.ReadFile(fileReader,file));
        }





    }
}