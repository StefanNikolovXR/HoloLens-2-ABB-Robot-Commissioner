using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace HeathenEngineering.UX.API
{
    public static class Cursors
    {
        private static int currentFrame;
        private static float frameTimer;
        private static bool holdIfDown = false;
        private static bool holding = false;
        private static CursorState nextState = null;
        private static bool nextHoldingState = false;
        private static CursorState currentState;
        private static CursorState defaultState;
        private static CursorMode mode = CursorMode.Auto;

        public static CursorMode RenderMode
        {
            get => mode;
            set
            {
                mode = value;
                if (currentState != null)
                    Cursor.SetCursor(currentState.animation.textureArray[currentFrame], currentState.hotSpot, mode);
                else if (defaultState != null)
                    Cursor.SetCursor(defaultState.animation.textureArray[currentFrame], defaultState.hotSpot, mode);
            }
        }
        public static bool Visible { get => Cursor.visible; set => Cursor.visible = value; }
        public static CursorLockMode LockMode { get => Cursor.lockState; set => Cursor.lockState = value; }
        public static CursorState DefaultState
        {
            get => defaultState;
            set
            {
                defaultState = value;
            }
        }
        public static CursorState CurrentState
        {
            get
            {
                return currentState;
            }
            set => SetState(value);
        }

        public static void Update(float frameTime)
        {
#if ENABLE_INPUT_SYSTEM
            // New input system backends are enabled.
            if (holding && !Mouse.current.leftButton.isPressed)
            {
                holding = false;

                if (nextState != null)
                    SetState(nextState, false, nextHoldingState);
                else
                    SetDefault();
            }
            else if (holdIfDown && Mouse.current.leftButton.isPressed)
                holding = true;
#else
            // Old input backends are enabled.
            if (holding && !Input.GetMouseButton(0))
            {
                holding = false;

                if (nextState != null)
                    SetState(nextState, false, nextHoldingState);
                else
                    SetDefault();
            }
            else if (holdIfDown && Input.GetMouseButton(0))
                holding = true;
#endif

            if (currentState == null)
                return;

            Cursor.visible = Visible;
            Cursor.lockState = LockMode;

            frameTimer -= frameTime;
            if (frameTimer <= 0f)
            {
                frameTimer += (1f / currentState.animation.framesPerSecond);
                Cursor.SetCursor(currentState.animation.textureArray[currentFrame], currentState.hotSpot, mode);

                if (currentState.animation.loop || currentFrame < currentState.animation.textureArray.Length - 1)
                    currentFrame = (currentFrame + 1) % currentState.animation.textureArray.Length;
            }
        }
        public static void SetDefault() => SetState(defaultState);
        public static void SetState(CursorState state, bool setOnHold = false, bool holdOnDown = false)
        {
            if (holding && !setOnHold)
            {
                nextHoldingState = holdOnDown;
                nextState = state;
                return;
            }

            holdIfDown = holdOnDown;

            if (state == null && state != defaultState)
            {
                SetState(defaultState);
            }
            else if (state == null && defaultState == null)
            {
                Debug.LogError("Attempted to set the Cursor State to a null value.\nThis is an unsupported action, you can only call SetState with a null state if a defualt state is defined.");
            }


            var pState = CurrentState;
            currentState = state ? state : defaultState;

            currentFrame = 0;
            frameTimer = (1f / currentState.animation.framesPerSecond);

            Cursor.SetCursor(currentState.animation.textureArray[currentFrame], currentState.hotSpot, mode);

            if (pState != null && pState != state)
                pState.Invoke(state, false);

            if (currentState != null)
                currentState.Invoke(state, true);
        }
    }
}
