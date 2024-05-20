/*
 * Author: Wang Johnathan Zhiwen
 * Date: 19/05/2024
 * Description: 
 * This is the player character
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject coolTextbox;

    // Current score
    int currentScore = 0;

    //current door
    Door currentDoor;

    //current collectible
    Collectible currentCollectible;


    // This is for increasing the score then deleting the collected collectible
    public void IncreaseScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.text = currentScore.ToString() + " / 5";
        if (currentScore == 5)
            coolTextbox.SetActive(true);
    }


    public void UpdateDoor(Door newDoor)
    {
        currentDoor = newDoor;
    }

    public void UpdateCollectible(Collectible newCollectible)
    {
        currentCollectible = newCollectible;
    }

    //When player interact
    public void OnInteract()
    {
        // with Door
        if (currentDoor != null)
        {
            currentDoor.OpenDoor();
            currentDoor = null;
        }
        // with collectible
        if (currentCollectible != null)
        {
            IncreaseScore(currentCollectible.myScore);
            currentCollectible.Collected();
        }
    }

}
