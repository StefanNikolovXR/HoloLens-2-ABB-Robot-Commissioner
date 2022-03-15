using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.Deployment;
using System.Drawing;
using System.Management;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using System.Deployment;
using System.Drawing;
using System.Management;
using UnityEngine.Networking;
using System.Web;
using System.Net;
using System.IO;
using RestSharp;

public class JogAxesPostRequest : MonoBehaviour
{

    static NetworkCredential default_credential = new NetworkCredential("Default User", "robotics");

    public void JogAxis()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);

        request.Credentials = default_credential;

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

       // request.AddHeader("Cookie", "-http-session-=1::http.session::83661a1544ef7a0a420729fdd41e4787; ABBCX=14");

        request.AddParameter("axis1", "900");
        request.AddParameter("axis2", "9000");
        request.AddParameter("axis3", "9000");
        request.AddParameter("axis4", "9000");
        request.AddParameter("axis5", "9000");
        request.AddParameter("axis6", "9000");
        request.AddParameter("ccount", "0");
        request.AddParameter("inc-mode", "Large");
        IRestResponse response = client.Execute(request);
        print(response.Content);
    }
}

