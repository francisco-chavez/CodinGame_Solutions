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
		int N = int.Parse(Console.ReadLine());
		List<int> strengths = new List<int>(N);
		for (int i = 0; i < N; i++)
		{
			int Pi = int.Parse(Console.ReadLine());
			strengths.Add(Pi);
		}
		strengths.Sort();
		int deltaMin = strengths[1] - strengths[0];
		for (int i = 2; i < strengths.Count; i++)
		{
			var delta = strengths[i] - strengths[i - 1];
			deltaMin = Math.Min(deltaMin, delta);
		}

		// Write an action using Console.WriteLine()
		// To debug: Console.Error.WriteLine("Debug messages...");

		Console.WriteLine(deltaMin);
	}
}
