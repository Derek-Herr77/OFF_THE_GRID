using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_move : MonoBehaviour
{
    private float box_speed;
    public float timeNow;
    // Update is called once per frame
    void Update()
    {
        timeNow = Time.realtimeSinceStartup;
        box_speed = timeNow / 4;
        transform.Translate(-Vector3.forward * Time.deltaTime * box_speed);
    }
}
