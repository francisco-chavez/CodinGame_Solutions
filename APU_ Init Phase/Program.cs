using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Player
{
	static void Main(string[] args)
	{
		int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
		int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis

		bool[,] grid = new bool[height, width];
		for (int h = 0; h < height; h++)
		{
			string line = Console.ReadLine(); // width characters, each either 0 or .
			for (int w = 0; w < width; w++)
			{
				grid[h, w] = '0' == line[w];
			}
		}

		Console.Error.WriteLine("Finished building {0}x{1} grid.", width, height);
		int[] coords = new int[6];

		for (int h = 0; h < height; h++)
		{
			Console.Error.WriteLine("Looking at row {0}", h);
			for (int w = 0; w < width; w++)
			{
				Console.Error.WriteLine("Looking at: ({0}, {1})", w, h);

				if (grid[h, w])
				{
					Console.Error.WriteLine("Found node at: ({0}, {1})", w, h);
					coords[0] = w;
					coords[1] = h;

					for (int w2 = w + 1; w2 <= width; w2++)
					{
						if (w2 == width || !grid[h, w2])
						{
							coords[2] = -1;
							coords[3] = -1;
						}
						else
						{
							coords[2] = w2;
							coords[3] = h;
							break;
						}
					}

					for (int h2 = h + 1; h2 <= height; h2++)
					{
						if (h2 == height || !grid[h2, w])
						{
							coords[4] = -1;
							coords[5] = -5;
						}
						else
						{
							coords[4] = w;
							coords[5] = h2;
							break;
						}
					}


					Console.WriteLine("{0} {1} {2} {3} {4} {5}", coords[0], coords[1], coords[2], coords[3], coords[4], coords[5]);
				}
			}
		}

		// Write an action using Console.WriteLine()
		// To debug: Console.Error.WriteLine("Debug messages...");

		//Console.WriteLine("0 0 1 0 0 1"); // Three coordinates: a node, its right neighbor, its bottom neighbor
	}
}
