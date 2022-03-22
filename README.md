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

3. **Configuration and editing of SafeMove V2 supervision features** - Stand Still, Axis Position, Axis Speed, Tool Speed, Tool Position and Tool Orientation. 
