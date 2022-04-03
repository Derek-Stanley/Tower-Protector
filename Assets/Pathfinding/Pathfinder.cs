using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
   [SerializeField] Node currentSearchNode;
   Vector2Int[] directions = {Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
   GridManager gridManager;
   Dictionary<Vector2Int, Node> grid;

   void Awake() 
   {
       gridManager = FindObjectOfType<GridManager>(); 
       if(gridManager != null )
       {
           grid = gridManager.Grid;
       }      
   }
    void Start()
    {
        ExploreNeighbours();
    }

    void ExploreNeighbours()
    {
        List<Node> neighbours = new List<Node>();

        foreach (var direction in directions)
        {
            Vector2Int nieghborCoor = currentSearchNode.coordinates + direction;
            if(grid.ContainsKey(nieghborCoor))
            {
                neighbours.Add(grid[nieghborCoor]);
                //TODO remove after testing
                grid[nieghborCoor].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
            }
        }
    }
}
