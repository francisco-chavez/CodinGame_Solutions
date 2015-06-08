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
		int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
		int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.

		Dictionary<string, string> extToFileType = new Dictionary<string, string>(N);
		for (int i = 0; i < N; i++)
		{
			string[] inputs = Console.ReadLine().Split(' ');
			string EXT = inputs[0]; // file extension
			string MT = inputs[1]; // MIME type.
			extToFileType.Add(EXT.ToLower(), MT);
		}

		for (int i = 0; i < Q; i++)
		{
			string FNAME = Console.ReadLine(); // One file name per line.
			string[] parts = FNAME.Split('.');
			if (parts.Length == 1)
			{
				Console.WriteLine("UNKNOWN");
			}
			else
			{
				string ext = parts[parts.Length - 1].ToLower();
				if (extToFileType.ContainsKey(ext))
					Console.WriteLine(extToFileType[ext]);
				else
					Console.WriteLine("UNKNOWN");
			}
		}

		// Write an action using Console.WriteLine()
		// To debug: Console.Error.WriteLine("Debug messages...");

		//Console.WriteLine("UNKNOWN"); // For each of the Q filenames, display on a line the corresponding MIME type. If there is no corresponding type, then display UNKNOWN.
	}
}
