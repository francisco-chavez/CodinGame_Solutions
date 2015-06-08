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
		int C = int.Parse(Console.ReadLine());

		List<int> budgets = new List<int>(N);
		int totalBudget = 0;
		for (int i = 0; i < N; i++)
		{
			int B = int.Parse(Console.ReadLine());
			budgets.Add(B);
			totalBudget += B;
		}

		if (C > totalBudget)
		{
			Console.WriteLine("IMPOSSIBLE");
			return;
		}

		budgets.Sort();
		double average = ((double) C) / N;
		int amountPayed = 0;

		List<int> payments = new List<int>(N);
		for (int i = 0; i < N; i++)
		{
			if (budgets[i] < average)
			{
				amountPayed += budgets[i];
				payments.Add(budgets[i]);

				average = ((double) (C - amountPayed)) / (N - (i + 1));
			}
			else
			{
				amountPayed += (int) average;
				payments.Add((int) average);
			}
		}

		while (amountPayed < C)
		{
			for (int i = N - 1; i >= 0 && amountPayed < C; i--)
			{
				if (payments[i] == budgets[i])
					break;

				amountPayed++;
				payments[i] += 1;
			}
		}

		for (int i = 0; i < N; i++)
		{
			Console.WriteLine(payments[i]);
		}
	}
}
