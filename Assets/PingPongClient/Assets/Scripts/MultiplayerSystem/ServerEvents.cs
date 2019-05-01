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
        public static string ON_USER_CONNECTED = "onUserConnected";
        public static string ON_MOVE_FORWARD = "onMoveForward";
        public static string ON_MOVE_BACKWARD = "onMoveBackward";
        public static string ON_MOVE_LEFT = "onMoveLeft";
        public static string ON_MOVE_RIGHT = "onMoveRight";
        public static string ON_PLAYER_JUMP = "onPlayerJump";
        #endregion

        #region EventsToEmit
        public static string MOVE_FORWARD = "moveForward";
        #endregion
    }
}
