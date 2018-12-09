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

	public class BSPNode : INode
	{
		protected BSPNode positive;
		protected BSPNode negative;
		protected Plane plane;
		protected Action exec;

		public static BSPNode CreateLeaf(Action exec)
		{
			return new BSPNode(null, null, null, exec);
		}

		public BSPNode(Plane plane, BSPNode posi, BSPNode nega, Action exec)
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
