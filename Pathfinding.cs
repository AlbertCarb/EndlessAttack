using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    Grid m_grid; // grid object to represent the underlying world map

    private List<Node> m_path; // node list to hold the path to the target from the enemy 

/**/
    /*
    Pathfinding::Awake() Pathfinding::Awake()

    NAME
        Pathfinding::Awake - initializes the state of the Pathfinding class objects 

    SYNOPSIS
        void Pathfinding::Awake(); 
        
    DESCRIPTION
        This function is responsible for intialzing varaibles or game states
        before the game starts. It is called after all objects are intialized. 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    void Awake()
    {
        // creates reference to grid component in the engine
        m_grid = GetComponent<Grid>();
    }
/* void Pathfinding::Awake(); */

/**/
    /*
    Pathfinding::FindPath() Pathfinding::FindPath()

    NAME
        Pathfinding::FindPath - finds the path from the enemy to the player

    SYNOPSIS
        public List<Node> Pathfinding::FindPath(Vector3 a_startPos, Vector3 a_targetPos);
            a_startPos -> the start position of where the path begins 
            a_targetPos -> the end position of where the path should end 
        
    DESCRIPTION
        This function is responsible for finding the shortest path from the enemy 
        to the player while avoiding any unwalkable terrain.

    RETURNS
        Node list of all the nodes in the path

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public List<Node> FindPath(Vector3 a_startPos, Vector3 a_targetPos)
    {
        // start and end nodes relative to the position on the map
        Node startNode = m_grid.NodeFromWorldPoint(a_startPos);
        Node targetNode = m_grid.NodeFromWorldPoint(a_targetPos);

        // open set is in the heap where we can quickly access unchecked nodes
        Heap<Node> openSet = new Heap<Node>(m_grid.MaxSize);

        // closed set to hold anything already examined
        HashSet<Node> closedSet = new HashSet<Node>();

        // start node automatically gets added to the open set
        openSet.Add(startNode);

        m_path = null;

        // while the open set is not 0 and the path is not null
        // check the neighbors of each node and see what has the lowest fcost and follow it 
        while (openSet.Count > 0 && m_path == null)
        {
            Node currentNode = openSet.RemoveFirst(); 
            closedSet.Add(currentNode);

            if (currentNode == targetNode)
            {
                TrackPath(startNode, targetNode);
            }

            // for every neighbor, if any are not walkable or have been examined
            // then skip the node
            foreach (Node neighbor in m_grid.GetNeighbors(currentNode))
            {
                if (!neighbor.m_walkable || closedSet.Contains(neighbor))
                {
                    continue; 
                }

                // holds the cost of what it'd take to move to a particular neighbor from the current node
                int newMovementCostToNeighbor = currentNode.m_gCost + GetDistance(currentNode, neighbor);

                // if it's less than the neigbors g cost or it's not found in the open set 
                // then set the neighbor to the current node 
                if (newMovementCostToNeighbor < neighbor.m_gCost || !openSet.Contains(neighbor))
                {
                    neighbor.m_gCost = newMovementCostToNeighbor; 
                    neighbor.m_hCost = GetDistance(neighbor, targetNode);
                    neighbor.m_parent = currentNode;

                    // if it does not contain the new neighbor then add to the open set
                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                    else // else update the item
                    {
                        openSet.UpdateItem(neighbor);
                    }
                }
            }
        }

        if (m_path != null)
        {
            return m_path;
        }

        return null;
    }
/* public List<Node> Pathfinding::FindPath(Vector3 a_startPos, Vector3 a_targetPos); */

/**/
    /*
    Pathfinding::TrackPath() Pathfinding::TrackPath()

    NAME
        Pathfinding::TrackPath - tracks all the nodes in a path

    SYNOPSIS
        private void Pathfinding::TrackPath(Node a_startNode, Node a_endNode);
            a_startPos -> the start position of where the path begins 
            a_endNode -> the end position of where the path should end 
        
    DESCRIPTION
        This function is responsible for tracking the current path between the start 
        and end nodes. 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    private void TrackPath(Node a_startNode, Node a_endNode)
    {
        Node currNode = a_endNode;

        while (currNode != a_startNode)
        {
            m_path.Add(currNode);
            currNode = currNode.m_parent;
        }

        m_path.Reverse();
        m_grid.path = m_path;
    }
/* private void Pathfinding::TrackPath(Node a_startNode, Node a_endNode); */

/**/
    /*
    Pathfinding::GetDistance() Pathfinding::GetDistance()

    NAME
        Pathfinding::GetDistance - gets distance between two nodes

    SYNOPSIS
        private void Pathfinding::GetDistance(Node a_nodeA, Node a_nodeB);
            a_nodeA -> first node to check distance
            a_nodeB -> second node to check distance
        
    DESCRIPTION
        This function is responsible for getting the distance between two nodes
        relative to their x and y coords. 

    RETURNS
        int value of the distance between the two nodes

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    private int GetDistance(Node a_nodeA, Node a_nodeB)
    {
        int distanceX = Mathf.Abs(a_nodeA.m_gridX - a_nodeB.m_gridX);
        int distanceY = Mathf.Abs(a_nodeA.m_gridY - a_nodeB.m_gridY);

        if (distanceX > distanceY)
        {
            return 14 * distanceY + 10 * (distanceX - distanceY);
        }

        return 14 * distanceX + 10 * (distanceY - distanceX);
    }
/* private int Pathfinding::getDistance(Node a_nodeA, Node a_nodeB); */
}
