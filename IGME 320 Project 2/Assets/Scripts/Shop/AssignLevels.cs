using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignLevels : MonoBehaviour
{
	public LevelList levelList;

    /// <summary>
	/// Author: John Heiden
	/// Adds a level index to each button, with no repeating indices
	/// Each index is stored in the button's text to be referenced by other scripts
	/// </summary>
    void Start()
    {
		List<int> levelsToSelect = new List<int>();
		foreach (GameObject button in GameObject.FindGameObjectsWithTag("PuzzleButton"))
		{
			int level = Random.Range(0, levelList.StoredLevels.Count);
			while (levelsToSelect.Contains(level))
			{
				level = Random.Range(0, levelList.StoredLevels.Count);
			}

			levelsToSelect.Add(level);

			button.GetComponent<Image>().sprite = levelList.StoredLevels[7].WallsPrefab.GetComponentInChildren<SpriteRenderer>().sprite;
			button.GetComponentInChildren<Text>().text = level.ToString();
		}
    }
}
