using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RoundScript : MonoBehaviour {

    private DateTime currentTime = new DateTime(1, 1, 1);

    private Dictionary<int, int> playerNumScoreMap = new Dictionary<int, int>();

    public enum GameStatus
    {
        Paused,
        Active
    }
    private GameStatus gameStatus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void FixedUpdate ()
    {
        //if (isServer)
        {
            if (gameStatus != GameStatus.Paused)
            {
                currentTime = currentTime.AddSeconds(Time.fixedDeltaTime);
            }
            Debug.Log(currentTime.ToLongTimeString());
        }
    }

    internal void AddPointsToPlayerNum(int points, int playerNum)
    {
        playerNumScoreMap[playerNum] += points;
    }
    internal void RemovePointsFromPlayerNum(int points, int playerNum)
    {
        AddPointsToPlayerNum(points * -1, playerNum);
    }

    internal void PauseGame()
    {
        gameStatus = GameStatus.Paused;
    }
    internal void UnpauseGame()
    {
        gameStatus = GameStatus.Active;
    }
}
