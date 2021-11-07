using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class gun_fire : MonoBehaviour
{
    public ParticleSystem bullet, flash;
    public Animator animator;
    public InputActionReference fire_reference = null;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        fire_reference.action.started += fire_gun;

        animator.Play("gun_fire");
    }

    public void fire_gun(InputAction.CallbackContext context)
    {
        animator.Play("gun_fire", -1, 0f);
        bullet.Play();
        flash.Play();
        sound.Play();
    }
}
