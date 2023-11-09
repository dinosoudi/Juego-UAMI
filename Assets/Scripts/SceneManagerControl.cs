using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;   
 
public class SceneManagerControl : MonoBehaviour
{
    // Función para cambiar de escena utilizando el número de la escena
    public void ChangeSceneByIndex(int sceneIndex)
    {
        // Asegúrate de que el índice de la escena sea válido
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Cargar la escena por su índice
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogError("Índice de escena no válido: " + sceneIndex);
        }
    }
}
