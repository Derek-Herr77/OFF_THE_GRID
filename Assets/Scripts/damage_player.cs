using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using TMPro;

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
    public GameObject notes;
    public List<string> notes_list = new List<string>();



    private void Start()
    {
        populate_list();
    }
    private void Update()
    {
        //game ends
        if(hit_count >= 5)
        {
            event_system.GetComponent<GameController>().in_game = false;
            StartCoroutine(play_crowd());
            lose_sound.Play();
            //call stuff for the notes
            StartCoroutine(note_play());
            hit_count = 0;
        }


        IEnumerator note_play()
        {
            notes.SetActive(true);
            string note = notes_list[Random.Range(0, notes_list.Count - 1)];
            notes.GetComponent<TextMeshProUGUI>().text = note;
            yield return new WaitForSeconds(8f);
            notes.SetActive(false);
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

    public void populate_list()
    {
        notes_list.Add("WOW! YOU'RE REALLY GOOD AT THIS!");
        notes_list.Add("NICE TRY BUCKO!");
        notes_list.Add("SICK MOVES AL PACINO!");
        notes_list.Add("SICK TRICKS! TRY AGAIN!");
        notes_list.Add("I'M VERY SLEEP DEPRIVED!");
        notes_list.Add("NICE JOB! I THINK YOU'RE PRETTY COOL!");
        notes_list.Add("ARE YOU FAMOUS!?");
    }


}
