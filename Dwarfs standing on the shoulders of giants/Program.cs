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
		DAG graph = new DAG();
		int n = int.Parse(Console.ReadLine()); // the number of relationships of influence
		for (int i = 0; i < n; i++)
		{
			string[] inputs = Console.ReadLine().Split(' ');
			int x = int.Parse(inputs[0]); // a relationship of influence between two people (x influences y)
			int y = int.Parse(inputs[1]);

			graph.AddDirectedEdge(x, y);
		}

		// Write an action using Console.WriteLine()
		// To debug: Console.Error.WriteLine("Debug messages...");

		Console.WriteLine(graph.FindLongestPath()); // The number of people involved in the longest succession of influences
	}
}

public class DAG
{
	#region Helper Classes
	public class Node
	{
		private HashSet<Node> _outGoing;

		public IEnumerable<Node> ChildNodes { get { return _outGoing; } }

		public Node(int id)
		{
			this._outGoing = new HashSet<Node>();
		}

		public void AddDestination(Node node)
		{
			this._outGoing.Add(node);
		}
	}
	#endregion

	private Dictionary<int, Node> _nodes;

	// This is a set of node ids with no incoming connections. The longest
	// path will start out with on of these nodes.
	private HashSet<int> _S;

	public DAG()
	{
		_nodes = new Dictionary<int, Node>();
		_S = new HashSet<int>();
	}

	public void AddDirectedEdge(int start, int end)
	{
		if (!_nodes.ContainsKey(start))
		{
			_nodes.Add(start, new Node(start));
			_S.Add(start);
		}

		if (!_nodes.ContainsKey(end))
		{
			_nodes.Add(end, new Node(end));
		}

		if (_S.Contains(end))
			_S.Remove(end);

		_nodes[start].AddDestination(_nodes[end]);
	}

	public int FindLongestPath()
	{
		int maxLengthFound = 0;
		foreach (var s in _S)
		{
			int subPathLength = FindLongestPath(1, _nodes[s]);
			maxLengthFound = Math.Max(maxLengthFound, subPathLength);
		}

		return maxLengthFound;
	}

	private int FindLongestPath(int pathLength, Node parentNode)
	{
		int maxPathLength = pathLength;
		foreach (var d in parentNode.ChildNodes)
		{
			int subPathLength = FindLongestPath(pathLength + 1, d);
			maxPathLength = Math.Max(maxPathLength, subPathLength);
		}

		return maxPathLength;
	}
}
