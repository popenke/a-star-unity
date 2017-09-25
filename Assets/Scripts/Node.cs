using UnityEngine;

public class Node
{
    public bool Walkable;
    public Vector3 WorldPosition;
    public int GridX;
    public int GridY;
    public int GCost;
    public int HCost;
    public Node Parent;

    public Node(bool walkable, Vector3 worldPosition, int gridX, int gridY)
    {
        Walkable = walkable;
        WorldPosition = worldPosition;
        GridX = gridX;
        GridY = gridY;
    }

    public int FCost
    {
        get { return GCost + HCost; }
    }
}