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
class Player
{
	static void Main(string[] args)
	{
		string[] inputs;
		inputs = Console.ReadLine().Split(' ');
		int W = int.Parse(inputs[0]); // number of columns.
		int H = int.Parse(inputs[1]); // number of rows.

		int[,] dungen = new int[H, W];
		for (int i = 0; i < H; i++)
		{
			string LINE = Console.ReadLine(); // represents a line in the grid and contains W integers. Each integer represents one room of a given type.
			string[] row = LINE.Split();
			for (int j = 0; j < W; j++)
			{
				dungen[i, j] = int.Parse(row[j]);
			}
		}
		int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit (not useful for this first mission, but must be read).

		// game loop
		while (true)
		{
			inputs = Console.ReadLine().Split(' ');
			int XI = int.Parse(inputs[0]);
			int YI = int.Parse(inputs[1]);
			string POS = inputs[2];

			int deltaX = 0;
			int deltaY = 0;

			switch (dungen[YI, XI])
			{
			case 0:
				break;

			case 1:
				deltaY++;
				break;

			case 2:
				deltaX = (POS[0] == 'L') ? 1 : -1;
				break;

			case 3:
				deltaY++;
				break;

			case 4:
				switch (POS[0])
				{
				case 'T':
					deltaX--;
					break;
				case 'R':
					deltaY++;
					break;
				}
				break;

			case 5:
				switch (POS[0])
				{
				case 'T':
					deltaX++;
					break;
				case 'L':
					deltaY++;
					break;
				}
				break;

			case 6:
				switch (POS[0])
				{
				case 'T':
					break;

				case 'L':
					deltaX++;
					break;

				case 'R':
					deltaX--;
					break;
				}
				break;

			case 7:
			case 8:
			case 9:
				deltaY++;
				break;

			case 10:
				deltaX--;
				break;

			case 11:
				deltaX++;
				break;

			case 12:
			case 13:
				deltaY++;
				break;
			}

			// Write an action using Console.WriteLine()
			// To debug: Console.Error.WriteLine("Debug messages...");

			Console.WriteLine("{0} {1}", XI + deltaX, YI + deltaY); // One line containing the X Y coordinates of the room in which you believe Indy will be on the next turn.
		}
	}
}
