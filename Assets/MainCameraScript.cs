using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour {
    private GameObject actionIndicatorResource;
    
    /* --------------------------------------------------
    Built-in Methods
    -------------------------------------------------- */
    void Start() {
        actionIndicatorResource = Resources.Load("ActionIndicator") as GameObject;
    }
    
    public void InstantiateActionIndicator() {
        GameObject instance = Instantiate(actionIndicatorResource);
        
        instance.transform.parent = transform;
        instance.transform.name = "ActionIndicator";
    }
}
