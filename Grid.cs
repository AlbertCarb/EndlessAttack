using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public bool m_onlyDisplayPathGizmos; // bool value to see if user only wants the A* path to be displayed 
    public LayerMask m_unwalkableMask; // reference to unwalkable parts of the map, i.e. water 
    public Vector2 m_gridWorldSize;  // Vector2 variable holding the size of the world 
    public float m_nodeRadius; // float value with the radius of a node
    Node[,] m_grid; // node array which will represent each tile on the map

    float m_nodeDiameter; // diameter of a node 
    int m_gridSizeX; // size of the grid along the x axis 
    int m_gridSizeY; // size of the grid along the y axis

/**/
    /*
    Grid::Start() Grid::Start()

    NAME
        Grid::Start - initializes the Grid class objects

    SYNOPSIS
        void Grid::Start(); 
       
    DESCRIPTION
        This function is responsible for acting as a constructor for the Grid
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it initalizes certain 
        Grid-specific stats.
    
        Start is called before the first frame update.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    void Start()
    {
        m_nodeDiameter = m_nodeRadius * 2;
        m_gridSizeX = Mathf.RoundToInt(m_gridWorldSize.x / m_nodeDiameter);
        m_gridSizeY = Mathf.RoundToInt(m_gridWorldSize.y / m_nodeDiameter);
        CreateGrid();
    }
/* void Grid::Start(); */

/**/
    /*
    Grid::MaxSize Grid::MaxSize

    NAME
        Grid::MaxSize - gets/sets the int value of WaveCount

    SYNOPSIS
        public int Grid::MaxSize; 
        
    DESCRIPTION
        This accessor function is repsonsible for getting the current value of 
        m_gridSizeX * m_gridSizeY

    RETURNS
        int value of m_gridSizeX * m_gridSizeY

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public int MaxSize
    {
        get
        {
            return m_gridSizeX * m_gridSizeY;
        }
    }
/* public int Grid::MaxSize; */

/**/
    /*
    Grid::CreateGrid() Grid::CreateGrid()

    NAME
        Grid::CreateGrid - creates the grid relative to the world 

    SYNOPSIS
        void Grid::CreateGrid(); 
       
    DESCRIPTION
        This function is responsible for creating a grid that can be manipulated 
        with our A* algorithm and it is relative to the environment of the map

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    void CreateGrid()
    {
        m_grid = new Node[m_gridSizeX, m_gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * m_gridWorldSize.x / 2 - Vector3.up * m_gridWorldSize.y / 2;

        for (int x = 0; x < m_gridSizeX; x++)
        {
            for (int y = 0; y < m_gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * m_nodeDiameter + m_nodeRadius) + Vector3.up * (y * m_nodeDiameter + m_nodeRadius);

                // identifies which parts of the map are marked as unwalkable so the enemy knows where to avoid
                bool walkable = !(Physics2D.OverlapCircle((Vector2)worldPoint, 0.1f, m_unwalkableMask));
                m_grid[x, y] = new Node(walkable, worldPoint, x, y);
            }
        } 
    }
/* void Grid::CreateGrid(); */

/**/
    /*
    Grid::GetNeighbors() Grid::GetNeighbors()

    NAME
        Grid::GetNeighbors - creates the grid relative to the world 

    SYNOPSIS
        public List<Node> Grid::GetNeighbors(Node a_node); 
            a_node -> current node being checked for neighbors
       
    DESCRIPTION
        This function is responsible for finding all potential neighbors 
        of the current node and storing them into a list.

    RETURNS
        List of Nodes that are neighbors of the current node

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public List<Node> GetNeighbors(Node a_node)
    {
        List<Node> neighbors = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                {
                    continue; 
                }

                int checkX = a_node.m_gridX + x; 
                int checkY = a_node.m_gridY + y;

                if (checkX >= 0 && checkX < m_gridSizeX
                && checkY >= 0 && checkY < m_gridSizeY)
                {
                    neighbors.Add(m_grid[checkX, checkY]);
                }
            }
        }

        return neighbors;
    }
/* public List<Node> Grid::GetNeighbors(Node a_node); */

/**/
    /*
    Grid::NodeFromWorldPoint() Grid::NodeFromWorldPoint()

    NAME
        Grid::NodeFromWorldPoint - gets the node relative to the world position

    SYNOPSIS
        public Node Grid::NodeFromWorldPoint(Vector3 a_worldPos); 
            a_worldPos -> the current world position in the world 
       
    DESCRIPTION
        This function is responsible for finding the node relative to the 
        current position in the world

    RETURNS
        Node from world position

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public Node NodeFromWorldPoint(Vector3 a_worldPos)
    {
        float percentX = (a_worldPos.x + m_gridWorldSize.x / 2) / m_gridWorldSize.x; 
        float percentY = (a_worldPos.y + m_gridWorldSize.y / 2) / m_gridWorldSize.y; 

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((m_gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((m_gridSizeY - 1) * percentY);

        return m_grid[x, y];
    }
/* public Node Grid::NodeFromWorldPoint(Vector3 a_worldPos); */

    public List<Node> path; // List of all the nodes that lead to the target

/**/
    /*
    Grid::OnDrawGizmos() Grid::OnDrawGizmos()

    NAME
        Grid::OnDrawGizmos - draws the gizmos to see where the path is in the engine 

    SYNOPSIS
        void Grid::OnDrawGizmos(); 
       
    DESCRIPTION
        This function is responsible for displaying where the path from the target 
        to goal is. This is mainly used for debugging purposes. It'll paint the nodes 
        certain colors to identify what is walkable space, what isn't, and the path.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(m_gridWorldSize.x, m_gridWorldSize.y, 1));

        if (m_onlyDisplayPathGizmos)
        {
            if (path != null)
            {
                foreach (Node n in path)
                {
                    Gizmos.color = Color.black;
                    Gizmos.DrawCube(n.m_worldPosition, Vector3.one * (m_nodeDiameter - .1f));
                }
            }
        }
        else 
        {
            if (m_grid != null)
            {
                foreach (Node n in m_grid)
                { 
                    if (n.m_walkable)
                    {
                        Gizmos.color = Color.white;
                    }
                    else 
                    {
                        Gizmos.color = Color.red;
                    }

                    if (path != null)
                    {
                        if (path.Contains(n))
                        {
                            Gizmos.color = Color.black;
                        }
                    }
        
                    Gizmos.DrawCube(n.m_worldPosition, Vector3.one * (m_nodeDiameter - .1f));
                }
            }
        }
    }
/* void Grid::OnDrawGizmos(); */
}
