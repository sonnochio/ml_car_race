using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colEnter : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {

        other.gameObject.GetComponent<VehicleBehaviour.carAgent>().CollisionPunishment();


    }



}
