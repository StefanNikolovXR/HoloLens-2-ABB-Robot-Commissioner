using UnityEngine;

namespace HeathenEngineering.UX
{
    /// <summary>
    /// Updates the animation state of the <see cref="CursorSettings"/>
    /// </summary>
    public class CursorAnimator : MonoBehaviour
    {
        [SerializeField]
        private CursorState defaultState;

        private void OnEnable()
        {
            if (defaultState != null)
                API.Cursors.DefaultState = defaultState;
        }

        private void LateUpdate()
        {
            API.Cursors.Update(Time.unscaledDeltaTime);
        }
    }

    
}
