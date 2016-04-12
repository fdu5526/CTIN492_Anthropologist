using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/*
 * a bunch of global stuff that everyone needs put into the same place
 * everything in here is jank as hell, do not question
 */
public class Global
{
	// hardcoded layer numbers
	public const int layerPlayer = 8;
	public const int layerEnemy = 9;
	public const int layerFlame = 11;
	public const int layerInvincible = 12;
	public const int layerEnvironment = 13;
	public const int layerEnemyAttack = 14;
	public const int layerFlameTrail = 15;
	public const int layerReflectedEnemyAttack = 16;

	public static bool FiftyFifty { get { return UnityEngine.Random.value > 0.5f; } }
	
	// find facing angle based on default sprite direction
	public static float Angle (Vector2 defaultDirection, Vector2 direction) {
		float theta = Vector2.Angle(defaultDirection, direction);
		if (defaultDirection == Vector2.down) {
			theta = direction.x < 0f ? -theta : theta;
		} else if (defaultDirection == Vector2.right) {
  		theta = direction.y > 0f ? -theta : theta;
		} else if (defaultDirection == Vector2.up) {
			theta = direction.x > 0f ? -theta : theta;
		} else if (defaultDirection == Vector2.left) {
  		theta = direction.y < 0f ? -theta : theta;
		} 
		return theta;
	}


	// get the vector at the angle DEGREES to vector v
	public static Vector2 VectorAtAngle (Vector2 v, float degrees) {
		float r = degrees / 180f * Mathf.PI;
		float c = Mathf.Cos(r);
		float s = Mathf.Sin(r);
		return new Vector2(v.x * c + v.y * s, v.x * -s + v.y * c);
	}


	// read CSV and poop out data array
	public static int[][] ParseLevelData (string path) {
		TextAsset csv = Resources.Load(path) as TextAsset;

		string[] rows = csv.text.Split('\n');

		// Length - 2 to exclude Beat and Duration columns
		int[][] retVal = new int[rows.Length - 2][];

		// read each row
		for(int i = 1; i < rows.Length - 1; i++) {
			string[] col = rows[i].Split(',');

			// get the enemy data count
			retVal[i - 1] = new int[col.Length - 1];
			for (int d = 1; d < col.Length - 2; d++) {
				retVal[i - 1][d - 1] = Int32.Parse(col[d]);
			}
		}
		return retVal;
	}


	// hacky but efficient Fast inverse square root algorithm
	public static float FastSqrt(float z)
	{
		if (z == 0) return 0;
		FloatIntUnion u;
		u.tmp = 0;
		u.f = z;
		u.tmp -= 1 << 23; /* Subtract 2^m. */
		u.tmp >>= 1; /* Divide by 2. */
		u.tmp += 1 << 29; /* Add ((b + 1) / 2) * 2^m. */
		return u.f;
	}
	// C style union what could go wrong?
	[StructLayout(LayoutKind.Explicit)]
	private struct FloatIntUnion
	{
		[FieldOffset(0)]
		public float f;

		[FieldOffset(0)]
		public int tmp;
	}
}