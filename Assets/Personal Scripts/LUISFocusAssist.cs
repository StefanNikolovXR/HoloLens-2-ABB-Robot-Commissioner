using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class LUISFocusAssist : MonoBehaviour
{
    public FocusAssistMode focus;
    public ToolTip tooltip;

    public void SaveScene()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "This will add spatial anchors to all holograms in your environment and save them to a .scene file. The next time you're in this environment, you can restore your work to the exact state and place in the real world you saved it in.";
        }
    }

    public void LoadScene()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "You can load a previously saved .scene file to replace your current session with a spatially anchored environment. Make sure you're currently in the same physical environment as the loaded scene's!";
        }
    }

    public void UserCollision()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable a collider around your own body. You can use it to simulate safety scenarios by physically walking into a safe zone to trigger a category stop.";
        }
    }

    public void Import()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Click this to import .XLS SafeMove data into your current holographic environment.";
        }
    }

    public void LeftHanded()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to make your left hand your dominant one. This will anchor the main menu to your right hand and all panel placement will be determined by the raycast from your left hand.";
        }
    }

    public void ColorBlind()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to switch the color pallette of the app through 4 settings for color-blind accessibility: Default, Protanopia, Tritanopia and Deuteranopia.";
        }
    }

    public void Components()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to visualize or hide the physical, non-interactive components of the robot hologram you've anchored.";
        }
    }

    public void JogHandles()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable the axis handles that allow joints to be rotated with a pinch gesture. If this is disabled, you will not be able to lock joints in Hand Pathing Mode.";
        }
    }

    public void Colliders()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable the collision capsules on the robot's arm. If this is disabled, the robot will not trigger collisions with safe zones when moving inside them.";
        }
    }

    public void AxisArrows()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable visual arrow indicators for each joint's orientation and the robot's rotational factory limits. If this is disabled, you will not be able to visualize SafeMove APO.";
        }
    }

    public void HandPathing()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable control of the robot with pinch and grab gestures. If Jog Handles is enabled, you can tap on a joint indicator to prevent that joint from moving as a result of other joints moving.";
        }
    }

    public void AdjustFrame()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to move and/or rotate the robot hologram and re-anchor it. If connection to RobotStudio is enabled, this will move the base frame in your station and will prompt a controller restart.";
        }
    }

    public void ArmTracing()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable measurement lines for calibration purposes. Additionally, moving a safe zone under or above the robot will measure the distance from the robot's joints to the top or bottom of the respective zone.";
        }
    }

    public void RobotStudio()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle to summon the RobotStudio panel. It contains interface to connect to, pass and receive information from an RS station running on the same PC machine.";
        }
    }

    public void SafeMove()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle to summon the SafeMove panel. It allows you to set up all SafeMove V2 Supervision functions globally or for a specific safe zone.";
        }
    }

    public void RPMandBrake()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle to summon the RPM&Brake panel. It visualizes the velocity of all joints and the distance the non-arm joints will travel before coming to a complete stop. ASP is visualized on this panel.";
        }
    }

    public void Orientation()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle to summon the Orientation panel. It requires connection to RobotStudio to display tool position and orientation and joint orientation data.";
        }
    }

    public void Keyboard()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle to summon a digital keyboard. It allows you to type values into the SafeMove table and the Axis Jogging slider (a toggled function of the Master Slider)";
        }
    }

    public void LUIS()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle to summon or disable... me! If I'm re-enabled, I will automatically be put into Focus Assist mode.";
        }
    }

    public void MasterSlider()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle to summon or disable a slider panel with four functions: axis jogging, safe zone creation, torque & speed adjustment and replay. Only one function can be active at the same time.";
        }
    }

    public void Instructions()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle to summon or disable the Instructions panel. It allows you to teach instructions if connected to a RobotStudio station and also visualize the machine's path.";
        }
    }

    public void StartMenu()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle to summon or disable the Start Menu cube. It lets you load a scanned spatial mesh, switch to a new environment layout or add/replace robot models in your environment.";
        }
    }

    public void Robot()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle to show or hide all functions related to the specific robot hologram in your single machine environment.";
        }
    }

    public void Environment()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle to show or hide all functions that spawn panels and other UI elements in your environment.";
        }
    }

    public void General()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle to show or hide all functions related to the specific scene (hologram environment), as well as user collision and accessibility settings.";
        }
    }

    public void TeachInstruction()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this button to teach the machine an instruction at the tool's tip in your active RobotStudio station and visualize the instruction in your physical space.";
        }
    }

    public void ScrollInstructionParameters()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this button to switch to the next or previous instruction setting in your active RobotStudio station. Hold the button to scroll through parameters quicker. These settings will apply to all subseqently taught instructions.";
        }
    }

    public void LeaveTrail()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Enabling this will make the tool's tip leave a permanent visual trail in your physical space for as long as the function is active.";
        }
    }

    public void ClearTrail()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this to delete the visual trail emitted by the tool's tip.";
        }
    }

    public void TargetShells()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable the outer spherical indicators for the machine's instructions. These indicators can be tapped to move the machine in the position for that instruction.";
        }
    }

    public void Login()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this to attempt to log in on your active RobotStudio station with the username, password and VC/IP you've provided above.";
        }
    }

    public void Mastership()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this to request Mastership in Auto Mode on your active RobotStudio station.";
        }
    }

    public void RMMP()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this to request Mastership in Manual Mode on your active RobotStudio station.";
        }
    }

    public void Functions()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this after you have logged in successfully to rotate the panel and access manual axis jogging and functions to pass and receive data from an active RobotStudio station.";
        }
    }

    public void RS_Orientation()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to receive position and orientation data from your active RobotStudio station. The data will be displayed on the Orientation panel, found under Environment in your main menu.";
        }
    }

    public void RStoUnity()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this receive both motion and orientation data from your active RobotStudio station. Pathing and FlexPendant joystick input will move the robot hologram smoothly in sync with the machine in RS. Manual jogging will snap the hologram to the final position and orientation.";
        }
    }

    public void SetMechUnits()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to pass motion from this application to your active RobotStudio station. This allows you to control a real machine or an RS digital twin by moving the robot hologram via the joint handles, slider input or hand pathing.";
        }
    }

    public void Logout()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this to logout of your current session on your active RobotStudio station (if you are currently logged in) and rotate this panel back to the login and grants functions.";
        }
    }

    public void TorqueSwitch()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Set MechUnits to SMB and then tap this to apply motion to the robot in your active RobotStudio station equivalent to a FlexPendant joystick tap. The increment and torque can be adjusted by the Torque & Speed slider (a toggled function of the Master Slider).";
        }
    }

    public void GlobalZoneTools()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this to access visualization and storage functions for all SafeMove V2 Supervision features. If you've selected a safe zone, tapping this button will instead give access to functions specific to that zone.";
        }
    }

    public void SST()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this to access the data table for Stand Still Supervision, allowing you to activate supervision of the robot while its stationary but with active motors.";
        }
    }

    public void ASP()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this to access the data table for Axis Speed Supervision, allowing you to activate supervision for the minimum and maximum speed of each joint.";
        }
    }

    public void TSP()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this to access the data table for Tool Speed Supervision, allowing you to activate supervision for the minimum and maximum speed of the robot's tool(s).";
        }
    }

    public void APO()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this to access the data table for Axis Position Supervision, allowing you to activate supervision for the allowed range of each joint's rotation.";
        }
    }

    public void TPO()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this to access the data table for Tool Position Supervision, allowing you to activate supervision for the allowed entry of the robot's arm and tool into a specific zone.";
        }
    }

    public void TOR()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this to access the data table for Tool Orientation Supervision, allowing you to set the allowed rotation of the robot's tool at specific vectors.";
        }
    }

    public void Enable_SST()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable Stand Still Supervision globally.";
        }
    }

    public void Enable_ASP()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable Axis Speed Supervision globally if no zones are selected or for a specific selected zone.";
        }
    }

    public void Enable_TSP()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable Tool Speed Supervision globally if no zones are selected or for a specific selected zone.";
        }
    }

    public void Enable_APO()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable Axis Position Supervision globally if no zones are selected or for a specific selected zone.";
        }
    }

    public void Enable_TPO()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable Tool Speed Supervision globally if no zones are selected or for a specific selected zone.";
        }
    }

    public void Enable_TOR()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable Tool Orientation Supervision globally if no zones are selected or for a specific selected zone.";
        }
    }

    public void ActiveModes()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Tap this to expand or collapse my available modes. In my default Focus Assist mode, I will give you helpful information when you hover over interactable holograms. In Tutorial mode, I will run you through a series of tutorials to get you accustomed with working with the HoloLens 2 and this particular application. In Comment mode, I can record and create comments for you to place in your environment. Finally, in Command mode I can execute tasks you tell me.";
        }
    }

    public void CommentMode()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable Comment mode. You can speak comments and I will record them in my speech bubble above. If you are happy with your comment, tap on me and I will create a copy of my bubble for you to place in your environment. If I didn't record your comment properly, please wait a little bit before speaking again and I will clear the comment for you automatically.";
        }
    }

    public void CommandMode()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable Command mode. You can ask me to perform a wide range of tasks. If I've misunderstood you or I didn't complete your task, your command will be automatically stored in the LUIS API for a developer to look at and expand my dictionary.";
        }
    }

    public void TutorialMode()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to enable or disable Tutorial mode. I will run you through a series of tutorials to get you comfortable with using the HoloLens 2 and working with this application. You can exit the tutorials at any time and I will store your progress in them if you choose to return to them.";
        }
    }

    public void FocusAssistMode()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Toggle this to switch to my default mode, Focus Assist. When you hover over holograms that can be interacted with, I will give you helpful information about them.";
        }
    }

    public void JointHandle()
    {
        if (focus.assist)
        {
            tooltip.ToolTipText = "Grab this joint indicator up close or pinch it from a distance and then move your hand to rotate the robot's corresponding axis.";
        }
    }

    public void MotionHandle() { 
         if (focus.assist)
        {
            tooltip.ToolTipText = "Grab this handle up close or pinch it from a distance to move its corresponding panel or other UI element. Releasing the handle will re-anchor the element.";
        }
}
}
