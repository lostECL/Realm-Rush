using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable;} }

    GridManager gridManager;
    PathFinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<PathFinder>();
    }

    void start()
    {
        if(gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosistion(transform.position);

            if(!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    void OnMouseDown()       
    {
        if(gridManager.GetNode(coordinates).isWalkable && !pathfinder.willBlockPath(coordinates))
        {
            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);
            if(isSuccessful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
                isPlaceable = false;
            }
        }
    }
}
