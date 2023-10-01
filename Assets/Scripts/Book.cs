using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    private Animator anim;
    public int value = 5;
    public GameManager gameManager;

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
            gameManager.addPoints(value);
            Destroy(this.gameObject);
        }
    }
}
