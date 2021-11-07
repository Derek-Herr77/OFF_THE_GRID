using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject event_system;
    public GameObject cube;
    public float spawn_time = 1f;
    public float cube_speed;
    private bool spawning = false;
    private Vector3 pos;
    private float randx;
    private float randy;
    // Update is called once per frame


    private void FixedUpdate()
    {
        spawn_time = spawn_time - 0.00010f;
    }
    void Update()
    {
        if (event_system.GetComponent<GameController>().in_game && event_system.GetComponent<GameController>().has_waited)
        {

            if (spawning == false)
            {
                StartCoroutine(spawn());
            }
            IEnumerator spawn()
            {
                spawning = true;
                yield return new WaitForSeconds(spawn_time);
                randx = Random.Range(-7f, 7f);
                randy = Random.Range(0f, 3f);
                pos = new Vector3(randx, randy, 0);
                Instantiate(cube, transform.position + pos, transform.rotation);
                spawning = false;
            }
        }
        else
        {
            spawn_time = 1f;
        }
    }
}
