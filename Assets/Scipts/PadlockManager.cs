using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class PadlockManager : MonoBehaviour
{
    [SerializeField]
    public bool isResolved = false;

    LeanDragTranslate translate;

    LPLockpicking doorLock;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[Lock] Started");
        transform.position = transform.parent.transform.position;
        transform.rotation = Quaternion.Euler(90, 0, 0);
        isResolved = false;
        translate = GetComponent<LeanDragTranslate>();
        doorLock = GetComponentInParent<LPLockpicking>();
        translate.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isResolved) {
            translate.enabled = true;
            Debug.Log("[Lock] isResolved");
        }
    }

    // Update is called once per frame
    public void OnTap ()
    {
        if (!isResolved)
        {
            doorLock.Activate(this);
        }
    }
}
