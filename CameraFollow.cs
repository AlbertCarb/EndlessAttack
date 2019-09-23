using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    private Transform m_target; // the target the camera will follow 
    private float m_XMax; // maximum x value it will follow 
    private float m_xMin; // minimum x value it will follow 
    private float m_yMax; // maximum y value it will follow 
    private float m_yMin; // minimum y value it will follow 
    private Player player; // player reference

    [SerializeField] // serialize fields allows use to manipulate private data in our engine's UI 
    private Tilemap tilemap; // reference to the world environment

/**/
    /*
    CameraFollow::Start() CameraFollow::Start()

    NAME
        CameraFollow::Start - initializes the CameraFollow class objects

    SYNOPSIS
        void CameraFollow::Start(); 
        
    DESCRIPTION
        This function is responsible for acting as a constructor for the CameraFollow
        class objects. This is a Unity specific function that initializes certain 
        object attributes on startup. For this class, it initalizes certain 
        CameraFollow-specific stats and calls back the base class Start function.
        
        Start is called before the first frame update.

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        3/12/2019
    */
/**/
    void Start()
    {
        // references our player object and sets it to our target
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
        player = m_target.GetComponent<Player>();

        // sets a bound to the camera's movement 
        Vector3 minTile = tilemap.CellToWorld(tilemap.cellBounds.min);
        Vector3 maxTile = tilemap.CellToWorld(tilemap.cellBounds.max);

        // sets the limits relative to the player's position 
        SetLimits(minTile, maxTile);
        player.SetLimits(minTile, maxTile);
    }
/* void CameraFollow::Start(); */

/**/
    /*
    CameraFollow::LateUpdate() CameraFollow::LateUpdate()

    NAME
        CameraFollow::LateUpdate - updates the state of the CameraFollow class objects 

    SYNOPSIS
        private void CameraFollow::LateUpdate(); 
        
    DESCRIPTION
        This function is responsible for acting as an updater for the 
        state of the CameraFollow class' objects by checking its current 
        state and values frame by frame. The values and states that are to be 
        tracked are specified in the body of the function. 

        This first makes the necessary updates for CameraFollow-specific values.
        
        LateUpdate is called once per frame after all regular Updates have been made. 
        This is important for camera follow so the camera can move after any possible 
        object movement. 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        3/12/2019
    */
/**/
    private void LateUpdate()
    {
        // the transform position will be updated every frame to move where the player has moved
        transform.position = new Vector3(Mathf.Clamp(m_target.position.x, m_xMin, m_XMax), Mathf.Clamp(m_target.position.y, m_yMin, m_yMax), -10);
    }
/* void CameraFollow::LateUpdate(); */

/**/
    /*
    CameraFollow::SetLimits() CameraFollow::SetLimits()

    NAME
        CameraFollow::SetLimits - sets camera bounds relative to the player 

    SYNOPSIS
        private void CameraFollow::SetLimits(Vector3 a_minTile, Vector3 a_maxTile); 
            a_minTile -> the minimum tile the camera will capture 
            a_maxTile -> the maximum tile the camera will capture 
        
    DESCRIPTION
        This function is responsible for setting camera boundaries relative 
        to player's position. This will allow us to lock the position and have the camera 
        follow the player as the player moves. 

    RETURNS
        ((void))

    AUTHOR
        Albert Carbillas

    DATE
        3/12/2019
    */
/**/
    private void SetLimits(Vector3 a_minTile, Vector3 a_maxTile)
    {
        Camera cam = Camera.main; 

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        
        m_xMin = a_minTile.x + width / 2;
        m_XMax = a_maxTile.x - width / 2;
        m_yMin = a_minTile.y + height / 2;
        m_yMax = a_maxTile.y - height / 2;
    }
/* private void CameraFollow::SetLimits(Vector3 a_minTile, Vector3 a_maxTile); */
}
