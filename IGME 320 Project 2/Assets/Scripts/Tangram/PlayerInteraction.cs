using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles the players interaction such as clicking.
/// </summary>
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] LayerMask shapeLayer;
    [SerializeField] Camera mainCamera;
    [SerializeField] SnapGrid grid;

    private Vector2 worldPoint;
    private bool holdingShape = false;
    private Shape currentShape;

    public bool HoldingShape
	{
        get
		{
            return holdingShape;
		}
	}


    /// <summary>
    /// Checks if we have a current shape. If we do we update the shapes position and sometimes snap them.
    /// </summary>
    void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = mainCamera.farClipPlane * .5f;
        worldPoint = mainCamera.ScreenToWorldPoint(mousePos);
        if (currentShape != null)
		{

            Vector3 currentPos = currentShape.transform.position;
            currentPos = worldPoint;

            Vector2 snapPoint = grid.GetClosestSnap(worldPoint, 0.5f);
            if (snapPoint != Vector2.zero)
			{
                currentPos = snapPoint;
            }

            currentPos.z = currentShape.ZPos;


            currentShape.transform.position = currentPos;
        }
    }

    /// <summary>
    /// Takes in the on click event and will hold a shape if we are hovering over one.
    /// </summary>
    /// <param name="value">The input value pa</param>
    public void OnClick(InputValue value)
	{

        if (value.isPressed)
		{
            Vector3 mousePos = Mouse.current.position.ReadValue();
            mousePos.z = mainCamera.farClipPlane * .5f;
            Vector3 worldPoint = mainCamera.ScreenToWorldPoint(mousePos);


            RaycastHit2D result = Physics2D.Raycast(worldPoint, Vector2.zero, 1000f, shapeLayer);
            if (result)
            {
                currentShape = result.collider.gameObject.GetComponent<Shape>();
                currentShape.Held = true;
            }
        }
        else if (currentShape != null)
		{
            currentShape.Held = false;
            currentShape = null;
        }
    }

    /// <summary>
    /// Will rotate the current shape if we have one.
    /// </summary>
    /// <param name="value">The input value.</param>
    public void OnRotate(InputValue value)
    {

        if (value.isPressed && currentShape != null)
        {
            currentShape.gameObject.transform.Rotate(Vector3.forward, 90f);
        }
    }
}