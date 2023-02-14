using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckPoints : MonoBehaviour
{
    public List<CheckPointSingle> checkPointScreens;

    private void Awake()
    {
        List<CheckPointSingle> checkPoints = new List<CheckPointSingle>(GetComponentsInChildren<CheckPointSingle>());

        Debug.Log(checkPoints.Count);

        checkPointScreens = checkPoints.Where(cp => cp.gameObject.name == "checkPointScreen").ToList();

        Debug.Log("correnct    "+ checkPointScreens.Count);

        //checkPointScreens = new List<GameObject>();

        //CheckPointSingle checkPointScreen = null;

        //foreach (CheckPointSingle checkPoint in checkPoints)
        //{
        //    if (checkPoint.gameObject.name == "checkPointScreen")
        //    {
        //        checkPointScreen = checkPoint;
        //        break;
        //    }
        //}

    }
}