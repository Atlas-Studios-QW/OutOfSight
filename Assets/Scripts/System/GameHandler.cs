using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public List<Light> LightSources;

    //Put the controller onto every lighting object in the scene
    private void Start()
    {
        foreach (Light Lightsource in FindObjectsOfType(typeof(Light),true))
        {
            LightSources.Add(Lightsource);
            Lightsource.gameObject.AddComponent<ObjectsController>();
        }
    }
}
