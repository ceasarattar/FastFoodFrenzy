using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItem : MonoBehaviour
{

    public Transform cloneObj;
    public int foodValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnButtonE()
    {
        if (gameObject.name == "Soda can")
            Instantiate(cloneObj, new Vector3(0, .10f, 0), cloneObj.rotation);

        if (gameObject.name == "Soda bottle")
            Instantiate(cloneObj, new Vector3(0, .60f, 0), cloneObj.rotation);

        if (gameObject.name == "Cookie")
            Instantiate(cloneObj, new Vector3(0, .62f, -.05f), cloneObj.rotation);

        if (gameObject.name == "Chocolate Donut")
            Instantiate(cloneObj, new Vector3(0, .10f, 0), cloneObj.rotation);

        if (gameObject.name == "Hotdog")
            Instantiate(cloneObj, new Vector3(0, .10f, 0), cloneObj.rotation);
    }
}
