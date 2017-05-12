using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour {
    private GameObject actionIndicatorResource;
    private GameObject criticalActionIndicatorResource;
    
    /* --------------------------------------------------
    Built-in Methods
    -------------------------------------------------- */
    void Start() {
        actionIndicatorResource = Resources.Load("ActionIndicator") as GameObject;
        criticalActionIndicatorResource = Resources.Load("CriticalActionIndicator") as GameObject;
    }
    
    public void InstantiateActionIndicator(int criticalChance) {
        int roll = Random.Range(0, 100);
        GameObject instance;
        
        if (roll <= criticalChance) {
            instance = Instantiate(criticalActionIndicatorResource);
        } else {
            instance = Instantiate(actionIndicatorResource);
        }
        
        // Move down to be this MainCamera's child
        instance.transform.parent = transform;
        instance.transform.name = "ActionIndicator";
    }
}
