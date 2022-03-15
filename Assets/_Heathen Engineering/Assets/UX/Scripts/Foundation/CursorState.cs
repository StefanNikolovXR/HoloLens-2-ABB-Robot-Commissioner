using HeathenEngineering.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace HeathenEngineering.UX
{
    [CreateAssetMenu(menuName = "UX/Cursor/State")]
    public class CursorState : GameEvent<bool>
    {
        public Vector2 hotSpot = Vector2.zero;
        [FormerlySerializedAs("Animation")]
        public CursorAnimation animation;

        public bool Active
        {
            get => API.Cursors.CurrentState == this;
            set
            {
                if (value)
                    API.Cursors.SetState(this);
                else if (API.Cursors.CurrentState == this)
                    API.Cursors.SetDefault();
            }
        }

        public bool IsDefault => API.Cursors.DefaultState == this;

        public void SetState(bool setOnHold = false, bool holdOnDown = false) => API.Cursors.SetState(this, setOnHold, holdOnDown);

        public void MakeDefault() => API.Cursors.DefaultState = this;
    }
}
