using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Light Light;

    //Just toggles a light on and off... The spicy stuff is in the other scripts
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
