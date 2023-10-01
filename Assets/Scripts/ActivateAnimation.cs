using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimation : MonoBehaviour
{
    private Animator anim;
    public PlayerMovement player;
    private bool crounching;
    private bool inTrigger;
    public bool onlyTouch;
    public int intAnimation;
    public Timer timer;
    public bool lessTime = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        // Desactiva la animación al inicio
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!onlyTouch){
            crounching = player.isCrouching;
            if(inTrigger && crounching){
                GetComponent<Animator>().SetTrigger("Interact");
                player.AnimCrunch(intAnimation);
                if(lessTime){
                    timer.AddSeconds(-2);
                }
                inTrigger=false;
            }
        }
    }

     private void OnBecameVisible()
    {
        // Cuando el objeto es visible en la cámara, activa la animación
        anim.enabled = true;
    }

    private void OnBecameInvisible()
    {
        // Cuando el objeto ya no es visible en la cámara, desactiva la animación
        anim.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inTrigger = true;
            if(onlyTouch){
                // está saltando
                GetComponent<Animator>().SetTrigger("Interact");
                if(lessTime){
                    timer.AddSeconds(-2);
                }
            }else{
                // interactua si está agachado:
                crounching = player.isCrouching;
                if(inTrigger && crounching){
                    GetComponent<Animator>().SetTrigger("Interact");
                    player.AnimCrunch(intAnimation);
                    if(lessTime){
                        timer.AddSeconds(-2);
                    }
                    inTrigger=false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            inTrigger=false;
        }
    }
}
