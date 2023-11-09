using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 

public class MiniGameManager : MonoBehaviour
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
            texto.text = " Presiona la tecla: 'S' ";
            space = false;
        }else{
            texto.text = " Presiona la tecla 'espacio' ";
            space = true;
        }
    }

    private void ChangeText(){
        float tiempoTranscurrido = Time.time - tiempoInicial;
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);
         
        if (segundos > 1){
            //GetComponent<Animator>().SetTrigger("sleep");
            tiempoInicial = Time.time;
            KeyToPress();
        }
    }

    private void StudyingAnim(){
        if( space ){
            if(Input.GetKeyDown(KeyCode.Space)){
                GetComponent<Animator>().SetTrigger("studying");
                KeyToPress();
                percent += 15;
                tiempoInicial = Time.time;
                texto.text = " ";
            }else if(Input.GetKeyDown(KeyCode.S)){
                GetComponent<Animator>().SetTrigger("sleep");
                KeyToPress();
                tiempoInicial = Time.time;
                texto.text = " ";
            }

        }else{
            if(Input.GetKeyDown(KeyCode.S)){
                GetComponent<Animator>().SetTrigger("studying");
                KeyToPress();
                percent += 15;
                tiempoInicial = Time.time;
                texto.text = " ";
            }else if(Input.GetKeyDown(KeyCode.Space)){
                GetComponent<Animator>().SetTrigger("sleep");
                KeyToPress();
                tiempoInicial = Time.time;
                texto.text = " ";
            }
        }
        textPercent.text = "Porcentaje: " + percent;
    }

    private void FireAnim(){
        if( space ){
            if(Input.GetKeyDown(KeyCode.Space)){
                GetComponent<Animator>().SetTrigger("fire");
                KeyToPress();
                percent += 20;
                tiempoInicial = Time.time;
                texto.text = " ";
            }else if(Input.GetKeyDown(KeyCode.S)){
                GetComponent<Animator>().SetTrigger("sleep");
                KeyToPress();
                tiempoInicial = Time.time;
                texto.text = " ";
            }
        }else{
            if(Input.GetKeyDown(KeyCode.S)){
                GetComponent<Animator>().SetTrigger("fire");
                KeyToPress();
                percent += 20;
                tiempoInicial = Time.time;
                texto.text = " ";
            }else if(Input.GetKeyDown(KeyCode.Space)){
                GetComponent<Animator>().SetTrigger("sleep");
                KeyToPress();
                tiempoInicial = Time.time;
                texto.text = " ";
            }
        }
        if(percent < 100){
            textPercent.text = "Porcentaje: " + percent + "%";
        }else{
            textPercent.text = "Porcentaje: 100%";
        }
        
    }

    void Start()
    {
        tiempoInicial = Time.time;
        KeyToPress();
    }

    void Update()
    {
        ChangeText();

        if(percent < 45){
            StudyingAnim();
        }else if(percent > 100){
            SceneManager.LoadScene(3);
        }else{
            FireAnim();
        }
    }
}
