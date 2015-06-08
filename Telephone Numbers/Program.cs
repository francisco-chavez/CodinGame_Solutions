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
		Tree numbers = new Tree();
		for (int i = 0; i < N; i++)
		{
			string telephone = Console.ReadLine();
			numbers.AddNumber(telephone);
		}

		// Write an action using Console.WriteLine()
		// To debug: Console.Error.WriteLine("Debug messages...");

		Console.WriteLine(numbers.GetItemCount()); // The number of elements (referencing a number) stored in the structure.
	}
}

public class Tree
{
	private Node root = new Node();

	public void AddNumber(string number)
	{
		Node current = root;
		foreach (char c in number)
		{
			int digit = (int) char.GetNumericValue(c);
			if (current.Children[digit] == null)
				current.Children[digit] = new Node();

			current = current.Children[digit];
		}
	}

	public int GetItemCount() { return Node.Count - 1; }
}

public class Node
{
	private Node[] children;

	public static int Count { get { return count; } }
	private static int count = 0;

	public Node()
	{
		children = new Node[10];
		for (int i = 0; i < 10; i++)
			children[i] = null;

		Node.count++;
	}

	public Node[] Children { get { return children; } }
}
