using SocketIO;

namespace MultiplayerSystem
{
    public class OnMoveForwardSignal
    {
        private SocketIOEvent socketIOEvent;

        public OnMoveForwardSignal(SocketIOEvent socketIOEvent)
        {
            this.socketIOEvent = socketIOEvent;
        }
    }
}