using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerDeathCheck : MonoBehaviour
{

    public ParticleSystem deadParticle;
    public TrailRenderer playerTrail;
    private AudioManager audioManager;
    ButtonsTransition buttonTransition;
    PlayerInput playerInput;
    Vector2 startPos;
    Rigidbody2D rbplayer;
    public bool isdead;
    private void Awake()
    {
        rbplayer = GetComponent<Rigidbody2D>();
        //game = FindObjectOfType<GameUI>();
        playerInput = FindObjectOfType<PlayerInput>();
        buttonTransition = FindObjectOfType<ButtonsTransition>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {   
        startPos = transform.position;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            Die();
        }

    }
    void Die()
    {
        isdead = true;
        rbplayer.simulated = false;
        playerInput.playerControls.Disable();
        playerInput.Move = 0;
        buttonTransition.DisableButtons();
        StartCoroutine(Respawn(0.5f));
        playerTrail.enabled = false;
        PlayDeadParticles();
    }

    IEnumerator Respawn(float duration)
    {
        transform.localScale = new Vector3(0, 0, 0);
        rbplayer.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(duration);
        //SceneController.instance.Restart();
        deadParticle.Clear();
        transform.position = startPos;
        transform.localScale = new Vector3(1, 1, 1);
        buttonTransition.Enablebuttons();
        playerInput.playerControls.Enable();
        rbplayer.simulated = true;
        playerTrail.enabled = true;
        isdead = false;
    }
    private void PlayDeadParticles()
    {
        audioManager.PlaySFX(audioManager.death);
        deadParticle.transform.position = transform.position;
        deadParticle.Play();
    }
    private void Update()
    {
        if(transform.position.y <-10f && !isdead)
        {
            Die();
        }
    }


}


