using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTime : MonoBehaviour
{
    private Animator anim;
    public int value = 6;
    
    private bool inTrigger;
    public PlayerMovement player;
    private bool crounching;
    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // Desactiva la animación al inicio
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        crounching = player.isCrouching;
        if(inTrigger && crounching){
            timer.AddSeconds(value);
            inTrigger=false;
            Destroy(this.gameObject);
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

    
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            inTrigger = true;
            crounching = player.isCrouching;
            if(inTrigger && crounching){
                timer.AddSeconds(value);
                inTrigger=false;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision.CompareTag("Player")){
            inTrigger=false;
        }
    }
}
