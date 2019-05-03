using UnityEngine;
using MultiplayerSystem;
using Zenject;

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
        }
    }
}
