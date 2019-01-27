using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrater : MonoBehaviour
{

    [SerializeField]
    private int vibCount;

    [SerializeField,Range(500,3999)]
    private int vibPower;

    // Update is called once per frame
    void Update()
    {
        var trackedObject = GetComponent<SteamVR_TrackedObject>();
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            // トリガーを深く引いている
            device.TriggerHapticPulse((ushort)vibPower);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Vib());
        }
    }

    IEnumerator Vib()
    {
        var trackedObject = GetComponent<SteamVR_TrackedObject>();
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        for(int i = 0; i < vibCount; i++)
        {
            device.TriggerHapticPulse((ushort)vibPower);

            yield return null;
        }

    }
}
