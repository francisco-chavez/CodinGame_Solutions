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
		int minX = int.MaxValue;
		int maxX = int.MinValue;
		List<int> sortedYValues = new List<int>(N);

		for (int i = 0; i < N; i++)
		{
			string[] inputs = Console.ReadLine().Split(' ');
			int X = int.Parse(inputs[0]);
			int Y = int.Parse(inputs[1]);

			minX = Math.Min(minX, X);
			maxX = Math.Max(maxX, X);

			sortedYValues.Add(Y);
		}
		sortedYValues.Sort();

		int deltaX = maxX - minX;
		long minDist = FindAbsDiff(sortedYValues, sortedYValues[N / 2]);

		if (N % 2 == 0)
		{
			int y2 = sortedYValues[(N / 2) - 1];
			long distContender = FindAbsDiff(sortedYValues, y2);
			minDist = Math.Min(minDist, distContender);
		}

		Console.WriteLine(deltaX + minDist);
	}

	static long FindAbsDiff(List<int> values, int pivit)
	{
		long result = 0;

		foreach (var val in values)
			result += Math.Abs(val - pivit);

		return result;
	}
}
