using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateReplay.Example;
using UltimateReplay.Storage;
using UnityEngine;
using UltimateReplay;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Experimental.UI;

public class BeginRecordingRobot : MonoBehaviour
{
    public bool recordOnStart = false;
    private ReplayStorageTarget storageTarget = new ReplayMemoryTarget();
    private ReplayHandle recordHandle = ReplayHandle.invalid;
    private ReplayHandle playbackHandle = ReplayHandle.invalid;

    private ReplayScene recordScene = null;
    private ReplayScene playbackScene = null;
    public float t;
    private PlaybackOrigin replaybehavior = PlaybackOrigin.Start;
    private bool defaultvalue = false;
    private bool restorescene = false;

    public ReplayHandle RecordHandle
    {
        get { return recordHandle; }
    }

    public ReplayHandle PlaybackHandle
    {
        get { return playbackHandle; }
    }

    public void RecordRobotMotion() {

        recordOnStart = true;

    if (recordOnStart == true) { 
                recordHandle = ReplayManager.BeginRecording(storageTarget, null, false, true, null);
        }
    }

    public void ReplayGoLive()
    {
        // Stop all recording
        if (ReplayManager.IsRecording(recordHandle) == true)
            ReplayManager.StopRecording(ref recordHandle);
    }

    public void ReplayRobotMotion()
    {
        playbackHandle = ReplayManager.BeginPlayback(storageTarget, playbackScene);
    }

    /* public static void SetPlaybackTimeNormalized(ReplayHandle playbackHandle, float t, PlaybackOrigin replaybehavior)
     {
         //ReplayHandle.BeginPlaybackFrame(storageTarget, playbackScene, defaultvalue, replayoptions);
     }

   public static ReplayHandle BeginPlaybackFrame(ReplayStorageTarget storageTarget, ReplayScene playbackScene, bool defaultvalue, ReplayPlaybackOptions replayoptions)
     {

     }
    */

    public static void StopPlayback(ref ReplayHandle playbackHandle, bool restorescene)
    {
        // Stop all playback
        if (ReplayManager.IsReplaying(playbackHandle) == true)
            ReplayManager.StopPlayback(ref playbackHandle);
    }

    public void LaunchMotion(SliderEventData eventData)
    {
        playbackHandle = ReplayManager.BeginPlayback(storageTarget, playbackScene);
    }

    public void SliderMotion(SliderEventData eventData)
    {
        t = eventData.NewValue;

        ReplayManager.SetPlaybackTimeNormalized(playbackHandle, t, PlaybackOrigin.Start);

        ReplayManager.BeginPlaybackFrame(storageTarget, playbackScene, false, true);
    }

    public void PauseMotion(SliderEventData eventData)
    {
        ReplayManager.StopPlayback(ref playbackHandle);
        StopPlayback(ref playbackHandle, restorescene);
    }

}
