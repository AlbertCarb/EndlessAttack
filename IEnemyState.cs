using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the interface to access and manipulate the enemy's different states

public interface IEnemyState 
{
   void Enter(Enemy a_enemy); // Function for entering a state
   void Update(); // function for updating what the state is doing 
   void Exit(); // function for performing an exit action when leaving the state
}
