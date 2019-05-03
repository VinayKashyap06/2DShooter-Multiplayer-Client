using MultiplayerSystem;
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

        public virtual void MoveBackward(Vector3 position)
        {
            
        }

        public virtual void MoveForward(Vector3 position)
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
