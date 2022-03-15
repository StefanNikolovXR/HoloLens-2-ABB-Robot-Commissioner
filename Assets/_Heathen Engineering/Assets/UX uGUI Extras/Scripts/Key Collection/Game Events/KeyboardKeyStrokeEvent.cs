using HeathenEngineering.Events;
using HeathenEngineering.UX.uGUIExtras;
using System;
using UnityEngine.Events;

namespace HeathenEngineering.UX
{
    [Serializable]
    public class KeyboardKeyStrokeEvent : UnityEvent<KeyCollectionKey>
    { }

    [Serializable]
    public class UnityKeyStrokeDataEvent : UnityDataEvent<KeyCollectionKey>
    { }
}
