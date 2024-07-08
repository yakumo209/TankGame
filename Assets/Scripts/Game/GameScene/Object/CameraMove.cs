using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform targerPlayer;

    private Vector3 pos;

    public float H = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (targerPlayer==null)
        {
            return;
        }

        pos.x = targerPlayer.position.x;
        pos.z = targerPlayer.position.z;
        pos.y = H;
        this.transform.position = pos;
    }
}
