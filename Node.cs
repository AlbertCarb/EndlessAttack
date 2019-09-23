using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>
{
    public bool m_walkable; // value to see if a certain node is walkable
    public Vector3 m_worldPosition; // vector to represent a current world position 
    public int m_gridX; // x coord 
    public int m_gridY; // y coord

    public int m_gCost; // g cost of node that will be used for A*
    public int m_hCost; // h cost of node that will be used for A*
    private int m_fCost; // the final cost between the g and h cost to determine which node to take next

    public Node m_parent; // reference to the parent node

    int m_heapIndex; // position in the heap array

/**/
    /*
    Node::Node() Node::Node()

    NAME
        Node::Node - initializes the Node class objects

    SYNOPSIS
        public Node::Node(bool a_walkable, Vector3 a_worldPos, int a_gridX, int a_gridY); 
            a_walkable -> value if the node is walkable or not
            a_worldPos -> node's position relative to the world 
            a_gridX -> x coord 
            a_gridY -> y coord
       
    DESCRIPTION
        This function is responsible for acting as a constructor for the Node
        class 

    RETURNS
        Node class object

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public Node(bool a_walkable, Vector3 a_worldPos, int a_gridX, int a_gridY)
    {
        m_walkable = a_walkable; 
        m_worldPosition = a_worldPos;
        m_gridX = a_gridX;
        m_gridY = a_gridY;
    }
/* public Node::Node(bool a_walkable, Vector3 a_worldPos, int a_gridX, int a_gridY); */

/**/
    /*
    Node::FCost Node::FCost

    NAME
        Node::FCost - gets the int value of FCost

    SYNOPSIS
        public int Node::FCost; 
       
    DESCRIPTION
        This function is responsible for returning the f cost of determining the best path
        by adding the g cost and h cost together

    RETURNS
        int value of m_gCost + m_hCost

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public int FCost
    {
        get
        {
            return m_gCost + m_hCost;
        }
    }
/* public int Node::FCost; */

/**/
    /*
    Node::HeapIndex Node::HeapIndex

    NAME
        Node::HeapIndex - gets the int value of HeapIndex

    SYNOPSIS
        public int Node::HeapIndex; 
       
    DESCRIPTION
        This accessor and mutator is reponsible for getting and setting the value
        of the private member m_heapIndex

    RETURNS
        int value of m_heapIndex

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public int HeapIndex
    {
        get
        {
            return m_heapIndex;
        }

        set
        {
            m_heapIndex = value;
        }
    }
/* public int Node::HeapIndex; */

/**/
    /*
    Node::CompareTo() Node::CompareTo()

    NAME
        Node::CompareTo - compares the cost of nodes

    SYNOPSIS
        public int Node::CompareTo(Node a_nodeToCompare); 
            a_nodeToCompare -> the node to compare to the current node
       
    DESCRIPTION
        This function is responsible for comparing the f cost of two nodes 
        or h cost if the f cost is 0

    RETURNS
        negative int value of the compared cost

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public int CompareTo(Node a_nodeToCompare)
    {
        int compare = FCost.CompareTo(a_nodeToCompare.FCost);
        
        if (compare == 0)
        {
            compare = m_hCost.CompareTo(a_nodeToCompare.m_hCost);
        }

        return -compare;
    }
/* public int Node::CompareTo(Node a_nodeToCompare); */
}
