using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsController : MonoBehaviour
{
    Light LightSource;

    //Get the lightsource from the object
    private void Start()
    {
        LightSource = GetComponent<Light>();
    }

    private void OnTriggerStay(Collider Object)
    {
        print(Object);
        if (Object.transform.parent.tag == "Hideable")
        {
            Object.transform.parent.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider Object)
    {
        print(Object);
        if (Object.transform.parent.tag == "Hideable")
        {
            Object.transform.parent.gameObject.SetActive(false);
        }
    }
}
