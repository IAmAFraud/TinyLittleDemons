using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple script that counts if we have any shapes that overlap with us.
/// </summary>
public class Boundary : MonoBehaviour
{
	[SerializeField] LayerMask shapeLayer;

	private int overlapBoundary = 0;

	public int OverlapBoundary
	{
		get
		{
			return overlapBoundary;
		}
	}

	/// <summary>
	/// Adds to the overlap count. (so we can track how many things we overlap with)
	/// </summary>
	/// <param name="other">The other shape.</param>
	private void OnTriggerEnter2D(Collider2D other)
	{
		int layer = 1 << other.gameObject.layer;

		if (layer == shapeLayer.value)
		{
			overlapBoundary++;
		}
	}

	/// <summary>
	/// Adds to the overlap count. (so we can track how many things we overlap with)
	/// </summary>
	/// <param name="other">The other shape.</param>
	private void OnTriggerExit2D(Collider2D other)
	{
		int layer = 1 << other.gameObject.layer;

		if (layer == shapeLayer.value)
		{
			overlapBoundary--;
		}
	}
}