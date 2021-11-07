using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box_hit : MonoBehaviour
{
    public GameObject cube_destroyed;

    
    public void box_is_hit()
    {
        Instantiate(cube_destroyed, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
