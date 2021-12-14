using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple script that keeps count of how many shapes are within our boundary.
/// </summary>
public class WinZone : MonoBehaviour
{
	[SerializeField] LayerMask shapeLayer;

	private int overlapWinZone = 0;

	public int OverlapWinZone
	{
		get
		{
			return overlapWinZone;
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
			overlapWinZone++;
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
			overlapWinZone--;
		}
	}
}
