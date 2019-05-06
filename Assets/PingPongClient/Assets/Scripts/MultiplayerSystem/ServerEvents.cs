using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplayerSystem
{
    public static class ServerEvents
    {
        #region EventsToListen
        public const string ON_USER_CONNECTED = "onUserConnected";
        public const string ON_USER_DISCONNECTED = "onUserDisconnected";
        public const string ON_OPPONENT_CONNECTED = "onOpponentConnected";
        public const string ON_MOVE_FORWARD = "onMoveForward";
        public const string ON_MOVE_BACKWARD = "onMoveBackward";
        public const string ON_MOVE_LEFT = "onMoveLeft";
        public const string ON_MOVE_RIGHT = "onMoveRight";
        public const string ON_PLAYER_JUMP = "onPlayerJump";
        public const string ON_ADD_FRAME_DATA = "onAddFrameData";
        #endregion

        #region EventsToEmit
        public const string MOVE_FORWARD = "moveForward";
        public const string MOVE_BACKWARD = "moveBackward";
        public const string MOVE_LEFT = "moveLeft";
        public const string MOVE_RIGHT= "moveRight";
        #endregion
    }
}
