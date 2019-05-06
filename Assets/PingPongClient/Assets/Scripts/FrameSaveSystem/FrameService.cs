using UnityEngine;
using MultiplayerSystem;
using Zenject;
using System;

namespace FrameSaveSystem
{
    public class FrameService : IFrameService, IFixedTickable
    {
        private int frameCount = 0;
        private IWorldSaveService worldSaveService;        
        public FrameService(IWorldSaveService worldSaveService, SignalBus signalBus)
        {
            this.worldSaveService = worldSaveService;
            signalBus.Subscribe<OnUserConnectedSignal>(SetStartFrameCount);
        }
        public void FixedTick()
        {
            //Debug.Log("deltaTime" +Time.deltaTime*1000);          
            worldSaveService.ExecuteFrame(frameCount);
            frameCount++;
        }

        public int GetFrameCount()
        {
            return frameCount;
        }
      
        private void SetStartFrameCount(OnUserConnectedSignal onUserConnectedSignal)
        {          
            this.frameCount = onUserConnectedSignal.GetFrameNo();
            Debug.Log("<color=red> frame count set called </color>"+frameCount);
        }     
    }
}
