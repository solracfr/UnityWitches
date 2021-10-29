using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)] float m_speed = 1f;

    Enemy enemy;

    public float speed 
    {
        get {return m_speed;}
        set 
        {
            if(value < 0.0f) 
                Debug.Log("Cannot have negative speed value");
            else 
                m_speed = value;
        }
    }
    
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        Debug.Log("Start here");
        StartCoroutine(FollowPath());
        Debug.Log("finishing start"); // appears after first path name, but before the other path names
    }

    void Start()
    {
        enemy = GetComponent<Enemy>(); // Enemy.cs is also a component in the gameObject this script is attached to
    }

    void FindPath()
    {

        path.Clear();
        
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach(GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<Waypoint>());
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position; // any enemy that's instantiated will get put into the start of the path
    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path) 
        {
            {
                Vector3 startPosition = transform.position;
                Vector3 endPosition = waypoint.transform.position;
                float travelPercent = 0f;

                transform.LookAt(endPosition);

                while(travelPercent  < 1f)
                {
                    travelPercent += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                    yield return new WaitForEndOfFrame();
                }
                //yield return new WaitForSeconds(waitTime); // yields control back to the start method, or whatever code comes next
            }
        }

        // enemy has made it to the end of the path by this point
        enemy.StealGold(); // still works if placed after disabling enemy; may cause problems if OnDisable() is utilized
        gameObject.SetActive(false);
    }
}
