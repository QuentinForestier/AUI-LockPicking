using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class PlaneDetectionController : MonoBehaviour
{
    [SerializeField]
    private ARPlaneManager manager;

    [SerializeField]
    private GameObject kit;

    [SerializeField]
    private List<GameObject> hints;

    private int hintsCounter = 0;

    public float h_probability = 0.2f;
    public float v_probability = 0.2f;
    public float probabilityIncrease = 0.2f;

    private bool kitPlaced = false;

    // Start is called before the first frame update
    void Start()
    {

        manager.planesChanged += Manager_planesChanged;
    }



    private void Manager_planesChanged(ARPlanesChangedEventArgs obj)
    {
        if (obj.added.Count > 0)
        {
            ARPlane plane = obj.added[0];

            if (plane.alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.Vertical)
            {
                if(hintsCounter < hints.Count && AddObject(plane, ref v_probability, hints[hintsCounter])){
                    v_probability = 0.5f;
                    hintsCounter++;
                }
            }
            else
            {
                if (!kitPlaced)
                {
                    kitPlaced = AddObject(plane, ref h_probability, kit);
                }
            }
        }
    }

   


    private bool AddObject(ARPlane plane, ref float probability, GameObject obj)
    {
        if (Random.Range(0.0f, 1.0f) <= probability)
        {
            Debug.Log("[AddObject] Adding an object. Probability : " + probability);
            obj.transform.position = plane.transform.position;
            obj.SetActive(true);
            return true;
        }
        else
        {
            probability += probabilityIncrease;
            return false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
