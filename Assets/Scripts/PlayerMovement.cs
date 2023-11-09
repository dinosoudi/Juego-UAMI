using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeedX = -120;
    public float playerSpeedY;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public bool isCrouching = false;
    private bool isJumping = false;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        AnimationEvent animationEvent = new AnimationEvent
        {
            functionName = "AnimacionTerminada" // Nombre de la función a llamar cuando se dispare el evento
        };
        animationEvent.time = 2; // Cuando la animación llegue al final
        anim.runtimeAnimatorController.animationClips[5].AddEvent(animationEvent); // Ajusta esto según la posición de tu animación en la lista de clips
        anim.runtimeAnimatorController.animationClips[4].AddEvent(animationEvent);
        anim.runtimeAnimatorController.animationClips[3].AddEvent(animationEvent);
        //son interactuar, flexiones y tenis
        //Debug.Log("tiempo: " + anim.GetCurrentAnimatorClipInfo(0));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + playerSpeedX * Time.deltaTime,
            transform.position.y + playerSpeedY * Time.deltaTime);

        // Comprobar si el jugador está tocando el suelo.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 73f, groundLayer);

        // Salto
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }

        // Agacharse
        if (isGrounded && Input.GetKey(KeyCode.DownArrow))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }

        // Animaciones
        anim.SetBool("IsJumping", isJumping);
        anim.SetBool("IsCrouching", isCrouching);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isJumping = false; // Si el personaje colisiona con el suelo, indica que ya no esta saltando.
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Left Wall")){
            SceneManager.LoadScene(2);
        }
    }
    

    public void AnimCrunch(int animation){
        if(animation==2){
            GetComponent<Animator>().SetTrigger("PushUp");
        }else if (animation==1){
            GetComponent<Animator>().SetTrigger("Interact");
        }else{
            GetComponent<Animator>().SetTrigger("Tennis");
        }
        playerSpeedX = 0;
    }

    private void AnimacionTerminada()
    {
        //Debug.Log("Animacion terminada");
        playerSpeedX = -120;
    }

}
