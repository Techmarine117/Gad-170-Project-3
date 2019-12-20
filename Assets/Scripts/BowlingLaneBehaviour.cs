using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple bowling lane logic, is triggered externally by buttons that are routed
/// to the InitialiseRound, TalleyScore and ResetRack.
/// 
/// Future work;
///   Use the timer in update to limit how long a player has to bowl,
///   Detect that the player/ball is 'bowled' from behind the line
/// </summary>
public class BowlingLaneBehaviour : MonoBehaviour
{
    public GameObject pinPrefab;
    public GameObject bowlingBall;
    public Transform[] pinSpawnLocations;
    public Transform defaultBallLocation;
    private GameObject[] bowlingPins = new GameObject[0];
    public int Score = 0;



    [ContextMenu("InitialiseRound")]
    public void InitialiseRound()
    {
        bowlingPins = new GameObject[pinSpawnLocations.Length];
        int i = 0;
        foreach (var pinLoc in pinSpawnLocations)
        {
            bowlingPins[i] = Instantiate(pinPrefab, pinLoc.position, pinLoc.rotation);
            i++;
        }

    }
    // added code for ball to reset when it hits the end of the lane

    public void BallReachedEnd()
    {
        bowlingBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bowlingBall.transform.position = defaultBallLocation.position;

    }

    [ContextMenu("TalleyScore")]
    public void TalleyScore()
    {
        //TODO; determine score and get that information out to a checklist item, either via event or directly
        // added code to tally the score
        if (bowlingPins.Length != 0)
        {
            int i = 0;
            foreach (var item in bowlingPins)
            {
                if (bowlingPins[i].transform.position != pinSpawnLocations[i].position)
                {
                    Score++;
                }
                i++;
            }
        }
        GameObject.FindGameObjectWithTag("BowlingScore").GetComponent<InteractiveItem>().UseNotHeldMessage.messageBody = "Bowling Score: " + Score.ToString();


    }


    [ContextMenu("ResetRack")]
    public void ResetRack()
    {
        bowlingBall.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bowlingBall.transform.position = defaultBallLocation.position;
        if (bowlingPins.Length != 0)
        {
            foreach (var item in bowlingPins)
            {
                Destroy(item);
            }
        }
        bowlingPins = new GameObject[0];

    }

    protected void Update()
    {
        
    }
}
