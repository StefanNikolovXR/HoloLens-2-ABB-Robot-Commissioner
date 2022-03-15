using UnityEngine.EventSystems;

namespace HeathenEngineering.UX
{
    /// <summary>
    /// Sets the stae of the cursor on enter and mouse down and reverts to default on exit
    /// </summary>
    public class ButtonCursorState : MouseOverCursorState, IPointerDownHandler, IPointerClickHandler
    {
        public CursorState stateOnClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (stateOnEnter)
                API.Cursors.SetState(stateOnEnter, false, holdOnMouseDown);
            else
                API.Cursors.SetDefault();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            API.Cursors.SetState(stateOnClick, true, holdOnMouseDown);
        }
    }
}
