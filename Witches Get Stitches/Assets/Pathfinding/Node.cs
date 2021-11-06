using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// pure classes can no longer be attached
// to a GameObject in the Editor
// in other words, this class exists purely
// as data that can be read in console
[System.Serializable] // allows inspector to notice this class
public class Node
{
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

    // constructor
    public Node(Vector2Int coordinates, bool isWalkable)
    {
        this.coordinates = coordinates; // making use of this to distinguish keywords
        this.isWalkable  = isWalkable;
    }
}
