using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathState : IEnemyState
{
    private Stack<Node> m_finalPath; // stack of nodes that holds the final A* path to the player 
    private List<Node> m_path; // a list that holds the nodes to the path 
    private Vector3 m_destination; // the destination of the enemy
    private Vector3 m_current; // the current position of the enemy
    private Vector3 m_goal; // end goal of the enemy to reach which is the player's transform position
    private Transform m_transform; // enemy's transformation value 

/**/
    /*
    PathState::Enter() PathState::Enter()

    NAME
        PathState::Enter - sets vector positions relative to world position

    SYNOPSIS
        public void PathState::Enter(Enemy a_parent); 
            a_parent -> reference to the enemy
        
    DESCRIPTION
        This function is apart of the IEnemyState interface and this is one of
        its functions. This sets accesses the A* algorithm to find the fastest path to
        the player and sets the appropriate Vector variables to identify where to go

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public void Enter(Enemy a_parent)
    {
        this.m_transform = a_parent.transform;
        
        m_path = a_parent.AStar.FindPath(a_parent.transform.parent.position, a_parent.Target.position);
        m_finalPath = PathToStack(m_path);

        m_current = m_finalPath.Pop().m_worldPosition; 
        m_destination = m_finalPath.Pop().m_worldPosition;
        this.m_goal = a_parent.Target.parent.position;
    }
/* public void PathState::Enter(Enemy a_parent); */

/**/
    /*
    PathState::Exit() PathState::Exit()

    NAME
        PathState::Exit - preforms a function upon leaving this state

    SYNOPSIS
        public void PathState::Exit(); 
        
    DESCRIPTION
        This function is not doing anything for this state but is necessary 
        to have to maintain the structure of the interface.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public void Exit()
    {
    }
/* public void PathState::Exit(); */

/**/
    /*
    PathState::Update() PathState::Update()

    NAME
        PathState::Update - updates the state of the PathState class objects

    SYNOPSIS
        public void PathState::Update(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the PathState class' objects by checking its current 
        state and values frame by frame. The values and states that are to be 
        tracked are specified in the body of the function. 
        
        Update is called once per frame.

        This will be used on the enemy so they can follow the player and is
        part of our IEnemyState interface.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    public void Update()
    {
        // if there is an available path to the player 
        // then move the enemy towards the player 
        // this is different from our follow state in that it uses the shortest path possible and avoids obstacles. 
        if (m_finalPath != null)
        {
            m_transform.parent.position = Vector2.MoveTowards(m_transform.parent.position, m_destination, 2 * Time.deltaTime);

            float distance = Vector2.Distance(m_destination, m_transform.parent.position);

            if (distance <= 0f)
            {
                if (m_finalPath.Count > 0)
                {
                    m_current = m_destination;
                    m_destination = m_finalPath.Pop().m_worldPosition;
                }
                else 
                {
                    m_finalPath = null;
                }
            }
        }
    }
/* public void PathState::Update(); */

/**/
    /*
    PathState::PathToStack() PathState::PathToStack()

    NAME
        PathState::PathToStack - converts the node list to a stack

    SYNOPSIS
        Stack<Node> PathState::PathToStack(List<Node> a_path); 
            a_path -> list of nodes 
        
    DESCRIPTION
        This function is responsible for converting our list of nodes
        into a stack of nodes. This makes it simpler to pop off vector 
        positions that lead back to the player target. 

    RETURNS
        Stack of type Node

    AUTHOR
        Albert Carbillas

    DATE
        9/2/2019
    */
/**/
    Stack<Node> PathToStack(List<Node> a_path)
    {
        // create new stack
        Stack<Node> finalPath = new Stack<Node>();

        // if path exists 
        // then for every node in the list
        // push into the stack
        if (a_path != null)
        {
            foreach (Node n in a_path)
            {
                finalPath.Push(n);
            }

            return finalPath;
        }

        return null;
    }
/* Stack<Node> PathState::PathToStack(List<Node> a_path); */
}
