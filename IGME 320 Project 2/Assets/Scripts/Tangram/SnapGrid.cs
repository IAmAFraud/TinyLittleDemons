using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds points for snapping and gives information about valid snapping points.
/// </summary>
public class SnapGrid : MonoBehaviour
{
	[SerializeField] private Transform[] points;

	/// <summary>
	/// Gets the closest valid snapping point.
	/// </summary>
	/// <param name="mousePos">Our current mouse position.</param>
	/// <param name="minRange">Minimum range to activate snapping.</param>
	/// <returns></returns>
	public Vector3 GetClosestSnap(Vector3 mousePos, float minRange)
	{
		Vector3 bestPoint = Vector3.zero;
		float bestDistance = Mathf.Infinity;
		for (int i = 0; i < points.Length; i++)
		{
			float dist = Vector2.Distance(mousePos, points[i].position);
			if (dist < minRange && dist < bestDistance)
			{
				bestDistance = dist;
				bestPoint = points[i].position;
			}
		}

		return bestPoint;
	}
}