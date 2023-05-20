using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class PadlockManager : MonoBehaviour
{

    public LeanDragTranslate translate;

    public LPLockpicking doorLock;

    public LPLockActivator activatorSource;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[Lock] Started");
        transform.position = transform.parent.transform.position;
        transform.rotation = Quaternion.Euler(90, 0, 0);
        translate.enabled = false;
    }

    public void OnStopMoving()
    {
        if (translate.enabled)
        {
            GetComponent<Rigidbody>().isKinematic = false;

            Invoke("RemoveLock", 3);
        }


    }


    private void RemoveLock()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void onWin()
    {
        
        translate.enabled = true;
        transform.GetChild(0).transform.localPosition += new Vector3(0, 0.015f, 0);
        Debug.Log("[Lock] isResolved");
        
    }

    // Update is called once per frame
    public void OnTap ()
    {
        Debug.Log("[Lock] Tap");
        doorLock.gameObject.SetActive(true);
        doorLock.Activate(activatorSource);
    }
}
