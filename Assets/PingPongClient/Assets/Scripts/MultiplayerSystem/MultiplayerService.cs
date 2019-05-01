using System;
using UnityEngine;
using System.Collections.Generic;
using Zenject;

namespace MultiplayerSystem
{
    public class MultiplayerService :IInitializable,IMultiplayerService
    {
        private SignalBus signalBus;
        private IMultiplayerController multiplayerController;
        public MultiplayerService(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        public void Initialize()
        {
            GameObject controller = new GameObject("MultiplayerController");
            controller.AddComponent<MultiplayerController>();
            GameObject.DontDestroyOnLoad(controller);

            multiplayerController = controller.GetComponent<IMultiplayerController>();
            multiplayerController.SetSignalBus(signalBus);
        }


    }
}
