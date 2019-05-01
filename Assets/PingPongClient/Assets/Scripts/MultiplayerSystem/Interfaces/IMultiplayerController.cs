using Zenject;

namespace MultiplayerSystem
{
    interface IMultiplayerController
    {
        void MoveForward();
        void SetSignalBus(SignalBus signalBus);
    }
}
