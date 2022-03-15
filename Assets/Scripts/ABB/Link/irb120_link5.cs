// ------------------------------------------------------------------------------------------------------------------------//
// ----------------------------------------------------- LIBRARIES --------------------------------------------------------//
// ------------------------------------------------------------------------------------------------------------------------//

// -------------------- Unity -------------------- //
using UnityEngine;

public class irb120_link5 : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.localEulerAngles = new Vector3(0f, 0f,GlobalVariables_RWS_client.robotBaseRotLink_irb_joint[4]);
    }
    void OnApplicationQuit()
    {
        Destroy(this);
    }
}
