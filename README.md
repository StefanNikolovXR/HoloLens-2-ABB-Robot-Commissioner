# HoloLens-2-ABB-Robot-Commissioner
I made this application to help technicians commission and control industrial ABB robots using a HoloLens 2 device. For a complete demonstration of all its features, please watch the demo below:

<a href="http://www.youtube.com/watch?feature=player_embedded&v=dZER4gMpJcY
" target="_blank"><img src="http://img.youtube.com/vi/dZER4gMpJcY/0.jpg" 
alt="IMAGE ALT TEXT HERE" width="240" height="180" border="10" /></a>

# What is it?

My app uses a digital twin of a real ABB robot (IRB 120) that is placed in the user's real physical environment as an interactable 3D object (hologram). An expanding menu that follows the user's non-dominant hand contains sliders, menus, the option to control the robot with hand gestures via an IK solver and accessibility settings. 

# List of Features

1. **Anchoring** a digital twin of a robot as well as menus, sliders and other UI elements with **World Locking (WLT)** and **Space Pins**. This method removes the need for object anchoring and provides stable holograms even in new, unscanned environment. Note that environments still need to be consistently well-lit to avoid hologram flickering and drifting.

2. **Network connection from Unity to a RobotStudio station and vice versa via RobotWebServices**. This allows the holographic twin to be synchronized with the one in RobotStudio and it allows the user to see pathing and jogging in RobotStudio visualized in real physical space. Passing parameters from Unity to RS lets the user remotely control a robot from Unity and also create path instructions.

3. **Creating and editing of safe zones** or 3D polygonal volumes that the robot can pass through. These zones can contain various restrictions that apply to the robot while it's inside a zone. Safe zones in my app are created via a slider that determines how many edges or vertices a zone should have. Additional vertices can be added at any time and existing ones can be removed. The user can manipulate all aspects of a safe zone - its height, the position of specific edges, etc., as well as how the zone is visualized, whether the zone should project a 2D reflection of its shape at floor level, whether the edges should have their coordinates listed and more.

4. **Configuration, editing and visualization of SafeMove V2 supervision features** - Stand Still, Axis Position, Axis Speed and Tool Orientation. These parameters can be set up globally for the robot regardless of the position of its axes or only for a specific safe zone. Stand Still and Axis Position are visualized as arcs around the robot's joints that show the allowed range of motion for that joint. Axis Speed is visualized as concentrical circles wrapped around the gauges that show the velocity of each joint. Tool Orientation is visualized as a green cone-shaped polygon that is instantiated at the tool's position and its width is determined by the tolerance number the user inputs. Tool Speed and Tool Position are the last two SafeMove V2 features and parameters can be added for them, but they are not simulated and not visualized in my app.

5. **Various ways to control the holographic digital twin** by applying torque, rotating the joints manually with hand gestures, using an axis rotation slider or by moving the robot by the tip of its tool with hand gestures using an IK solver.

# How to Install

1. Clone the repository or download and unzip it.
2. Install **Unity Hub** and **Unity 2020.3.30f1** through it.
3. Add the project's folder to your **Projects** list in the Hub and select 2020.3.30f1 as the target platform.
4. Run the project. The main and only scene is called **"Core February for Feedback"** and is the default scene that loads upon starting the project.
5a. The project can be tested without a HoloLens 2 device by just hitting play and using the in-built MRTK input emulator.
5b. To test with a real device, please download, install and run the **Holographic Remoting App** from the Microsoft Store on your HoloLens 2 device. Then, go to going to **Window->XR->Holographic Remoting for Play Mode** and paste the IP that the remoting app displays. Enable Holographic Remoting and hit play in the editor. **Note that both the HL2 and the desktop you're remoting the app from MUST be connected to the same Wifi network, otherwise the app won't start and will give an error that a handshake couldn't be established.

Notes for better performance and visual clarity:

1. Run Unity's **Game** window in **Maximize on Play** mode.
2. Disconnect the HoloLens 2 from its Wifi network and connect it to the desktop you're remoting from via a USB-C cable. Paste the new IP the Holographic Remoting App gives you into the Remoting panel in Unity.
3. Run eye calibration for every new user. You **MUST** do this or holograms will likely appear blurry and text might be unreadable. Additionally, in the HoloLens 2 navigate to Control Panel -> Calibration and run the Color Calibration tool as well. See what color setting gives the best hologram clarity before you run the app. This will also help you with general clarity when using the HoloLens 2.
