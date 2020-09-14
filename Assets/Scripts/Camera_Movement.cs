using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles camera movement
public class Camera_Movement : MonoBehaviour
{
    // Public Variables
    public GameObject player;
    public float interpSpeed;

    // Private Variables
    private Vector3 playerPos;

    // Update is called once per frame
    void LateUpdate()
    {
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, playerPos, interpSpeed);
    }
}
