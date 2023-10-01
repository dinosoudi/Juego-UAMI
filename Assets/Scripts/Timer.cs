using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textoCronometro;
    private float tiempoInicial;
    private bool cronometroActivo = false;
    private int extraSeconds = 0;

    void Start()
    {
        tiempoInicial = Time.time;
        IniciarCronometro();
    }

    void Update()
    {
        if (cronometroActivo)
        {
            float tiempoTranscurrido = Time.time - tiempoInicial;
            tiempoTranscurrido = tiempoTranscurrido - extraSeconds;
            int minutos = 9 + Mathf.FloorToInt(tiempoTranscurrido / 60);
            int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);

            string textoTiempo = string.Format("{0:00}:{1:00}", minutos, segundos);
            textoCronometro.text = textoTiempo + " am";
        }
    }

    public void IniciarCronometro()
    {
        cronometroActivo = true;
        tiempoInicial = Time.time;
    }

    public void DetenerCronometro()
    {
        cronometroActivo = false;
    }

    public void AddSeconds(int addSeconds){
        extraSeconds = extraSeconds + addSeconds;
    }
}
