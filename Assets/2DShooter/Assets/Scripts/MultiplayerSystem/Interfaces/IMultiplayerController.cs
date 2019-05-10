using Zenject;
using FrameSaveSystem;

namespace MultiplayerSystem
{
    interface IMultiplayerController
    {        
        void SetSignalBus(SignalBus signalBus);
        void SetupServices(IWorldSaveService worldSaveService, IFrameService frameService);
    }
}
