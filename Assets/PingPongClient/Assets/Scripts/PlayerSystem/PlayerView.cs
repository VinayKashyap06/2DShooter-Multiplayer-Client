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
        
        private SignalBus signalBus;
      
        public void SetSignalBus(SignalBus signalBus)
        {
            this.signalBus = signalBus;
            signalBus.Subscribe<OnMoveForwardSignal>(OnMoveForward);            
        }

        private void OnMoveForward(OnMoveForwardSignal onMoveForwardSignal)
        {            
            transform.position = Vector3.Lerp(transform.position, onMoveForwardSignal.GetNewPosition(), 1);        
        }
    }
}