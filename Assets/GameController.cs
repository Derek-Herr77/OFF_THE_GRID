using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public float total_gameTime;
    public bool in_game;
    public float seconds = 0;
    private int minutes;
    public TextMeshProUGUI timer;
    public Animator canvus_animator;
    public Animator title_animator;
    public Animator start_animator;
    public bool has_waited = false;
    public AudioSource start_sound;

    // Start is called before the first frame update
    void Start()
    {
        in_game = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (in_game)
        {
            title_animator.SetBool("is_playing", true);
            canvus_animator.SetBool("is_playing", true);
            start_animator.SetBool("is_playing", true);

            if (has_waited)
            {
                seconds += Time.deltaTime;
                total_gameTime += Time.deltaTime;
                if (seconds >= 60)
                {
                    minutes += 1;
                    seconds = 0;
                }
                if(seconds < 10)
                {
                    timer.SetText("0{0}.0{1:2}", minutes, seconds);
                }
                else
                {
                    timer.SetText("0{0}.{1:2}", minutes, seconds);
                }
            }
            else { StartCoroutine(game_wait()); }



            IEnumerator game_wait()
            {
                timer.SetText("0{0}.0{1:2}", minutes, seconds);
                yield return new WaitForSeconds(3f);
                has_waited = true;
            }


        }
        else
        {
            has_waited = false;
            title_animator.SetBool("is_playing", false);
            canvus_animator.SetBool("is_playing", false);
            start_animator.SetBool("is_playing", false);
            var clones = GameObject.FindGameObjectsWithTag("clone");
            foreach (var clone in clones)
            {
                clone.GetComponent<box_hit>().box_is_hit();
            }

            seconds = 0;
            minutes = 0;
            total_gameTime = 0;
        }
    }

    public void start()
    {
        in_game = true;
        start_sound.Play();
    }
}
