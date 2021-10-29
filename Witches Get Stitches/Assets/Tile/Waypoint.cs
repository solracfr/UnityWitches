using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }
    void OnMouseDown() 
    {
        if (isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position); // returns whether a tower was placed at this waypoint
            //Debug.Log(transform.name);
            
            //towerPrefab.CreateTower(this) my implementation. passes Waypoint as argument 
            //gameObject does NOT work becuase function specifically asks for Waypoint to pass in
            //Instantiate(towerPrefab, transform.position, Quaternion.identity);

            isPlaceable = !isPlaced; // if tower was placed, waypoint cannot be placeable anymore
        }
    }
}
