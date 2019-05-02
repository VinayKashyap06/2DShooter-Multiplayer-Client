using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerControllerBase : IPlayerController
    {
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

        public virtual void SpawnView(PlayerView playerView,Vector3 position)
        {
            
        }
    }
}
