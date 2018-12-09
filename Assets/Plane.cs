using UnityEngine;

namespace Utils
{
	public class Plane
	{
		public enum Result
		{
			Positive = 0,
			Negative,
			Intersect,
		}

		public Vector3 Normal { get; private set; }
		public float Distance { get; private set; }

		public Plane(Vector3 n, float d)
		{
			Normal = n;
			Distance = d;
		}

		public Result CheckSide(Sphere sphere)
		{
			return CheckSide(sphere.Center, sphere.Radius);
		}

		public Result CheckSide(Vector3 c, float r)
		{
			// 球の中心と平面の符号付き距離を計算.
			float distance = Vector3.Dot(c, Normal) - Distance;

			// 球が平面と交差している
			if (Mathf.Abs(distance) < r) {
				return Result.Intersect;
			}
			if (r < distance) {
				// 平面の面側
				return Result.Positive;
			}
			//平面の裏側
			return Result.Negative;
		}

		public bool IsPositive(Vector3 pos, bool includeZeroFlag = true)
		{
			float distance = Vector3.Dot(pos, Normal) - Distance;
			
			return includeZeroFlag ? 0f <= distance : 0f < distance;
		}
	}
}

