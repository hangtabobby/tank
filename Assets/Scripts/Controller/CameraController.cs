using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = new Vector3(
            Player.Instance.transform.position.x,
            Player.Instance.transform.position.y,
            -10);
        transform.position = cameraPos;
    }
}
 