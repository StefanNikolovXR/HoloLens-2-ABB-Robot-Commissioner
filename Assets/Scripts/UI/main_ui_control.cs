/****************************************************************************
MIT License
Copyright(c) 2020 Roman Parak
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*****************************************************************************
Author   : Roman Parak
Email    : Roman.Parak @outlook.com
Github   : https://github.com/rparak
File Name: main_ui_control.cs
****************************************************************************/

// ------------------------------------------------------------------------------------------------------------------------ //
// ----------------------------------------------------- LIBRARIES -------------------------------------------------------- //
// ------------------------------------------------------------------------------------------------------------------------ //

// -------------------- System -------------------- //
using System;
using System.Text;
// -------------------- Unity -------------------- //
using UnityEngine;
using UnityEngine.UI;
// --------------------- TM ---------------------- //
using TMPro;

public class main_ui_control : MonoBehaviour
{

    // -------------------- TMP_InputField -------------------- //
    public TextMeshPro ip_address_txt;
    // -------------------- Float -------------------- //
    private float ex_param = 100f;
    // -------------------- TextMeshProUGUI -------------------- //
    public TextMeshPro position_x_txt, position_y_txt, position_z_txt;
    public TextMeshPro position_q1_txt, position_q2_txt, position_q3_txt, position_q4_txt;
    public TextMeshPro position_j1_txt, position_j2_txt, position_j3_txt;
    public TextMeshPro position_j4_txt, position_j5_txt, position_j6_txt;

    // ------------------------------------------------------------------------------------------------------------------------ //
    // ------------------------------------------------ INITIALIZATION {START} ------------------------------------------------ //
    // ------------------------------------------------------------------------------------------------------------------------ //
    void Start()
    {

        // Panel Initialization -> Connection/Diagnostic Panel

        // Position {Cartesian} -> X..Z
        position_x_txt.text = "0.00";
        position_y_txt.text = "0.00";
        position_z_txt.text = "0.00";
        // Position {Rotation} -> Quaternion(1..4)
        position_q1_txt.text = "0.00000000";
        position_q2_txt.text = "0.00000000";
        position_q3_txt.text = "0.00000000";
        position_q4_txt.text = "0.00000000";
        // Position Joint -> 1 - 6
        position_j1_txt.text = "0.00";
        position_j2_txt.text = "0.00";
        position_j3_txt.text = "0.00";
        position_j4_txt.text = "0.00";
        position_j5_txt.text = "0.00";
        position_j6_txt.text = "0.00";

        // Robot IP Address
        ip_address_txt.text = "127.0.0.1";
    }

    // ------------------------------------------------------------------------------------------------------------------------ //
    // ------------------------------------------------ MAIN FUNCTION {Cyclic} ------------------------------------------------ //
    // ------------------------------------------------------------------------------------------------------------------------ //
    void Update()
    {
        // Robot IP Address (Read) -> XML thread function
        GlobalVariables_Main_Control.abb_irb_rws_xml_config[0]  = ip_address_txt.text;
        // Robot IP Address (Write) -> JSON thraed function
        GlobalVariables_Main_Control.abb_irb_rws_json_config[0] = ip_address_txt.text;


        // ------------------------ Connection Information ------------------------//
        // If the button (connect/disconnect) is pressed, change the color and text

        // ------------------------ Cyclic read parameters {diagnostic panel} ------------------------ //
        // Position {Cartesian} -> X..Z
        position_x_txt.text = GlobalVariables_RWS_client.robotBaseRotLink_irb_cartes[0];
        position_y_txt.text = GlobalVariables_RWS_client.robotBaseRotLink_irb_cartes[1];
        position_z_txt.text = GlobalVariables_RWS_client.robotBaseRotLink_irb_cartes[2];
        // Position {Rotation} -> Quaternion(q1..q4)
        position_q1_txt.text = GlobalVariables_RWS_client.robotBaseRotLink_irb_cartes[3];
        position_q2_txt.text = GlobalVariables_RWS_client.robotBaseRotLink_irb_cartes[4];
        position_q3_txt.text = GlobalVariables_RWS_client.robotBaseRotLink_irb_cartes[5];
        position_q4_txt.text = GlobalVariables_RWS_client.robotBaseRotLink_irb_cartes[6];
        // Position Joint -> 1 - 6
        position_j1_txt.text = GlobalVariables_RWS_client.robotBaseRotLink_irb_joint[0].ToString();
        position_j2_txt.text = GlobalVariables_RWS_client.robotBaseRotLink_irb_joint[1].ToString();
        position_j3_txt.text = GlobalVariables_RWS_client.robotBaseRotLink_irb_joint[2].ToString();
        position_j4_txt.text = GlobalVariables_RWS_client.robotBaseRotLink_irb_joint[3].ToString();
        position_j5_txt.text = GlobalVariables_RWS_client.robotBaseRotLink_irb_joint[4].ToString();
        position_j6_txt.text = GlobalVariables_RWS_client.robotBaseRotLink_irb_joint[5].ToString();
    }

    // ------------------------------------------------------------------------------------------------------------------------//
    // -------------------------------------------------------- FUNCTIONS -----------------------------------------------------//
    // ------------------------------------------------------------------------------------------------------------------------//

    // -------------------- Destroy Blocks -------------------- //
    void OnApplicationQuit()
    {
        // Destroy all
        Destroy(this);
    }

    // -------------------- Connect Button -> is pressed -------------------- //
    public void TaskOnClick_ConnectBTN()
    {
        GlobalVariables_Main_Control.connect    = true;
        GlobalVariables_Main_Control.disconnect = false;
    }

    // -------------------- Disconnect Button -> is pressed -------------------- //
    public void TaskOnClick_DisconnectBTN()
    {
        GlobalVariables_Main_Control.connect    = false;
        GlobalVariables_Main_Control.disconnect = true;
    }

}
