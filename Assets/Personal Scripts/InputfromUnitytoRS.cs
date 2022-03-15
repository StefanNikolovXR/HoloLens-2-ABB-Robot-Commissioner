using System;
using System.Net;
using UnityEngine;
using RestSharp;
using RestSharp.Authenticators.Digest;
using TMPro;

public class InputfromUnitytoRS : MonoBehaviour
{

    static NetworkCredential default_credential = new NetworkCredential("Default User", "robotics");
    static CookieContainer login_cookie = new CookieContainer();

    public GameObject RPMAxisMonitoringContainer;

    private float j1torque = 0, j2torque = 0, j3torque = 0, j4torque = 0, j5torque = 0, j6torque = 0;

    public string j1torquestr, j2torquestr, j3torquestr, j4torquestr, j5torquestr, j6torquestr, torqueincrement, speed;
    public string j1torquestr_neg, j2torquestr_neg, j3torquestr_neg, j4torquestr_neg, j5torquestr_neg, j6torquestr_neg;

    public bool solveron = false, buttonpush = false, mechunitson = false;

    public ChangeJointTorque torque;

    public TextMeshPro diagnostics;

    public UpdateMechUnits updatemech;

    void Start()
    {
        torqueincrement = "Large";

        speed = "100";

        j1torquestr = "500";
        j2torquestr = "500";
        j3torquestr = "500";
        j4torquestr = "500";
        j5torquestr = "500";
        j6torquestr = "500";

        j1torquestr_neg = "-500";
        j2torquestr_neg = "-500";
        j3torquestr_neg = "-500";
        j4torquestr_neg = "-500";
        j5torquestr_neg = "-500";
        j6torquestr_neg = "-500";
    }

    public void LoginAsLocal() 
        {

        var client = new RestClient("http://localhost/users?action=set-locale");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        var request = new RestRequest(Method.POST);
        request.Credentials = default_credential;

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");
            request.AddParameter("type", "local");

      IRestResponse response = client.Execute(request);
       print(response.Content);
       diagnostics.text = ("Login successful.");

       foreach (var cookie in response.Cookies)
        {
            request.AddCookie(cookie.Name, cookie.Value);
        }
    }

    public void SetSpeed()
    {
        var client = new RestClient("http://localhost/rw/panel/speedratio?action=setspeedratio");
        client.CookieContainer = login_cookie;
        client.Timeout = -1;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        request.AddParameter("speed-ratio", speed);
    }

    public void GrantMastership()
    {

        var client = new RestClient("http://localhost/rw/mastership?action=request");
        client.CookieContainer = login_cookie;
        client.Timeout = -1;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        IRestResponse response = client.Execute(request);
        print(response.Content);
    }


    public async void SyncMechanicalUnits() {

        while (solveron == true)
        {
            var client = new RestClient("http://localhost/rw/motionsystem/mechunits/ROB_1?action=mechunit-position");
            client.Timeout = -1;
            client.CookieContainer = login_cookie;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

            request.AddParameter("rob_joint", updatemech.manualjog);
            request.AddParameter("ext_joint", "[0,0,0,0,0,0]");

            var restResponse = await client.ExecuteTaskAsync(request);
        }
    }

    public async void JogJ1()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        while (buttonpush)
        {

            var request = new RestRequest(Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

            request.AddParameter("axis1", j1torquestr);
            request.AddParameter("axis2", "0");
            request.AddParameter("axis3", "0");
            request.AddParameter("axis4", "0");
            request.AddParameter("axis5", "0");
            request.AddParameter("axis6", "0");
            request.AddParameter("ccount", "17");
            request.AddParameter("inc-mode", "Large");

            var restResponse = await client.ExecuteTaskAsync(request);
        }
    }

    public async void JogJ1Neg()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        while (buttonpush)
        {

            var request = new RestRequest(Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

            request.AddParameter("axis1", j1torquestr_neg);
            request.AddParameter("axis2", "0");
            request.AddParameter("axis3", "0");
            request.AddParameter("axis4", "0");
            request.AddParameter("axis5", "0");
            request.AddParameter("axis6", "0");
            request.AddParameter("ccount", "17");
            request.AddParameter("inc-mode", "Large");

            var restResponse = await client.ExecuteTaskAsync(request);
        }
    }

    public async void JogJ2()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        while (buttonpush)
        {

            var request = new RestRequest(Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

            request.AddParameter("axis1", "0");
            request.AddParameter("axis2", j2torquestr);
            request.AddParameter("axis3", "0");
            request.AddParameter("axis4", "0");
            request.AddParameter("axis5", "0");
            request.AddParameter("axis6", "0");
            request.AddParameter("ccount", "17");
            request.AddParameter("inc-mode", torqueincrement);

            var restResponse = await client.ExecuteTaskAsync(request);
        }
    }

    public async void JogJ2Neg()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        while (buttonpush)
        {

            var request = new RestRequest(Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

            request.AddParameter("axis1", "0");
            request.AddParameter("axis2", j2torquestr_neg);
            request.AddParameter("axis3", "0");
            request.AddParameter("axis4", "0");
            request.AddParameter("axis5", "0");
            request.AddParameter("axis6", "0");
            request.AddParameter("ccount", "17");
            request.AddParameter("inc-mode", torqueincrement);

            var restResponse = await client.ExecuteTaskAsync(request);
        }
    }

    public async void JogJ3()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        while (buttonpush)
        {

            var request = new RestRequest(Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

            request.AddParameter("axis1", "0");
            request.AddParameter("axis2", "0");
            request.AddParameter("axis3", j3torquestr);
            request.AddParameter("axis4", "0");
            request.AddParameter("axis5", "0");
            request.AddParameter("axis6", "0");
            request.AddParameter("ccount", "17");
            request.AddParameter("inc-mode", torqueincrement);

            var restResponse = await client.ExecuteTaskAsync(request);
        }
    }

    public async void JogJ3Neg()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        while (buttonpush)
        {

            var request = new RestRequest(Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

            request.AddParameter("axis1", "0");
            request.AddParameter("axis2", "0");
            request.AddParameter("axis3", j3torquestr_neg);
            request.AddParameter("axis4", "0");
            request.AddParameter("axis5", "0");
            request.AddParameter("axis6", "0");
            request.AddParameter("ccount", "17");
            request.AddParameter("inc-mode", torqueincrement);

            var restResponse = await client.ExecuteTaskAsync(request);
        }
    }

    public async void JogJ4()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        while (buttonpush)
        {

            var request = new RestRequest(Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

            request.AddParameter("axis1", "0");
            request.AddParameter("axis2", "0");
            request.AddParameter("axis3", "0");
            request.AddParameter("axis4", j4torquestr);
            request.AddParameter("axis5", "0");
            request.AddParameter("axis6", "0");
            request.AddParameter("ccount", "17");
            request.AddParameter("inc-mode", torqueincrement);

            var restResponse = await client.ExecuteTaskAsync(request);
        }
    }

    public async void JogJ4Neg()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        while (buttonpush)
        {

            var request = new RestRequest(Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

            request.AddParameter("axis1", "0");
            request.AddParameter("axis2", "0");
            request.AddParameter("axis3", "0");
            request.AddParameter("axis4", j4torquestr_neg);
            request.AddParameter("axis5", "0");
            request.AddParameter("axis6", "0");
            request.AddParameter("ccount", "17");
            request.AddParameter("inc-mode", torqueincrement);

            var restResponse = await client.ExecuteTaskAsync(request);
        }
    }

    public async void JogJ5()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        while (buttonpush)
        {

            var request = new RestRequest(Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

            request.AddParameter("axis1", "0");
            request.AddParameter("axis2", "0");
            request.AddParameter("axis3", "0");
            request.AddParameter("axis4", "0");
            request.AddParameter("axis5", j5torquestr);
            request.AddParameter("axis6", "0");
            request.AddParameter("ccount", "17");
            request.AddParameter("inc-mode", torqueincrement);

            var restResponse = await client.ExecuteTaskAsync(request);
        }
    }

    public async void JogJ5Neg()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        while (buttonpush)
        {

            var request = new RestRequest(Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

            request.AddParameter("axis1", "0");
            request.AddParameter("axis2", "0");
            request.AddParameter("axis3", "0");
            request.AddParameter("axis4", "0");
            request.AddParameter("axis5", j5torquestr_neg);
            request.AddParameter("axis6", "0");
            request.AddParameter("ccount", "17");
            request.AddParameter("inc-mode", torqueincrement);

            var restResponse = await client.ExecuteTaskAsync(request);
        }
    }

    public async void JogJ6()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        while (buttonpush)
        {

            var request = new RestRequest(Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

            request.AddParameter("axis1", "0");
            request.AddParameter("axis2", "0");
            request.AddParameter("axis3", "0");
            request.AddParameter("axis4", "0");
            request.AddParameter("axis5", "0");
            request.AddParameter("axis6", j6torquestr);
            request.AddParameter("ccount", "17");
            request.AddParameter("inc-mode", torqueincrement);

            var restResponse = await client.ExecuteTaskAsync(request);
        }
    }

    public async void JogJ6Neg()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        while (buttonpush)
        {

            var request = new RestRequest(Method.POST);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

            request.AddParameter("axis1", "0");
            request.AddParameter("axis2", "0");
            request.AddParameter("axis3", "0");
            request.AddParameter("axis4", "0");
            request.AddParameter("axis5", "0");
            request.AddParameter("axis6", j6torquestr_neg);
            request.AddParameter("ccount", "17");
            request.AddParameter("inc-mode", torqueincrement);

            var restResponse = await client.ExecuteTaskAsync(request);
        }
    }

    public void JogJ1SingleTime()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        request.AddParameter("axis1", j1torquestr);
        request.AddParameter("axis2", "0");
        request.AddParameter("axis3", "0");
        request.AddParameter("axis4", "0");
        request.AddParameter("axis5", "0");
        request.AddParameter("axis6", "0");
        request.AddParameter("ccount", "17");
        request.AddParameter("inc-mode", torqueincrement);

        IRestResponse response = client.Execute(request);

    }

    public void JogJ1SingleTimeNeg()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        request.AddParameter("axis1", j1torquestr_neg);
        request.AddParameter("axis2", "0");
        request.AddParameter("axis3", "0");
        request.AddParameter("axis4", "0");
        request.AddParameter("axis5", "0");
        request.AddParameter("axis6", "0");
        request.AddParameter("ccount", "17");
        request.AddParameter("inc-mode", torqueincrement);

        IRestResponse response = client.Execute(request);

    }

    public void JogJ2SingleTime()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        request.AddParameter("axis1", "0");
        request.AddParameter("axis2", j2torquestr);
        request.AddParameter("axis3", "0");
        request.AddParameter("axis4", "0");
        request.AddParameter("axis5", "0");
        request.AddParameter("axis6", "0");
        request.AddParameter("ccount", "17");
        request.AddParameter("inc-mode", torqueincrement);

        IRestResponse response = client.Execute(request);

    }

    public void JogJ2SingleTimeNeg()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        request.AddParameter("axis1", "0");
        request.AddParameter("axis2", j2torquestr_neg);
        request.AddParameter("axis3", "0");
        request.AddParameter("axis4", "0");
        request.AddParameter("axis5", "0");
        request.AddParameter("axis6", "0");
        request.AddParameter("ccount", "17");
        request.AddParameter("inc-mode", torqueincrement);

        IRestResponse response = client.Execute(request);

    }

    public void JogJ3SingleTime()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        request.AddParameter("axis1", j3torquestr);
        request.AddParameter("axis2", "0");
        request.AddParameter("axis3", "0");
        request.AddParameter("axis4", "0");
        request.AddParameter("axis5", "0");
        request.AddParameter("axis6", "0");
        request.AddParameter("ccount", "17");
        request.AddParameter("inc-mode", torqueincrement);

        IRestResponse response = client.Execute(request);

    }

    public void JogJ3SingleTimeNeg()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        request.AddParameter("axis1", j3torquestr_neg);
        request.AddParameter("axis2", "0");
        request.AddParameter("axis3", "0");
        request.AddParameter("axis4", "0");
        request.AddParameter("axis5", "0");
        request.AddParameter("axis6", "0");
        request.AddParameter("ccount", "17");
        request.AddParameter("inc-mode", torqueincrement);

        IRestResponse response = client.Execute(request);

    }

    public void JogJ4SingleTime()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        request.AddParameter("axis1", j4torquestr);
        request.AddParameter("axis2", "0");
        request.AddParameter("axis3", "0");
        request.AddParameter("axis4", "0");
        request.AddParameter("axis5", "0");
        request.AddParameter("axis6", "0");
        request.AddParameter("ccount", "17");
        request.AddParameter("inc-mode", torqueincrement);

        IRestResponse response = client.Execute(request);

    }

    public void JogJ4SingleTimeNeg()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        request.AddParameter("axis1", j4torquestr_neg);
        request.AddParameter("axis2", "0");
        request.AddParameter("axis3", "0");
        request.AddParameter("axis4", "0");
        request.AddParameter("axis5", "0");
        request.AddParameter("axis6", "0");
        request.AddParameter("ccount", "17");
        request.AddParameter("inc-mode", torqueincrement);

        IRestResponse response = client.Execute(request);

    }

    public void JogJ5SingleTime()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        request.AddParameter("axis1", j5torquestr);
        request.AddParameter("axis2", "0");
        request.AddParameter("axis3", "0");
        request.AddParameter("axis4", "0");
        request.AddParameter("axis5", "0");
        request.AddParameter("axis6", "0");
        request.AddParameter("ccount", "17");
        request.AddParameter("inc-mode", torqueincrement);

        IRestResponse response = client.Execute(request);

    }

    public void JogJ5SingleTimeNeg()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        request.AddParameter("axis1", j5torquestr_neg);
        request.AddParameter("axis2", "0");
        request.AddParameter("axis3", "0");
        request.AddParameter("axis4", "0");
        request.AddParameter("axis5", "0");
        request.AddParameter("axis6", "0");
        request.AddParameter("ccount", "17");
        request.AddParameter("inc-mode", torqueincrement);

        IRestResponse response = client.Execute(request);

    }

    public void JogJ6SingleTime()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        request.AddParameter("axis1", j6torquestr);
        request.AddParameter("axis2", "0");
        request.AddParameter("axis3", "0");
        request.AddParameter("axis4", "0");
        request.AddParameter("axis5", "0");
        request.AddParameter("axis6", "0");
        request.AddParameter("ccount", "17");
        request.AddParameter("inc-mode", torqueincrement);

        IRestResponse response = client.Execute(request);

    }

    public void JogJ6SingleTimeNeg()
    {
        var client = new RestClient("http://localhost/rw/motionsystem?action=jog");
        client.Timeout = -1;
        client.CookieContainer = login_cookie;

        var request = new RestRequest(Method.POST);

        request.AddHeader("Accept", "application/json");
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded;v=2.0");

        request.AddParameter("axis1", j6torquestr_neg);
        request.AddParameter("axis2", "0");
        request.AddParameter("axis3", "0");
        request.AddParameter("axis4", "0");
        request.AddParameter("axis5", "0");
        request.AddParameter("axis6", "0");
        request.AddParameter("ccount", "17");
        request.AddParameter("inc-mode", torqueincrement);

        IRestResponse response = client.Execute(request);

    }
}


