using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public class Sphere
	{
		public Vector3 Center { get; private set; }
		public float Radius { get; private set; }

		public Sphere(Vector3 c, float r)
		{
			Center = c;
			Radius = r;
		}
	}
}
