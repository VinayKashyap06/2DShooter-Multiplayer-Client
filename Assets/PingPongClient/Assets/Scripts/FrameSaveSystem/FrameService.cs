using UnityEngine;
using MultiplayerSystem;
using Zenject;
using System;

namespace FrameSaveSystem
{
    public class FrameService : IFrameService, IFixedTickable,IInitializable
    {
        private int frameCount = 0;
        private IWorldSaveService worldSaveService;
        private float frameRate;
        double t=0,nt=0;
        TimeSpan timeSpan2;
        TimeSpan timeSpan;
        //int deltaTime;
        DateTime date = new DateTime();
        //TimeSpan timeSpan = new TimeSpan();
        public FrameService(IWorldSaveService worldSaveService, SignalBus signalBus)
        {
            this.worldSaveService = worldSaveService;
            signalBus.Subscribe<OnUserConnectedSignal>(SetStartFrameCount);
        }
        public void FixedTick()
        {
            Debug.Log("deltaTime" +Time.deltaTime*1000);//(nt-t));
          //  timeSpan = TimeSpan.FromTicks(date.Ticks);
           // t =  timeSpan.TotalMilliseconds;

            worldSaveService.ExecuteFrame(frameCount);
            frameCount++;
            
            //timeSpan2 = TimeSpan.FromTicks(date.Ticks);
            //nt = timeSpan2.TotalMilliseconds;
        }

        public int GetFrameCount()
        {
            return frameCount;
        }

        public void Initialize()
        {
            //frameRate = 1 / 30;
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
