using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;

    /*** MY FIRST IMPLEMENTATION
    public void CreateTower(Waypoint waypoint)
    {
        // find waypoint
        // instantiate tower at waypoint
        Instantiate(gameObject, waypoint.transform.position, Quaternion.identity);
    }
    ***/

    // Lecture Method. More general with position and Tower prefabs, so perhaps more
    // scalable or adaptable?
    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null) { return false; }

        if (bank.CurrentBalance >= cost)
        {
            Instantiate(tower, position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }
        
        return false;
    }
}
