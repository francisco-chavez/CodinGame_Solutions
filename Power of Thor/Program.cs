using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print TX and TY, if Thor does not follow your orders.
 **/
class Player
{
	static void Main(string[] args)
	{
		string[] inputs = Console.ReadLine().Split(' ');
		int LX = int.Parse(inputs[0]); // the X position of the light of power
		int LY = int.Parse(inputs[1]); // the Y position of the light of power
		int TX = int.Parse(inputs[2]); // Thor's starting X position
		int TY = int.Parse(inputs[3]); // Thor's starting Y position

		// game loop
		while (true)
		{
			int E = int.Parse(Console.ReadLine()); // The level of Thor's remaining energy, representing the number of moves he can still make.


			// Write an action using Console.WriteLine()
			// To debug: Console.Error.WriteLine("Debug messages...");
			var dir = string.Empty;


			if (LY != TY)
			{
				if (TY > LY)
				{
					dir = "N";
					TY--;
				}
				else
				{
					dir = "S";
					TY++;
				}
			}

			if (LX != TX)
			{
				if (TX < LX)
				{
					dir += "E";
					TX++;
				}
				else
				{
					dir += "W";
					TX--;
				}
			}

			Console.WriteLine(dir); // A single line providing the move to be made: N NE E SE S SW W or NW
		}
	}
}
