using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Volume volume;
    [SerializeField]
    private ChannelMixer channelMixer;
    [SerializeField]
    private ColorAdjustments colorAdjustments;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SetEffect(0);
        if (Input.GetKeyDown(KeyCode.Z))
            SetEffect(1);
        if (Input.GetKeyDown(KeyCode.E))
            SetEffect(2);
    }
    public void SetEffect(int i)
    {
        if(i == 0)
        {
            volume.profile.components[0].active = true;
        }
        else if (i == 1)
        {
            volume.profile.components[0].active = false;
        }
        else if (i== 2){

        }
    }
}
