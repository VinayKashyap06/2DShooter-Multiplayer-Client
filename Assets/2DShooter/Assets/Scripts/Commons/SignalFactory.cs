﻿using System;
using Zenject;
using MultiplayerSystem;
using UnityEngine;

namespace Commons
{
    public static class SignalFactory
    {
        public static SignalBus signalBus;      
        public static void FireSignal(string eventToEmit, JSONObject dataToSend)
        {
            switch (eventToEmit)
            {
                case ServerEvents.ON_MOVE_FORWARD:
                    Debug.Log("signal move forward fired");
                    signalBus.TryFire(new OnMoveForwardSignal(dataToSend));
                    break;
                case ServerEvents.ON_MOVE_BACKWARD:
                    signalBus.TryFire(new OnMoveBackwardSignal(dataToSend));
                    break;
                case ServerEvents.ON_MOVE_LEFT:
                    break;
                case ServerEvents.ON_MOVE_RIGHT:
                    break;
                case ServerEvents.ON_USER_CONNECTED:
                    signalBus.TryFire(new OnUserConnectedSignal(dataToSend));
                    break;
                case ServerEvents.ON_OPPONENT_CONNECTED:
                    signalBus.TryFire(new OnOpponentConnectedSignal(dataToSend));
                    break;
                case ServerEvents.ON_FIRE:
                    signalBus.TryFire(new OnBulletFireSignal(dataToSend));
                    break;
            
            }
        }
    }
}
