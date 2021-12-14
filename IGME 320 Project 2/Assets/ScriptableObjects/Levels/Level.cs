using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Author: TJ Larson
/// Allows for us to create levels with all the necessary information
/// </summary>
[CreateAssetMenu(fileName = "New Level")]
public class Level : ScriptableObject
{
    // Fields
    [SerializeField] private GameObject wallsPrefab;

    [Header("Shapes")]
    [SerializeField] private int numSquares;
    [SerializeField] private int numSmallTris;
    [SerializeField] private int numBigTris;
    [SerializeField] private int numRightTrap;      // When longside down, points right
    [SerializeField] private int numLeftTrap;       // When longside down, points left
    [SerializeField] private int numRightParallel;  // When upright, leans right
    [SerializeField] private int numLeftParallel;   // When upright, leans left

    // Properties

    // Returns the prefab to serve as the puzzle walls
    public GameObject WallsPrefab
    {
        get { return wallsPrefab; }
    }

    // Returns the number of squares in the puzzle
    public int NumSquares
    {
        get { return numSquares; }
    }

    // The number of small triangles in the puzzle
    public int NumSmallTris
    {
        get { return numSmallTris; }
    }

    // The number of big triangles in the puzzle
    public int NumBigTris
    {
        get { return numBigTris; }
    }

    // The number of right trapezoids in the puzzle
    public int NumRightTrap
    {
        get { return numRightTrap; }
    }

    // The number of left trapezoids in the puzzle
    public int NumLeftTrap
    {
        get { return numLeftTrap; }
    }

    // The number of right parallelograms in the puzzle
    public int NumRightParallel
    {
        get { return numRightParallel; }
    }

    // The number of left parallelograms in the puzzle
    public int NumLeftParallel
    {
        get { return numLeftParallel; }
    }
}