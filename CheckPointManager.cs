using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckPointManager : MonoBehaviour
{


    public float MaxTimeToReachNextCheckpoint = 30f;
    public float TimeLeft = 30f;

    public VehicleBehaviour.carAgent carAgent;


    public CheckPointSingle nextCheckPointToReach;

    private int CurrentCheckpointIndex;
    private List<CheckPointSingle> Checkpoints;
    private CheckPointSingle lastCheckpoint;
    public event Action<CheckPointSingle> reachedCheckpoint;

    public List<CheckPointSingle> checkPointScreens;
    public List<CheckPointSingle> ScreensReached;


    // Start is called before the first frame update
    void Awake()
    {
        Checkpoints = FindObjectsOfType<CheckPointSingle>().ToList();

        checkPointScreens = FindObjectOfType<CheckPoints>().checkPointScreens;
        Debug.Log("checkpoints count is " + checkPointScreens.Count);

        ScreensReached = new List<CheckPointSingle>();
        //Debug.Log("ScreensReached is  " + ScreensReached);
        Debug.Log("ScreensReached is  " + ScreensReached.Count());


        //Test if there's duplicates in the checkPointScreens

        //bool hasDuplicates = Checkpoints.Count != Checkpoints.Distinct().Count();
        //if (hasDuplicates)
        //{
        //    Debug.Log("There are duplicate objects in the list");
        //}
        //else
        //{
        //    Debug.Log("There are no duplicate objects in the list");
        //}

        //foreach (var x in checkPointScreens)
        //{
        //    Debug.Log(x);
        //}

        ResetCheckpoints();

        carAgent = GetComponent<VehicleBehaviour.carAgent>();
        //Debug.Log("carAgent is " + carAgent);

    }

    public void ResetCheckpoints()
    {
        CurrentCheckpointIndex = 0;
        TimeLeft = MaxTimeToReachNextCheckpoint;
        SetNextCheckpoint();
    }

    private void Update()
    {
        TimeLeft -= Time.deltaTime;
        //Debug.Log("Timeleft is " + TimeLeft);
        if (TimeLeft < 0f)
        {
            carAgent.AddReward(-1f);
            carAgent.EndEpisode();
        }
    }
    
    public void CheckPointReached(CheckPointSingle checkpoint)
    {
        //Debug.Log("CurrentCheckpointIndex" + CurrentCheckpointIndex);
        //Debug.Log("nextCheckPointToReach" + nextCheckPointToReach);

        //if (nextCheckPointToReach != checkpoint) return;


        //lastCheckpoint = Checkpoints[CurrentCheckpointIndex];
        //Debug.Log("lastCheckpoint" + lastCheckpoint);

        //reachedCheckpoint?.Invoke(checkpoint);
        //Debug.Log("reachedCheckpoint" + reachedCheckpoint);

        //CurrentCheckpointIndex++;
        //Debug.Log("CurrentCheckpointIndex" + CurrentCheckpointIndex);

        if (!ScreensReached.Contains(checkpoint))
        {
            ScreensReached.Add(checkpoint);
            Debug.Log("added new checkpoint, total checkpoints is now " + ScreensReached.Count());

        }
        else
        {
            return;
        }






        if (CurrentCheckpointIndex >= Checkpoints.Count)
        {
            carAgent.AddReward(0.5f);
            carAgent.EndEpisode();
        }
        else
        {
            carAgent.AddReward((0.5f) / Checkpoints.Count);
            SetNextCheckpoint();
            Debug.Log("next check point set");
        }
    }

    private void SetNextCheckpoint()
    {

        
        if (Checkpoints.Count > 0)
        {
            TimeLeft = MaxTimeToReachNextCheckpoint;
            nextCheckPointToReach = Checkpoints[CurrentCheckpointIndex];

        }
    }


}
