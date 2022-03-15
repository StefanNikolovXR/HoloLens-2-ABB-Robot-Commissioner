using HeathenEngineering.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.UX
{
    public class CommandParserExampleScript : MonoBehaviour
    {
        public UnityEngine.UI.InputField inputField;

        public string kbUrl;
        public string geUrl;
        public string discordUrl;
        public string assetUrl;

        public void CommandRaised(CommandData data)
        {
            if(data.isValid)
            {
                Debug.Log("Detected event: '" + data.command.name + "' with the arguments of '" + data.arguments + "'");

                if (data.command.GetType() == typeof(StringGameEvent))
                {
                    //Example of invoking the command with an argument
                    ((StringGameEvent)data.command).Invoke(this, data.arguments);
                }
                else
                {
                    //Example of invoking the command without an argument
                    data.command.Invoke(this);
                }
            }
        }

        public void ClearInput()
        {
            inputField.text = string.Empty;
        }

        public void OpenKb()
        {
            UnityEngine.Application.OpenURL(kbUrl);
        }

        public void OpenGe()
        {
            UnityEngine.Application.OpenURL(geUrl);
        }

        public void OpenDiscord()
        {
            UnityEngine.Application.OpenURL(discordUrl);
        }

        public void OpenAsset()
        {
            UnityEngine.Application.OpenURL(assetUrl);
        }
    }
}
