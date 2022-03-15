using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.Windows.Speech;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;

public class LUISCoordinateParser : MonoBehaviour
{
    [Header("LUIS Credentials")]
    public string luisEndpoint = "";

    DictationRecognizer dictationRecognizer;
    LunarcomController lunarcomController;
    ///bool micPermissionGranted = false;
    string recognizedString;
    bool capturingAudio = false;
    bool commandCaptured = false;

    public GameObject TargetedObject;

    public float DefaultMoveSpeed = 2;

    public float DefaultMoveDistance = 10;

    public float distancetotravel;

    public Vector3 NewPosition;

    public CreateSafeZone createzone;
    public GameObject SpawnZoneOnTap, HandIndicators;
    public LUISTutorial luisanimations;

    public TMP_InputField j1_lower, j1_upper;

    public GameObject j3;

    public LeanRotateJoints leanrotate;

    public ZoneValues values;

    public LunarcomButtonController lunarcom;

    void Start()
    {
        TargetedObject = GameObject.Find("LUIS_Assistant");

        lunarcomController = LunarcomController.lunarcomController;

        if (lunarcomController.outputbox.ToolTipText == null)
        {
            Debug.LogError("outputText property is null! Assign a UI Text element to it.");
        }
        else
        {
            ///micPermissionGranted = true;
        }

        lunarcomController.onSelectRecognitionMode += HandleOnSelectRecognitionMode;
    }

    public void HandleOnSelectRecognitionMode(RecognitionMode recognitionMode)
    {
        if (recognitionMode == RecognitionMode.Intent_Recognizer)
        {
            lunarcomController.outputbox.ToolTipText = "I'm listening to your command!";
            BeginRecognizing();
        }
        else
        {
            if (capturingAudio)
            {
                StopCapturingAudio();
            }
            recognizedString = "";
            commandCaptured = false;
        }
    }

    private void BeginRecognizing()
    {
        if (Microphone.devices.Length > 0)
        {
            if (dictationRecognizer == null)
            {
                dictationRecognizer = new DictationRecognizer
                {
                    InitialSilenceTimeoutSeconds = 60,
                    AutoSilenceTimeoutSeconds = 5
                };

                dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
                dictationRecognizer.DictationError += DictationRecognizer_DictationError;
            }


            if (dictationRecognizer.Status == SpeechSystemStatus.Stopped)
            {
                dictationRecognizer.Start();
            }
            capturingAudio = true;
        }
    }

    public void StopCapturingAudio()
    {
        if (dictationRecognizer != null && dictationRecognizer.Status != SpeechSystemStatus.Stopped)
        {
            dictationRecognizer.DictationResult -= DictationRecognizer_DictationResult;
            dictationRecognizer.DictationError -= DictationRecognizer_DictationError;
            dictationRecognizer.Stop();
            dictationRecognizer = null;
            capturingAudio = false;
        }
    }

    private void DictationRecognizer_DictationResult(string dictationCaptured, ConfidenceLevel confidence)
    {
        //StopCapturingAudio();
        StartCoroutine(SubmitRequestToLuis(dictationCaptured, BeginRecognizing));
        recognizedString = dictationCaptured;
        print(recognizedString);
    }

    private void DictationRecognizer_DictationError(string error, int hresult)
    {
        Debug.Log("Dictation exception: " + error);
    }

    [Serializable]
    class AnalysedQuery
    {
        public string query = default;
        public TopScoringIntentData prediction = default;
        //public EntityData[] entities = default;
        ///public string query;
    }

    [Serializable]
    class TopScoringIntentData
    {
        public string topIntent = default;
        public EntityData entities = default;
        ///public float score;
    }

    [Serializable]
    class EntityData
    {
        public string[] MoveDistance = default;
        public string[] MoveDirection = default;
        public string[] create = default;
        public string[] element = default;
        public string[] secondelement = default;
        public string[] verticenumber = default;
        public string[] safemovedatatype = default;
        public string[] safemovevalue = default;
        public string[] rotationvalue = default;
        public string[] joint = default;
        ///public int startIndex;
        ///public int endIndex;
        ///public float score;
    }

    public IEnumerator SubmitRequestToLuis(string dictationResult, Action done)
    {
        string queryString = string.Concat(Uri.EscapeDataString(dictationResult));

        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(luisEndpoint + queryString))
        {
            yield return unityWebRequest.SendWebRequest();

            if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            {
                Debug.Log(unityWebRequest.error);
            }
            else
            {
                try
                {
                    AnalysedQuery analysedQuery = JsonUtility.FromJson<AnalysedQuery>(unityWebRequest.downloadHandler.text);
                    Debug.Log("Analysis query: " + analysedQuery);
                    UnpackResults(analysedQuery);
                }
                catch (Exception exception)
                {
                    Debug.Log("Luis Request Exception Message: " + exception.Message);
                    lunarcom.speechRecognitionMode = RecognitionMode.Disabled;
                    lunarcom.speechRecognitionMode = RecognitionMode.Intent_Recognizer;
                    lunarcom.ToggleSelected();
                    lunarcomController.outputbox.ToolTipText = $"Sorry, I couldn't understand your intent! Please try again.";
                }
            }

            done();
            yield return null;
        }
    }

    private void UnpackResults(AnalysedQuery aQuery)
    {
        string topIntent = aQuery.prediction.topIntent;

        Dictionary<string, string> entityDic = new Dictionary<string, string>();

        //foreach (EntityData ed in aQuery.prediction.entities)
        //{
        //    entityDic.Add(ed.type, ed.entity);
        //}

        switch (topIntent)
        {
            case "Execute":
                break;
            //string actionToTake = null;
            //string targetButton = null;

            /*     string actionToTake = aQuery.prediction.entities.Action[0];//Save action intent
               string targetButton = aQuery.prediction.entities.Target[0];//Save target intent

                  //foreach (var pair in entityDic)
                  //{
                  //    if (pair.Key == "Target")
                  //    {
                  //        targetButton = pair.Value;
                  //    }
                  //    else if (pair.Key == "Action")
                  //    {
                  //        actionToTake = pair.Value;
                  //    }
                  //}
                  ProcessResults(targetButton, actionToTake);
                  break;
              default:
                  ProcessResults();
                  break;*/

            case "Move":

                string DistancetoMove = aQuery.prediction.entities.MoveDistance[0];
                string DirectiontoMove = aQuery.prediction.entities.MoveDirection[0];

                ProcessMotion(DistancetoMove, DirectiontoMove);

                break;

            case "Create":

                string create = aQuery.prediction.entities.create[0];
                string element = aQuery.prediction.entities.element[0];
                string verticenumber = aQuery.prediction.entities.verticenumber[0];
                string secondelement = aQuery.prediction.entities.element[1];
               
                ProcessCreate(verticenumber);
                break;

            case "Edit":

                string safemove_value = aQuery.prediction.entities.safemovevalue[0];
                string safemove_data_type_upper = aQuery.prediction.entities.safemovedatatype[0];
                string safemove_data_type_lower = aQuery.prediction.entities.safemovedatatype[1];
                EditSafeMoveInfo(safemove_data_type_upper, safemove_value, safemove_data_type_lower);
                break;

            case "Rotate":
                string joint_num = aQuery.prediction.entities.joint[0];
                string rotationvalue_num = aQuery.prediction.entities.rotationvalue[0];
                RotateJoint(joint_num, rotationvalue_num);
                break;

            default:
                //lunarcomController.outputbox.ToolTipText = $"I couldn't understand your intent! Please try again.";
                break;
        }
        print(topIntent);
    }

    public void RotateJoint(string j, string rot)
    {
        float rot_parsed = float.Parse(rot);
        luisanimations.LUISRotate();
        leanrotate.MoveJ3(rot_parsed);

        lunarcomController.outputbox.ToolTipText = "Got it! I rotated Arm3 to " + rot + " degrees.";
    }

    public void EditSafeMoveInfo(string safemove_type1, string safemove_val1, string safemove_type2)
    {
        luisanimations.LUISInputValue();
        j1_lower.text = "-" + safemove_val1;
        j1_upper.text = safemove_val1;
        j1_lower.text = j1_lower.text.Replace("degrees", "");
        j1_upper.text = j1_upper.text.Replace("degrees", "");
        values.DataChanged();
        lunarcomController.outputbox.ToolTipText = "Got it! I changed the global lower limit of Rot1 to -" + safemove_val1 + " and the global upper limit of Rot1 to " + safemove_val1;
    }

    public void StoreHovered(GameObject hoveredobject)
    {
        TargetedObject = hoveredobject;
        NewPosition = TargetedObject.transform.position;
    }

    public void WipeHovered()
    {
        TargetedObject = null;
    }

    /*  public void ProcessResults(string targetButton = null, string actionToTake = null)
      {
          switch (targetButton)
          {
              case "launch":
                  CompleteButtonPress(actionToTake, targetButton, LaunchButton);
                  break;
              case "reset":
                  CompleteButtonPress(actionToTake, targetButton, ResetButton);
                  break;
              case "hint":
                  CompleteButtonPress(actionToTake, targetButton, HintsButton);
                  break;
              case "hints":
                  CompleteButtonPress(actionToTake, targetButton, HintsButton);
                  break;
              default:
                  CompleteButtonPress();
                  break;
          }
      }*/

    public void ProcessMotion(string processedmotion, string processeddirection)
    {

        Vector3 moveDir = Vector3.zero;

        float moveDistance = DefaultMoveDistance;

        moveDir = GetEntityDirection(processeddirection);

        moveDistance = float.Parse(processedmotion);

        print(moveDistance);
        print(processedmotion);
        print(processeddirection);

        NewPosition += moveDir * moveDistance;

    }

    Vector3 GetEntityDirection(string direction)
    {
        switch (direction)
        {
            case "forwards":
                return Vector3.forward;
            case "backwards":
                return Vector3.back;
            case "back":
                return Vector3.back;
            case "left":
                return Vector3.left;
            case "right":
                return Vector3.right;
        }

        return Vector3.zero;
    }

    public void ProcessCreate(string verticenumber)
    {
        var vertices = float.Parse(verticenumber);

        createzone.numberofedges = vertices;
        SpawnZoneOnTap.SetActive(true);
        HandIndicators.SetActive(true);

        luisanimations.LUISCommandAcceptedCounting();

        lunarcomController.outputbox.ToolTipText = "Got it! The next time you make a tap gesture, you will create a zone with " + vertices + " edges";

    }

    /*   private void CompleteButtonPress(string actionToTake = null, string buttonName = null, GameObject buttonToPush = null)
       {
           recognizedString += (actionToTake != null) ? "\n\nAction: " + actionToTake : "\n\nAction: -";
           recognizedString += (buttonName != null) ? "\nTarget: " + buttonName : "\nTarget: -";

           if (actionToTake != null && buttonName != null && buttonToPush != null)
           {
               recognizedString += "\n\nCommand recognized, pushing the '" + buttonName + "' button because I was told to '" + actionToTake + "'";
               buttonToPush.GetComponent<Interactable>().OnClick.Invoke();
           }
           else
           {
               recognizedString += "\n\nCommand not recognized";
           }
           commandCaptured = true;
       }*/

    private void Update()
    {
        if (lunarcomController.CurrentRecognitionMode() == RecognitionMode.Intent_Recognizer)
        {
            //lunarcomController.UpdateLunarcomText(recognizedString);

            if (commandCaptured)
            {
                foreach (LunarcomButtonController button in lunarcomController.buttons)
                {
                    if (button.GetIsSelected())
                    {
                        button.DeselectButton();
                    }
                }
                commandCaptured = false;
            }
        }

      /*  if (TargetedObject.transform.position != NewPosition)
            distancetotravel = DefaultMoveSpeed * Time.deltaTime;
        TargetedObject.transform.position = Vector3.MoveTowards(TargetedObject.transform.position, NewPosition, distancetotravel);*/

    }

    void OnDestroy()
    {
        if (dictationRecognizer != null)
        {
            dictationRecognizer.Dispose();
        }
    }
}
