using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public static TurnManager turnManagerInstance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void EndTurn()
    {
        Debug.Log("End Turn CLicked");
        
        // Compute this 
        PlayerManager.playerInstance.ComputePlayerBuildingsTask();

        //Update infos
        UIColonyManager.uiColonyManagerInstance.UpdateColonyResourcesImage();


        // Check for Combat initiated by player

        // Compute Enemies Tasks

        // Check for combat initiated by enemies
    }
}
