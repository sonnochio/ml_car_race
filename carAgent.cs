using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

namespace VehicleBehaviour
{
    public class carAgent : Agent
    {
        //private WheelVehicle[] wheelVehicles;
        private WheelVehicle wheelVehicle;
        public CheckPointManager checkpointManager;

        //private WheelVehicle wheelVehicle;
        public Vector3 startingPos = new Vector3(5, 2, 30);

        public override void OnEpisodeBegin()
        {

            Respawn();
            Debug.Log("agent initiated");


            checkpointManager = GetComponent<CheckPointManager>(); 

            if (checkpointManager)
            {
                //Debug.Log("checkpointManager not null");
                //Debug.Log(checkpointManager);

            }
            checkpointManager.ResetCheckpoints();
            //Debug.Log("MAX TIME is" + checkpointManager.MaxTimeToReachNextCheckpoint);
        }

        public void CollisionPunishment()
        {
            AddReward(-0.2f);
            Debug.Log("punished the car");
        }

        public void Respawn()
        {
            transform.position = RandomRespawn();
            transform.rotation = Quaternion.identity;
            wheelVehicle = GetComponent<WheelVehicle>();
            wheelVehicle.rb.velocity = Vector3.zero;
            wheelVehicle.rb.angularVelocity = Vector3.zero;
        }

        public Vector3 RandomRespawn()
        {
            return new Vector3(Random.Range(-1, 12), 2, Random.Range(30, 35));
        }

        public override void CollectObservations(VectorSensor sensor)
        {
 

            //allows short term memory and 
            Vector3 diff = checkpointManager.nextCheckPointToReach.transform.position - transform.position;
            sensor.AddObservation(diff / 20f);
            AddReward(-0.001f);
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            var input = actions.ContinuousActions;

            //for (int i = 0; i < wheelVehicles.Length; i++)
            //{
            //    wheelVehicles[i].throttle = input[0];
            //    wheelVehicles[i].steering = input[1] * 40;
            //}

            wheelVehicle.throttle = input[0];
            wheelVehicle.steering = input[1] * 20;

            if (wheelVehicle.Speed > 0)
            {
                AddReward(0.001f);
            }
        }


        public override void Heuristic(in ActionBuffers actionsOut)
        {

            var action = actionsOut.ContinuousActions;

            action[0] = Input.GetAxis("Throttle");
            //Debug.Log("action1" + action[0]);

            action[1] = Input.GetAxis("Steering");
            //Debug.Log("action2" + action[1]);

        }



    }
}

