
Transform Utilities
===================

    © 2011-2015 Freakshow Studio AS
    All rights reserved


Introduction
------------

*Transform Utilities* is a set of utilities for the Unity editor that allows you to easily nudge, rotate, flip and snap objects to a grid using keyboard shortcuts, or editor buttons. The grid can have independent scaling along each axis.

The grid can also be drawn in the scene view, each of XZ, YZ and YX grids can be shown independently and have a custom color.

Note that the grid and snap functions are independent of Unitys internal grid and snap.


Features
--------

 * Show a grid for any two axis XZ, YZ and YX independently or simultaneously with independent spacing in any direction and a separate color for each grid if wanted.
 * Nudge, Rotate, Flip and Snap using a custom editor window, menu items or keyboard shortcuts. Shortcuts can be customized by editing the ```TransformUtilMenuItem.cs``` file (see http://unity3d.com/support/documentation/ScriptReference/MenuItem.html for information about how to set your own shortcuts)


Usage
-----

In the menu, open the TransformUtil window under ```Edit -> TransformUtil -> Open Window```.

The *Preferences* tab will allow you to change the behaviour of the utilities, and the *Controls* tab contains buttons to nudge, rotate, flip and snap.

As any other Unity window, this can be docked anywhere in your editor.

All controls can also be activated from the menu, where you can also see the keyboard shortcut assigned to the function.

Note that the grid and snap functions are independent of Unitys internal grid and snap, and that control+mouse still uses Unitys internal grid and not the one provided by Transform Utilities (you can however in most cases set the Unity grid to be of equal size).

Hotkeys
-------

The default keyboard shortcuts are as follows:

| Key                       | Function           |
|---------------------------|--------------------|
| ```Alt+I```               | Nudge Z            |
| ```Alt+K```               | Nudge -Z           |
| ```Alt+L```               | Nudge X            |
| ```Alt+J```               | Nudge -X           |
| ```Alt+Shift+I```         | Nudge Y            |
| ```Alt+Shift+K```         | Nudge -Y           |
| ```Alt+,```               | Snap XYZ           |
| ```Alt+O```               | Yaw Right          |
| ```Alt+U```               | Yaw Left           |
| ```Alt+Shift+O```         | Pitch Up           |
| ```Alt+Shift+U```         | Pitch Down         |
| ```Alt+Control+O```       | Roll Right         |
| ```Alt+Control+U```       | Roll Left          |
| ```Alt+R```               | Reset Rotation     |
| ```Alt+Control+L```       | Flip X             |
| ```Alt+Control+I```       | Flip Y             |
| ```Alt+Control+K```       | Flip Z             |

On Mac, substitute ```Alt``` with ```Option``` and ```Control``` with ```Command```.


Support
-------

Should you require assistance, please contact <support@freakshowstudio.com>
