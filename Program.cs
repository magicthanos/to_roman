public static class Program
{
  public static void Main()
  {
    Console.Write("Give number to convert: ");
    int numToConvert = int.Parse(Console.ReadLine());
    Console.WriteLine($"{numToConvert} to Roman : {numToConvert.ToRoman()}");
  }
}

public static class RomanNumeralExtension
{
  public static string ToRoman(this int value)
  {
    //the function can convert numbers from 0 to 4999

    string romanNumeral = "";
    while (value != 0)
    {
      int div = (int)Math.Pow(10, value.ToString().Length - 1); //used to "divide" the number in units

      int numToAdd = (int)(value / div) * div; //floor to nearest 10th
      value -= numToAdd; //subtracts the previous number

      romanNumeral += numToAdd.ToRomanChars();
    }
    return romanNumeral;
  }

  private static string ToRomanChars(this int value) =>

      //calculates the specific characters and their length based on roman numeral rules

      value switch
      {
        <= 0 or >= 5000 => throw new ArgumentOutOfRangeException(nameof(value)),
        >= 1000 => new string('M', value / 1000),
        900 => "CM",
        >= 500 => "D" + new string('C', (value - 500) / 100),
        400 => "CD",
        >= 100 => new string('C', value / 100),
        90 => "XC",
        >= 50 => "L" + new string('X', (value - 50) / 10),
        40 => "XL",
        >= 10 => new string('X', value / 10),
        9 => "IX",
        >= 5 => "V" + new string('I', value - 5),
        4 => "IV",
        >= 1 => new string('I', value)
      };
}