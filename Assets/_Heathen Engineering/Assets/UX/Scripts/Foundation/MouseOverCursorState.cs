using UnityEngine;
using UnityEngine.EventSystems;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace HeathenEngineering.UX
{
    /// <summary>
    /// Sets the state of the cursor when the mouse enters the control and reverts to default when it exits
    /// </summary>
    public class MouseOverCursorState : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public CursorState stateOnEnter;
        public bool holdOnMouseDown;

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            API.Cursors.SetState(stateOnEnter, false, holdOnMouseDown);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            API.Cursors.SetDefault();
        }
    }
}
