using System;
using System.Collections.Generic;
using Zenject;
using UnityEngine;
using PlayerSystem;

namespace InputSystem
{
    class InputService : ITickable, IInputService
    {
        private SignalBus signalBus;
        public InputService(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }
        public void Tick()
        {
            if (Input.GetAxis("Vertical") > 0f)
            {
                signalBus.TryFire(new MoveForwardSignal());
            }
            else if(Input.GetAxis("Vertical") < 0f)
            {
                signalBus.TryFire(new MoveBackwardSignal());
            }
        }
    }
}
