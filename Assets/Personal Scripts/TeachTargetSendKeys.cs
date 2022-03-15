using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WindowsInput;

public class TeachTargetSendKeys : MonoBehaviour
{
    public void TeachTargetinRS()
    {
        var inputSim = new InputSimulator();
        inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.CONTROL);
        inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.SHIFT);
        inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_R);

        inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.CONTROL);
        inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.SHIFT);
        inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_R);
    }
}
