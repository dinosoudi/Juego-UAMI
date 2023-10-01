using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int TotalPoints{ get{return totalPoints;} }
    private int totalPoints = 0;
    public TextMeshProUGUI points;
    

    public void addPoints(int pointsToAdd){
        totalPoints = totalPoints + pointsToAdd;
        points.text = "Puntaje: " + TotalPoints.ToString();
    }

    

    

    

}
