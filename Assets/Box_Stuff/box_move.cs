using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_move : MonoBehaviour
{
    public GameObject event_system;
    private float box_speed;
    public float timeNow;
    // Update is called once per frame

    private void Start()
    {
        event_system = GameObject.Find("EventSystem");
    }
    void Update()
    {
        timeNow = event_system.GetComponent<GameController>().total_gameTime;
        box_speed = timeNow / 5;
        transform.Translate(-Vector3.forward * Time.deltaTime * box_speed);
    }
}
