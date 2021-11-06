using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public float game_time;
    public bool in_game;
    private float seconds = 55;
    private int minutes;
    public TextMeshProUGUI timer;
    public Animator canvus_animator;
    public Animator title_animator;
    // Start is called before the first frame update
    void Start()
    {
        in_game = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            in_game = !in_game;
        }
        if (in_game)
        {
            title_animator.SetBool("is_playing", true);
            if (!timer.enabled)
            {
                timer.enabled = true;
            }
            seconds += Time.deltaTime;
            if (seconds >= 60)
            {
                minutes += 1;
                seconds = 0;
            }
            timer.SetText("0{0}.{1:2}", minutes, seconds);
        }
        else
        {
            title_animator.SetBool("is_playing", false);
        }
    }
}
