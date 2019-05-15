using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using MultiplayerSystem;
using System;

namespace PlayerSystem
{
    public class PlayerView : MonoBehaviour
    {          
        public void OnMoveForward(Vector3 newPosition)
        {
            //Debug.Log("OnMoveForward Signal");
            transform.position = Vector3.Lerp(transform.position, newPosition, 1);        
        }
        public void OnMoveBackward(Vector3 newPosition)
        {            
            transform.position = Vector3.Lerp(transform.position, newPosition, 1);        
        }

        public void DestroySelf()
        {
            Destroy(this.gameObject);
        }
        public void SpawnBullet(Vector3 velocity)
        {
            Debug.Log("spawn bullet called");
        }
        public Vector3 GetCurrentPosition()
        {
            return this.transform.position;
        }
    }
}