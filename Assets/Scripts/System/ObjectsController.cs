using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsController : MonoBehaviour
{
    Light LightSource;

    bool PreviousState = false;

    List<Collider> CollidersInLight = new List<Collider>();

    //Get the lightsource from the object
    private void Start()
    {
        LightSource = GetComponent<Light>();
    }

    private void OnTriggerStay(Collider ObjectCollider)
    {
        try
        {
            if (ObjectCollider.transform.parent.tag == "Hideable" && LightSource.enabled)
            {
                GameObject Object = ObjectCollider.transform.parent.gameObject;
                Object.GetComponent<Rigidbody>().isKinematic = false;
                Object.GetComponent<MeshRenderer>().enabled = true;
                if (CollidersInLight.IndexOf(ObjectCollider) == -1)
                {
                    CollidersInLight.Add(ObjectCollider);
                }
            }
        } catch {}
    }

    private void OnTriggerExit(Collider ObjectCollider)
    {
        CollidersInLight.Remove(ObjectCollider);
        HideObject(ObjectCollider);
    }

    private void Update()
    {
        if (PreviousState && LightSource.enabled)
        {
            foreach (Collider ObjectCollider in CollidersInLight)
            HideObject(ObjectCollider);
        }
        PreviousState = LightSource.enabled;
    }

    private void HideObject(Collider ObjectCollider)
    {
        try
        {
            if (ObjectCollider.transform.parent.tag == "Hideable")
            {
                GameObject Object = ObjectCollider.transform.parent.gameObject;
                Object.GetComponent<Rigidbody>().isKinematic = true;
                Object.GetComponent<MeshRenderer>().enabled = false;
                CollidersInLight.Remove(ObjectCollider);
            }
        }
        catch { }
    }

}
