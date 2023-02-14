using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSingle : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("collided with the checkpoint");
        other.transform.parent.parent.parent.GetComponent<CheckPointManager>().CheckPointReached(this);

        //other.GetComponent<CheckPointManager>().CheckPointReached(this);


       
    }

}
