using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TangramManager : MonoBehaviour
{
	[SerializeField] WinZone winZone;
	[SerializeField] Boundary boundary;
	[SerializeField] List<Shape> shapes;
	[SerializeField] Camera cam;
	[SerializeField] private SpriteRenderer cursorSprite;
	[SerializeField] private Sprite thumbsUpSprite;

	[Header("Shape Prefabs")]
	[SerializeField] private GameObject squarePrefab;
	[SerializeField] private GameObject smallTriPrefab;
	[SerializeField] private GameObject bigTriPrefab;
	[SerializeField] private GameObject rightTrapPrefab;
	[SerializeField] private GameObject leftTrapPrefab;
	[SerializeField] private GameObject rightParallelPrefab;
	[SerializeField] private GameObject leftParallelPrefab;

	private SpriteRenderer wall;
	private GameObject shapesObject;
	private bool loading = false;

	// Position Vectors for Placing Shapes
	private Vector2 squareStart = new Vector2(-6.0f, -3.0f);
	private Vector2 smallTriStart = new Vector2(5.5f, 1.5f);
	private Vector2 bigTriStart = new Vector2(-7.0f, 0.0f);
	private Vector2 rightTrapStart = new Vector2(8.5f, 1.0f);
	private Vector2 leftTrapStart = new Vector2(-9.0f, -3.0f);
	private Vector2 rightParallelStart = new Vector2(5.5f, -3.0f);
	private Vector2 leftParallelStart = new Vector2(8.5f, -3.0f);

	// Level Loading Variables
	[SerializeField] LevelList levelList;

	// Animator for the Transition Sheet
	[SerializeField] Animator levelTransition;

	private bool NoShapeOverlap()
	{
		for (int i = 0; i < shapes.Count; i++)
		{

			if (shapes[i].Overlap > 0)
			{
				return false;
			}
		}
		return true;
	}

	private bool AllShapesInDaBag()
	{
		return winZone.OverlapWinZone >= shapes.Count;
	}

	private bool NoBoundaryHits()
	{
		return boundary.OverlapBoundary <= 0;
	}

    private void Start()
	{
		LoadLevel();
		wall = boundary.gameObject.GetComponent<SpriteRenderer>();
	}

	/// <summary>
	/// Checks first if we have no boundary hits. The boundary is a line around the shape.
	/// Then checks if we have all shapes inside of the puzzle. Checks by a count.
	/// Checks if any of the shapes overlap with eachother.
	/// If all passes then we change the background color to green to show we won.
	/// </summary>
	private void Update()
	{
		if (NoBoundaryHits() && AllShapesInDaBag() && NoShapeOverlap() && !loading)
		{
			//cam.backgroundColor = Color.green;

			cursorSprite.sprite = thumbsUpSprite;
			StartCoroutine(OnAnimation());
		}
	}

	// Level Loading Functionality

	/// <summary>
	/// Loads in the selected level
	/// </summary>
	private void LoadLevel()
    {
		// Selects the active level
		Level selectedLevel = levelList.StoredLevels[levelList.CurrentLevel];
		GameObject levelBoundaries = selectedLevel.WallsPrefab;

		// Instantiates the level prefab
		GameObject levelPrefab = Instantiate(levelBoundaries);
		winZone = levelPrefab.GetComponentInChildren<WinZone>();
		boundary = levelPrefab.GetComponentInChildren<Boundary>();

		// Creates the shapes game object
		if (!shapesObject)
        {
			Destroy(shapesObject);
			shapesObject = new GameObject("Shapes");
			shapesObject.transform.position = new Vector3(-1f, -1f, -2f);

		}

		// Clears the shapes list
		shapes.Clear();

		// Pushes new shapes into the shapes list and instantiates them
		LoadShapes(selectedLevel);
	}

	/// <summary>
	/// Loads in the shapes for the level
	/// </summary>
	/// <param name="level">The scriptable object of the level</param>
	private void LoadShapes(Level level)
    {
		GameObject curShape;

		// For the squares
		for (int i = 0; i < level.NumSquares; i++)
		{
			
			curShape = Instantiate(squarePrefab, new Vector3(squareStart.x + (i * 0.3f), squareStart.y + (i * -0.2f), 0.0f), Quaternion.identity);
			Shape shapeScript = curShape.GetComponent<Shape>();
			Vector3 vec = curShape.transform.position;
			vec.z = shapeScript.ZPos;
			curShape.transform.position = vec;
			curShape.transform.parent = shapesObject.transform;
			shapes.Add(shapeScript);

		}
		// For the Small Triangles
		for (int i = 0; i < level.NumSmallTris; i++)
		{
			curShape = Instantiate(smallTriPrefab, new Vector3(smallTriStart.x + (i * 0.3f), smallTriStart.y + (i * -0.2f), 0.0f), Quaternion.identity);
			Shape shapeScript = curShape.GetComponent<Shape>();
			Vector3 vec = curShape.transform.position;
			vec.z = shapeScript.ZPos;
			curShape.transform.position = vec;
			curShape.transform.parent = shapesObject.transform;
			shapes.Add(shapeScript);
		}
		// For the Big Triangles
		for (int i = 0; i < level.NumBigTris; i++)
		{
			curShape = Instantiate(bigTriPrefab, new Vector3(bigTriStart.x + (i * 0.3f), bigTriStart.y + (i * -0.2f), 0.0f), Quaternion.identity);
			Shape shapeScript = curShape.GetComponent<Shape>();
			Vector3 vec = curShape.transform.position;
			vec.z = shapeScript.ZPos;
			curShape.transform.position = vec;
			curShape.transform.parent = shapesObject.transform;
			shapes.Add(shapeScript);
		}
		// For the Right Trapezoids
		for (int i = 0; i < level.NumRightTrap; i++)
		{
			curShape = Instantiate(rightTrapPrefab, new Vector3(rightTrapStart.x + (i * 0.3f), rightTrapStart.y + (i * -0.2f), 0.0f), Quaternion.identity);
			Shape shapeScript = curShape.GetComponent<Shape>();
			Vector3 vec = curShape.transform.position;
			vec.z = shapeScript.ZPos;
			curShape.transform.position = vec;
			curShape.transform.parent = shapesObject.transform;
			shapes.Add(shapeScript);
		}
		// For the left Trapezoids
		for (int i = 0; i < level.NumLeftTrap; i++)
		{
			curShape = Instantiate(leftTrapPrefab, new Vector3(leftTrapStart.x + (i * 0.3f), leftTrapStart.y + (i * -0.2f), 0.0f), Quaternion.identity);
			Shape shapeScript = curShape.GetComponent<Shape>();
			Vector3 vec = curShape.transform.position;
			vec.z = shapeScript.ZPos;
			curShape.transform.position = vec;
			curShape.transform.parent = shapesObject.transform;
			shapes.Add(shapeScript);
		}
		// For the Right Parallelograms
		for (int i = 0; i < level.NumRightParallel; i++)
		{
			curShape = Instantiate(rightParallelPrefab, new Vector3(rightParallelStart.x + (i * 0.3f), rightParallelStart.y + (i * -0.2f), 0.0f), Quaternion.identity);
			Shape shapeScript = curShape.GetComponent<Shape>();
			Vector3 vec = curShape.transform.position;
			vec.z = shapeScript.ZPos;
			curShape.transform.position = vec;
			curShape.transform.parent = shapesObject.transform;
			shapes.Add(shapeScript);
		}
		// For the Left Parallelograms
		for (int i = 0; i < level.NumLeftParallel; i++)
		{
			curShape = Instantiate(leftParallelPrefab, new Vector3(leftParallelStart.x + (i * 0.3f), leftParallelStart.y + (i * -0.2f), 0.0f), Quaternion.identity);
			Shape shapeScript = curShape.GetComponent<Shape>();
			Vector3 vec = curShape.transform.position;
			vec.z = shapeScript.ZPos;
			curShape.transform.position = vec;
			curShape.transform.parent = shapesObject.transform;
			shapes.Add(shapeScript);
		}
	}


	/// <summary>
	/// Author: John Heiden
	/// Performs an animation before moving from Tangram to Store
	/// </summary>
	/// <returns></returns>
	IEnumerator OnAnimation()
	{
		yield return new WaitForSeconds(2);

		levelTransition.SetBool("TransitionStarted", true);

		yield return new WaitForSeconds(3);

		while (levelTransition.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
		{
			yield return null;
		}

		levelList.CurrentLevel++;
		SceneManager.LoadScene(2);
		loading = true;
		StopAllCoroutines();
	}
}