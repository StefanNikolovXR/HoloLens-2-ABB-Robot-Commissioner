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

public class RequestMastershipAUTO : MonoBehaviour
{

    // Authenticator = new DigestAuthenticator("Default User", "robotics");
    static NetworkCredential default_credential = new NetworkCredential("Default User", "robotics");

    public void GrantMastership ()
    {

        var client = new RestClient("http://localhost/rw/mastership?action=request");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
       // request.Credentials = default_credential;
        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");
        IRestResponse response = client.Execute(request);
        print(response.Content);

    }
}
