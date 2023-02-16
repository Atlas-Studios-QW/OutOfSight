using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public List<Light> Lights;

    public void ToggleLights()
    {
        print("Lightswitch");
        foreach (Light light in Lights)
        {
            light.enabled = !light.enabled;
        }
    }
}
