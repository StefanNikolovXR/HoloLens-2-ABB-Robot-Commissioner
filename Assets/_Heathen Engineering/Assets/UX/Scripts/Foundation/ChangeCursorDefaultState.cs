using UnityEngine;
using UnityEngine.EventSystems;

namespace HeathenEngineering.UX
{
    /// <summary>
    /// Changes the default cursor state based on mouse enter or exit
    /// </summary>
    public class ChangeCursorDefaultState : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public CursorState stateOnEnter;
        public CursorState stateOnExit;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            API.Cursors.DefaultState = stateOnEnter;
            API.Cursors.SetDefault();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            API.Cursors.DefaultState = stateOnExit;
            API.Cursors.SetDefault();
        }
    }
}
