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
		int charWidth = int.Parse(Console.ReadLine());
		int charHeight = int.Parse(Console.ReadLine());
		string output = Console.ReadLine().ToUpper();

		string[] alphabetRows = new string[charHeight];
		for (int i = 0; i < charHeight; i++)
		{
			alphabetRows[i] = Console.ReadLine();
		}
		string T = Console.ReadLine();

		// Write an action using Console.WriteLine()
		// To debug: Console.Error.WriteLine("Debug messages...");
		int charIndexDelta = (int) 'A';
		Dictionary<char, int> charToIndexMap = new Dictionary<char, int>();
		for (int i = 0; i < 26; i++)
		{
			char key = (char) (i + charIndexDelta);
			charToIndexMap.Add(key, i);

		}


		for (int i = 0; i < charHeight; i++)
		{
			for (int j = 0; j < output.Length; j++)
			{
				if (charToIndexMap.ContainsKey(output[j]))
				{
					int alphaIndex = charToIndexMap[output[j]] * charWidth;
					Console.Write(alphabetRows[i].Substring(alphaIndex, charWidth));
				}
				else
				{
					Console.Write(alphabetRows[i].Substring(26 * charWidth, charWidth));
				}
			}
			Console.WriteLine();
		}
	}
}
