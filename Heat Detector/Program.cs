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
		int W = int.Parse(inputs[0]); // width of the building.
		int H = int.Parse(inputs[1]); // height of the building.
		int N = int.Parse(Console.ReadLine()); // maximum number of turns before game over.
		inputs = Console.ReadLine().Split(' ');
		int X0 = int.Parse(inputs[0]);
		int Y0 = int.Parse(inputs[1]);

		int minX = 0;
		int maxX = W;
		int minY = 0;
		int maxY = H;

		// game loop
		while (true)
		{
			string BOMB_DIR = Console.ReadLine(); // the direction of the bombs from batman's current location (U, UR, R, DR, D, DL, L or UL)

			if (BOMB_DIR.Contains('D'))
			{
				minY = Y0;
				if (Y0 == maxY - 1)
					Y0 = maxY;
				else
					Y0 = (maxY + Y0) / 2;
			}
			else if (BOMB_DIR.Contains('U'))
			{
				maxY = Y0;
				Y0 = (minY + Y0) / 2;
			}

			if (BOMB_DIR.Contains('R'))
			{
				minX = X0;
				if (X0 == maxX - 1)
					X0 = maxX;
				else
					X0 = (maxX + X0) / 2;
			}
			else if (BOMB_DIR.Contains('L'))
			{
				maxX = X0;
				X0 = (minX + X0) / 2;
			}

			// Write an action using Console.WriteLine()
			// To debug: Console.Error.WriteLine("Debug messages...");

			Console.WriteLine("{0} {1}", X0, Y0); // the location of the next window Batman should jump to.
		}
	}
}
