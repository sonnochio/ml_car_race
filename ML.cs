using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

namespace VehicleBehaviour
{
    public class ML : Agent
    {

        private WheelVehicle wheelVehicle;
        public Vector3 startingPos = new Vector3(5, 2, 30);

        private void Start()
        {
            wheelVehicle = FindObjectOfType<WheelVehicle>();
            Debug.Log("hi");
        }

        public override void OnEpisodeBegin()
        {

        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            var input = actions.ContinuousActions;
            wheelVehicle.throttle = input[0];
            wheelVehicle.steering = input[1];
            //AddReward(wheelVehicle.Speed * .001f);

        }


        public override void Heuristic(in ActionBuffers actionsOut)
        {


            var action = actionsOut.ContinuousActions;

            action[0] = Input.GetAxis("Throttle")*2;
            action[1] = Input.GetAxis("Steering")*40;
            //Debug.Log(action[0]);
            //Debug.Log("steering"+action[1]);

        }


        //public override void OnActionReceived(float[] vectorAction)
        //{
        //    base.AgentAction(vectorAction);
        //    wheelVehicle.Throttle = vectorAction[0];
        //    wheelVehicle.Steering = vectorAction[1];
        //    AddReward(wheelVehicle.Speed * .001f);
        //}

    }
}

