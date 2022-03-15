using HeathenEngineering.Events;
using HeathenEngineering.UX.uGUIExtras;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.UX
{
    [AddComponentMenu("Heathen/Events/KeyCollection Key Press Game Event Listener")]
    public class KeyboardKeyPressGameEventListener : GameEventListener<KeyCollectionKey>
    {
        public KeyboardKeyPressGameEvent Event;
        public UnityKeyStrokeDataEvent Responce;
        public KeyboardKeyStrokeEvent UnityEvent;

        public override IGameEvent<KeyCollectionKey> m_event => Event;

        public override UnityDataEvent<KeyCollectionKey> m_responce => Responce;

        public override UnityEvent<KeyCollectionKey> m_unityEvent => UnityEvent;
    }

    
}
