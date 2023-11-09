using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class SecondMiniManager : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public TextMeshProUGUI textPercent;
    private bool space; 
    private int percent;
    private float tiempoInicial;

    //tecla que se debe presionar
    private void KeyToPress(){
        int rand = Random.Range(0, 2);
        if(rand == 0){
            texto.text = " 'S' ";
            space = false;
        }else{
            texto.text = " 'Espacio' ";
            space = true;
        }
    }

    private void ChangeText(){
        float tiempoTranscurrido = Time.time - tiempoInicial;
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);
         
        if (segundos > 1){
            tiempoInicial = Time.time;
            KeyToPress();
        }
    }

    private void Anim(){
        if( space ){
            if(Input.GetKeyDown(KeyCode.Space)){
                GetComponent<Animator>().SetTrigger("correcto");
                KeyToPress();
                percent += 15;
                tiempoInicial = Time.time;
                texto.text = " ";
            }else if(Input.GetKeyDown(KeyCode.S)){
                GetComponent<Animator>().SetTrigger("incorrecto");
                KeyToPress();
                tiempoInicial = Time.time;
                texto.text = " ";
            }

        }else{
            if(Input.GetKeyDown(KeyCode.S)){
                GetComponent<Animator>().SetTrigger("correcto");
                KeyToPress();
                percent += 15;
                tiempoInicial = Time.time;
                texto.text = " ";
            }else if(Input.GetKeyDown(KeyCode.Space)){
                GetComponent<Animator>().SetTrigger("incorrecto");
                KeyToPress();
                tiempoInicial = Time.time;
                texto.text = " ";
            }
        }
        textPercent.text = "Porcentaje: " + percent + "%";
    }

    

    // Start is called before the first frame update
    void Start()
    {
        tiempoInicial = Time.time;
        KeyToPress();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(percent > 100){
            texto.text = " ";
            textPercent.text = " ";
            GetComponent<Animator>().SetTrigger("termina");
        }else{
            ChangeText();
            Anim();
        }
        
        
    }
}
