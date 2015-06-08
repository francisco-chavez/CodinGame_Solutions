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
		int R = int.Parse(Console.ReadLine());	// The number on line 1
		int L = int.Parse(Console.ReadLine());	// The line we want to read

		List<int> previousLine = null;
		List<int> currentLine = new List<int>();
		currentLine.Add(R);
		for (int i = 2; i <= L; i++)
		{
			previousLine = currentLine;
			currentLine = new List<int>();

			int currentNumber = previousLine[0];
			int currentCount = 0;
			for (int j = 0; j < previousLine.Count; j++)
			{
				if (currentNumber == previousLine[j])
				{
					currentCount++;
				}
				else
				{
					currentLine.Add(currentCount);
					currentLine.Add(currentNumber);
					currentNumber = previousLine[j];
					currentCount = 1;
				}


			}

			currentLine.Add(currentCount);
			currentLine.Add(currentNumber);
		}

		for (int i = 0; i < currentLine.Count; i++)
		{
			Console.Write(currentLine[i]);
			if (i < currentLine.Count - 1)
				Console.Write(" ");
			else
				Console.WriteLine();
		}

		// Write an action using Console.WriteLine()
		// To debug: Console.Error.WriteLine("Debug messages...");

		//Console.WriteLine("answer");
	}
}
