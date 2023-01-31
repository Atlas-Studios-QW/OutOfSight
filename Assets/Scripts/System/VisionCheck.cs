using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCheck : MonoBehaviour
{
    [Header("Connect Objects")]
    public Light FlashLightSource;

    public List<Transform> SeenObjects = new List<Transform>();

    //When an object comes into view, put it into a list so it can be checked with a raycast.
    private void OnTriggerEnter(Collider SeenObject)
    {
        if (FlashLightSource.enabled)
        {
            SeenObjects.Add(SeenObject.transform.parent);
        }
    }

    //Whenever an object leaves the light of the flashlight, make it disappear.
    private void OnTriggerExit(Collider ObjectCollider)
    {
        if (FlashLightSource.enabled)
        {
            try { SeenObjects.Remove(ObjectCollider.transform.parent); } catch { }
            Destroy(ObjectCollider.transform.parent.gameObject);
        }
    }

    //Check every object for view obstuctions.
    private void Update()
    {
        //Check if flashlight is enabled, if not, delete every object that is still in the list.
        if (FlashLightSource.enabled)
        {
            foreach (Transform Object in SeenObjects)
            {
                if (Object == null)
                {
                    SeenObjects.Remove(Object);
                }

                RaycastHit hit;
                if (Physics.Linecast(FlashLightSource.transform.position, Object.position, out hit))
                {
                    if (hit.transform.tag != "LooseObject")
                    {
                        SeenObjects.Remove(Object);
                        Destroy(Object.gameObject);
                    }
                }
            }
        }
        else
        {
            foreach (Transform Object in SeenObjects)
            {
                Destroy(Object.gameObject);
            }
            SeenObjects = new List<Transform>();
        }
    }
}
