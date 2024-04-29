<h1 align="center"> :mortar_board:Pruebas unitarias - Testing 2024-1 Wednesday 2 at 4pm </h1>

## Índice
- [Objetivo del proyecto](#Objetivo-del-proyecto)
   
- [Explicación breve de las pruebas unitarias](#Explicacion-breve-de-las-pruebas-unitarias)
   
   - [Función 1 ConcatenateStrings](##Funcion-1-ConcatenateStrings)
  
   - [Función 2 ReverseString](##Funcion-2-ReverseString)
 
   - 

- [Bibliografía](#Bibliografía)

<h1 align="center"> :dart:Objetivo del proyecto </h1>

Este proyecto de pruebas se hizo con el fin de adquirir conocimientos acerca de como se hacen las pruebas unitarias en C# con xUnit, donde el proyecto toma 11 funciones que interactuan con strings la cuales entregan diferentes soluciones.

<h1 align="center">:left_right_arrow:Explicación breve de las pruebas unitarias</h1>

## Función 1 ConcatenateStrings

Se elaboró solamente una prueba unitaria ya que la función consistía en unir dos strings, como se sabe, los strings puede gaurdar cualquier carácter, asi que no había un error grande para este caso.
incluso, se hizo otra pureba unitaria, pero se skipea porque no se considera necesaria.

Adjunto código.

```csharp,

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


```

## Función 2 ReverseString

En ese caso, se agrego una prueba unitaria en caso de que no fuera null para que la validara. Esta prueba no tiene una gran validez ya que solo es hacer al revés una palabra o frase.

```csharp,

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

```

## Función 3 - GetStringLength

Esta función requirió una prueba de exception ya que no se puede enviar un argumento nulos.

```csharp,

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

```

## Función 4 - RemoveWhitespace

Esta función solamente se requirió hacer una prueba unitaria.

```csharp,

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

```

## Función 5 - TruncateString

Esta función solamente se requirió hacer una prueba unitaria.

```csharp,

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

```

## Función 6 - IsPalindrome_Test

Esta función no está elaborada correctamente, ya que solo debe tomar una palabra y mediante esta determinar si la palabra palindroma o no. Aquí se aplica nuevos atributos [Theory] e [InLineData].

El cual [Theory] hace entender que va a recibir varios datos de entrada con los cuales va a hacer las pruebas unitarias y [InLineData] llevará los datos que recibirá la prueba de entrada, junto a la respuesta esperada.

```csharp,

/// <summary>
/// Tests for the sixth option of menu
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

```

## Función 7 - CountOccurrences



```csharp,

[Theory]
[InlineData("Hola mundo", 'o', 2)]
[InlineData("Testing para páginas web", 'a', 3)]
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

```

## Función 8 - Pluralize



```csharp,

/// <summary>
/// Tests for the eighth option of menu
/// 
/// 
/// </summary>
/// <param name="str"></param>
/// <param name="expected"></param>

[Theory]
[InlineData("Hola mundo", "Hola mundos")]
[InlineData("Testing para páginas web", "Testing para páginas webs")]
public void Pluralize_Test_1_Equal(string str, string expect)
{
    // Arrange
    StringOperations StringsFunctions = new StringOperations();

    // Act
    string ResultOfFunction = StringsFunctions.Pluralize(str);

    // Assert
    Assert.Equal(expect, ResultOfFunction);

}

```

## Función 9 - QuantityInWords

```csharp,


        /// <summary>
        /// Tests for the nineth option of menu
        /// 
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="expected"></param>

        [Theory]
        [InlineData("Hola mundo", 10, "diez Hola mundos")]
        [InlineData("Testing para páginas web", 3, "tres Testing para páginas webs")]
        public void QuantityInWords_Test_1_Equal(string str, int quantity, string expect)
        {
            // Arrange
            StringOperations StringsFunctions = new StringOperations();

            // Act
            string ResultOfFunction = StringsFunctions.QuantintyInWords(str, quantity);

            // Assert
            Assert.Equal(expect, ResultOfFunction);

        }

```

## Función 10 - FromRomanToNumber

```csharp,

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
 public void FromRomanToNumbe_Test_2_Exception()
 {
     //Arrange
     StringOperations StringsFunctions = new StringOperations();
     string input = "A";

     //Act
     Assert.Throws<ArgumentException>(() => StringsFunctions.FromRomanToNumber(input));
 }

```

## Función 11 - ReadFile

```csharp,

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

```
<h1 align="center">:blue_book:Bibliografía</h1>

Las bases que se utilizaron para desarrollar el proyecto están en el siguiente [Github](https://github.com/yBetancurr4002/UnitTestingXUnit)


