using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

    // Use this for initialization

    public Transform Player;
    public Vector3 offset;

   
    void Update()
    {
        transform.position = new Vector3(Player.position.x + offset.x, 
            Player.position.y + offset.y, offset.z);
    }
}
