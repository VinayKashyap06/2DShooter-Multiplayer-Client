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
        [Inject]
        private SignalBus signalBus;
       
        private void Start()
        {
            signalBus.Subscribe<OnMoveForwardSignal>(OnMoveForward);
        }

        private void OnMoveForward()
        {
            transform.position += new Vector3(0, 0, 1)*Time.deltaTime*2f;
        }
    }
}