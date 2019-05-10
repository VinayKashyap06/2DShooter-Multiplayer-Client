using System;
using UnityEngine;
using System.Collections.Generic;
using Commons;
using Zenject;
using FrameSaveSystem;

namespace MultiplayerSystem
{
    public class MultiplayerService :IInitializable,IMultiplayerService
    {
        private SignalBus signalBus;
        private IMultiplayerController multiplayerController;
        IWorldSaveService worldSaveService;
        IFrameService frameService;
        public MultiplayerService(IWorldSaveService worldSaveService,IFrameService frameService,SignalBus signalBus)
        {
            this.signalBus = signalBus;
            SignalFactory.signalBus = signalBus;
            this.worldSaveService = worldSaveService;
            this.frameService = frameService;
        }

        public void Initialize()
        {
            GameObject controller = new GameObject("MultiplayerController");
            controller.AddComponent<MultiplayerController>();
            GameObject.DontDestroyOnLoad(controller);

            multiplayerController = controller.GetComponent<IMultiplayerController>();
            multiplayerController.SetSignalBus(signalBus);
            multiplayerController.SetupServices(worldSaveService, frameService);
        }


    }
}
