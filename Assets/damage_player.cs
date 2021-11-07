using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class damage_player : MonoBehaviour
{
    public GameObject event_system;
    public Volume volume;
    public float contrast_limit = 40f;
    ColorAdjustments color1;
    public int hit_count;
    public AudioSource sound;
    public AudioSource sound_crowd;
    public AudioSource lose_sound;

    private void Update()
    {
        if(hit_count >= 5)
        {
            event_system.GetComponent<GameController>().in_game = false;
            hit_count = 0;
            StartCoroutine(play_crowd());
            lose_sound.Play();
        }

        IEnumerator play_crowd()
        {
            yield return new WaitForSeconds(2f);
            sound_crowd.Play();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (volume.profile.TryGet<ColorAdjustments>(out color1))
        {
            if (other.tag == "clone")
            {
                contrast_limit = 90f;
                hit_count += 1;
                sound.Play();
                Destroy(other.gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (volume.profile.TryGet<ColorAdjustments>(out color1))
        {
            if (color1.contrast.value < contrast_limit)
            {
                color1.contrast.value += 4f;
            }
            if(color1.contrast.value >= contrast_limit)
            {
                contrast_limit = 40f;
            }
            if(color1.contrast.value > contrast_limit)
            {
                color1.contrast.value -= 4f;
            }
        }

    }
}
