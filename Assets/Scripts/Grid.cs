using UnityEngine;

public class Grid : MonoBehaviour
{
    public LayerMask UnwalkableMask;
    public Vector2 GridWorldSize;
    public float NodeRadius;

    private Node[,] _grid;
    private float _nodeDiameter;
    private int _gridSizeX, _gridSizeY;

    private void Start()
    {
        _nodeDiameter = NodeRadius * 2;
        _gridSizeX = Mathf.RoundToInt(GridWorldSize.x / _nodeDiameter);
        _gridSizeY = Mathf.RoundToInt(GridWorldSize.y / _nodeDiameter);
        CreateGrid();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(GridWorldSize.x, 1, GridWorldSize.y));

        if (_grid != null)
        {
            foreach (Node node in _grid)
            {
                Gizmos.color = (node.Walkable) ? Color.white : Color.red;
                Gizmos.DrawCube(node.WorldPosition, Vector3.one * (_nodeDiameter - .1f));
            }
        }
    }

    private void CreateGrid()
    {
        _grid = new Node[_gridSizeX, _gridSizeY];
        Vector3 worldBottomLeft =
            transform.position - Vector3.right * GridWorldSize.x / 2 - Vector3.forward * GridWorldSize.y / 2;

        for (int x = 0; x < _gridSizeX; x++)
        {
            for (int y = 0; y < _gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * _nodeDiameter + NodeRadius) + Vector3.forward * (y * _nodeDiameter + NodeRadius);
                bool walkable = !(Physics.CheckSphere(worldPoint, NodeRadius, UnwalkableMask));
                _grid[x, y] = new Node(walkable, worldPoint);
            }
        }
    }
}