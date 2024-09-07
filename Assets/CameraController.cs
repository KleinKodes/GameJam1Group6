using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Follow script based on this tutorial: https://www.youtube.com/watch?v=Ul01SxwPIvk
public class CameraController : MonoBehaviour
{
    
    public Transform player;
    public float rot_smoothing = 0.1f;
    public float pos_smoothing = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, pos_smoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, rot_smoothing);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
