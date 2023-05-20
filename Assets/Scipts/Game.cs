using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private bool kitCollected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectKit(GameObject obj)
    {
        Debug.Log("[Game] CollectKit");
        obj.SetActive(false);
        kitCollected = true;    
    }
}
