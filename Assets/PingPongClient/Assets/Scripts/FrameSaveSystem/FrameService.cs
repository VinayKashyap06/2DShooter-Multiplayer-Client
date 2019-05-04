using UnityEngine;
using MultiplayerSystem;
using Zenject;

namespace FrameSaveSystem
{
    public class FrameService : IFrameService, IFixedTickable,IInitializable
    {
        private int frameCount = 0;
        private IWorldSaveService worldSaveService;
        private float frameRate;
        public FrameService(IWorldSaveService worldSaveService, SignalBus signalBus)
        {
            this.worldSaveService = worldSaveService;
            signalBus.Subscribe<OnUserConnectedSignal>(SetStartFrameCount);
        }
        public void FixedTick()
        {
            worldSaveService.ExecuteFrame(frameCount);
            Debug.Log("execurte frame called");
            frameCount++;
            // Tick();
        }

        public int GetFrameCount()
        {
            return frameCount;
        }

        public void Initialize()
        {
            //frameRate = 1/30;
            //Tick();
        }

        private void SetStartFrameCount(OnUserConnectedSignal onUserConnectedSignal)
        {          
            this.frameCount = onUserConnectedSignal.GetFrameNo();
            Debug.Log("<color=red> frame count set called </color>"+frameCount);
        }
        private async void Tick()
        {
            while (true)
            {
                await new WaitForSecondsRealtime(frameRate);
                worldSaveService.ExecuteFrame(frameCount);
                //Debug.Log("execute frame called");
                frameCount++;
            }
        }
    }
}
