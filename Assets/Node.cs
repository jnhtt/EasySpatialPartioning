using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public interface INode
	{
		void Execute();
		INode GetNext(Vector3 pos);
		bool IsLeaf();
	}

	public class Node : INode
	{
		protected Node positive;
		protected Node negative;
		protected Plane plane;
		protected Action exec;

		public static Node CreateLeaf(Action exec)
		{
			return new Node(null, null, null, exec);
		}

		public Node(Plane plane, Node posi, Node nega, Action exec)
		{
			this.plane = plane;
			this.positive = posi;
			this.negative = nega;
			this.exec = exec;
		}

		public INode GetNext(Vector3 pos)
		{
			if (plane.IsPositive(pos)) {
				return positive;
			} else {
				return negative;
			}
		}

		public void Execute()
		{
			if (exec != null) {
				exec();
			}
		}

		public bool IsLeaf()
		{
			return positive == null && negative == null;
		}
	}
}
