using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Author: TJ Larson
/// Stores a list of all of the game levels and allows other scripts to reference levels easily
/// </summary>

[CreateAssetMenu(fileName = "Level List")]
public class LevelList : ScriptableObject
{
    // Fields
    [SerializeField] private List<Level> storedLevels;
    [SerializeField] private int currentLevel;


	private void OnEnable()
	{
        currentLevel = 0;
	}


	// Returns the list containing all the stored levels
	public List<Level> StoredLevels
    {
        get { return storedLevels; }
    }

    // Returns an int of the level currently being played
    public int CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }
}
