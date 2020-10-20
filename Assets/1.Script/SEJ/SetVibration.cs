using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVibration : MonoBehaviour
{
    public static SetVibration setVibration;

    void Start()
    {
        if(setVibration && setVibration != this)
        {
            Destroy(this);
        }
        else
        {
            setVibration = this;
        }
    }

    public void TriggerVibration(AudioClip vibrationAudio, OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip(vibrationAudio);
        if(controller == OVRInput.Controller.LTouch)
        {
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if(controller == OVRInput.Controller.RTouch)
        {
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }

    public void TriggerVibration(int iteration, int frequency, int strength, OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i = 0; i < iteration; i++)
        {
            clip.WriteSample(i % frequency == 0 ? (byte)strength : (byte)0);
        }
        if (controller == OVRInput.Controller.LTouch)
        { 
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if(controller == OVRInput.Controller.RTouch)
        {
            OVRHaptics.RightChannel.Preempt(clip);
        }    
    }

    void Update()
    {
        
    }
}
