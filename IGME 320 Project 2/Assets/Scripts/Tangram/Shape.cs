using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Responsible for keeping track of shape overlap and changes
/// color if we do.
/// </summary>
public class Shape : MonoBehaviour
{
	[SerializeField] private SpriteRenderer sprite;
	[SerializeField] private LayerMask shapeLayer;
	[SerializeField] private float zPos = -2f;
	private int overlap;
	private bool held;


	public float ZPos
	{
		get
		{
			return zPos;
		}
	}

	public bool Held
	{
		get
		{
			return held;
		}
		set
		{
			held = value;
		}
	}

	public int Overlap
	{
		get
		{
			return overlap;
		}
	}

	/// <summary>
	/// If we are overlapping, then grey out the shape being held.
	/// </summary>
	private void Update()
	{
		if (overlap > 0)
		{
			Color color = sprite.color;
			color.a = 0.8f;

			sprite.color = color;
		}
		else
		{
			Color color = sprite.color;
			color.a = 1f;

			sprite.color = color;
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
			overlap++;
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
			overlap--;
		}
	}
}