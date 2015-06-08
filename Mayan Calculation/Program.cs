using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
	static void Main(string[] args)
	{
		string[] inputs = Console.ReadLine().Split(' ');
		int digitWidth = int.Parse(inputs[0]);
		int digitHeight = int.Parse(inputs[1]);

		string[] rawDigits = new string[digitHeight];
		for (int i = 0; i < digitHeight; i++)
			rawDigits[i] = Console.ReadLine();

		int rawHeightA = int.Parse(Console.ReadLine());
		string[] numberARaw = new string[rawHeightA];
		for (int i = 0; i < rawHeightA; i++)
			numberARaw[i] = Console.ReadLine();

		int rawHeightB = int.Parse(Console.ReadLine());
		string[] numberBRaw = new string[rawHeightB];
		for (int i = 0; i < rawHeightB; i++)
			numberBRaw[i] = Console.ReadLine();

		string operation = Console.ReadLine();

		var intToDigitMap = FormatRawDigits(rawDigits, digitWidth, digitHeight);
		var digitToIntMap = new Dictionary<string, int>(20);

		for (int i = 0; i < 20; i++)
			digitToIntMap.Add(intToDigitMap[i], i);

		string[] numberADigits = ConcatRawNumber(numberARaw, digitHeight);
		string[] numberBDigits = ConcatRawNumber(numberBRaw, digitHeight);

		long a = ConvertNumber(numberADigits, digitToIntMap);
		long b = ConvertNumber(numberBDigits, digitToIntMap);

		Console.Error.WriteLine("Finished Converting Input");

		long c = 0;
		switch (operation)
		{
		case "+":
			c = a + b;
			break;

		case "-":
			c = a - b;
			break;

		case "*":
			c = a * b;
			break;

		case "/":
			c = a / b;
			break;
		}

		Console.Error.WriteLine("Starting to conver output");

		char[] base20IntToDigitMap = CreateBase20Map();
		Dictionary<char, int> base20DigitToIntMap = new Dictionary<char, int>(20);

		for (int i = 0; i < 20; i++)
			base20DigitToIntMap.Add(base20IntToDigitMap[i], i);

		Console.Error.WriteLine("Changing output to base 20");
		string base20C = ConvertToBase20(c, base20IntToDigitMap);

		Console.Error.WriteLine("Writing output");
		foreach (var b20Digit in base20C)
		{
			var digitB10Int = base20DigitToIntMap[b20Digit];
			var mayanDigit = intToDigitMap[digitB10Int];

			for (int h = 0; h < digitHeight; h++)
				Console.WriteLine(mayanDigit.Substring(h * digitWidth, digitWidth));
		}

		// Write an action using Console.WriteLine()
		// To debug: Console.Error.WriteLine("Debug messages...");
	}

	static string[] FormatRawDigits(string[] rawDigits, int digitWidth, int digitHeight)
	{
		string[] results = new string[20];

		for (int currentDigit = 0; currentDigit < 20; currentDigit++)
		{
			StringBuilder sb = new StringBuilder();

			for (int h = 0; h < digitHeight; h++)
				sb.Append(rawDigits[h].Substring(currentDigit * digitWidth, digitWidth));

			results[currentDigit] = sb.ToString();
		}

		return results;
	}

	static string[] ConcatRawNumber(string[] rawNumber, int digitHeight)
	{
		int digitCount = rawNumber.Length / digitHeight;
		string[] results = new string[digitCount];

		int currentLine = 0;
		for (int currentDigit = 0; currentDigit < digitCount; currentDigit++)
		{
			StringBuilder sb = new StringBuilder();
			for (int h = 0; h < digitHeight; h++)
				sb.Append(rawNumber[currentLine++]);

			results[currentDigit] = sb.ToString();
		}

		return results;
	}

	static long ConvertNumber(string[] numberDigits, Dictionary<string, int> digitToIntMap)
	{
		long result = 0;
		long digitLocMult = 1; // I'm also using this to caste the int into a long.

		for (int i = numberDigits.Length - 1; i >= 0; i--)
		{
			result += digitToIntMap[numberDigits[i]] * digitLocMult;
			digitLocMult *= 20;
		}

		return result;
	}

	static char[] CreateBase20Map()
	{
		///
		/// I had started this with a for loop to convert the i values into digit strings
		/// at base 20, but when I ran it I found out that the Convert.ToString(int value, int base)
		/// method only works with certain bases.
		/// -FCT
		/// 
		char[] result = new char[] 
		{ 
			'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' 
		};

		return result;
	}

	static string ConvertToBase20(long value, char[] base20Map)
	{
		if (value == 0)
			return "0";

		StringBuilder sb = new StringBuilder();
		long currentValue = value;
		while (currentValue != 0)
		{
			sb.Insert(0, base20Map[(int) (currentValue % 20)]);
			currentValue /= 20;
		}

		return sb.ToString();
	}
}
