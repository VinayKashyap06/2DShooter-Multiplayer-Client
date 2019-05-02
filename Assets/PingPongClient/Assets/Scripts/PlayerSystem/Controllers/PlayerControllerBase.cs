using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace PlayerSystem
{
    public class PlayerControllerBase : IPlayerController
    {
        public SignalBus signalBus;
        public virtual string GetID()
        {
            return "";
        }

        public void MoveBackward()
        {
            
        }

        public void MoveForward()
        {
           
        }

        public void SetSignalBus(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        public virtual void SpawnView(PlayerView playerView,Vector3 position)
        {
            
        }
    }
}
