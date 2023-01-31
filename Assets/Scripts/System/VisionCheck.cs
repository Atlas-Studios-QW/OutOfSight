using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCheck : MonoBehaviour
{
    [Header("Connect Objects")]
    public Light FlashLightSource;

    public List<Transform> SeenObjects = new List<Transform>();

    private void OnTriggerEnter(Collider SeenObject)
    {
        if (FlashLightSource.enabled)
        {
            SeenObjects.Add(SeenObject.transform.parent);
        }
    }

    private void OnTriggerExit(Collider ObjectCollider)
    {
        if (FlashLightSource.enabled)
        {
            try { SeenObjects.Remove(ObjectCollider.transform.parent); } catch { }
            Destroy(ObjectCollider.transform.parent.gameObject);
        }
    }

    private void Update()
    {
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
                    print(hit.transform.tag);
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
