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

    // Update is called once per frame
    public void onWin()
    {
        
        translate.enabled = true;
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
