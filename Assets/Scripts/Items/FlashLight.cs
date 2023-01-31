using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Light Light;

    public void ToggleLight()
    {
        if (Light.enabled)
        {
            Light.enabled = false;
        } 
        else
        {
            Light.enabled = true;
        }
    }
}
