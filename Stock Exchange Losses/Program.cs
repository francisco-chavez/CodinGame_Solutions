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
		int n = int.Parse(Console.ReadLine());
		string vs = Console.ReadLine();
		string[] stockStrings = vs.Split();
		int[] stocks = new int[n];

		int size = n;
		int buy = 0;
		int sell = 0;

		int min = 0;
		int maxDiff = 0;


		for (int i = 0; i < size; i++)
		{
			stocks[i] = int.Parse(stockStrings[i]);
			if (stocks[i] > stocks[min])
				min = i;

			int diff = stocks[i] - stocks[min];

			if (diff < maxDiff)
			{
				buy = min;
				sell = i;
				maxDiff = diff;
			}
		}

		if (maxDiff > 0)
			maxDiff = 0;

		// Write an action using Console.WriteLine()
		// To debug: Console.Error.WriteLine("Debug messages...");

		Console.WriteLine(maxDiff);
	}
}
