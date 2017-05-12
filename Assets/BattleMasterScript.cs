using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMasterScript : MonoBehaviour {
    private Transform cameraTransform;
    private GameObject[] actionIndicators;
    private int beatChance;
    private int halfBeatChance;
    private int quarterBeatChance;
    private int criticalChance;
    private float bpm;
    private float beatInterval;
    private float halfBeatInterval;
    private float quarterBeatInterval;
    private int beatCount;
    
    /* --------------------------------------------------
    Built-in Methods
    -------------------------------------------------- */
	void Start() {
		cameraTransform = transform.Find("Main Camera").transform;
        beatChance = 100;
        halfBeatChance = 30;
        quarterBeatChance = 10;
        criticalChance = 10;
        bpm = 60.0f;
        beatInterval = 1 / (bpm / 60.0f);
        quarterBeatInterval = beatInterval / 4;
        beatCount = 0;
        
        InvokeRepeating("instantiateByChance", 0, quarterBeatInterval);
	}
	
	void Update() {
        // Handle inputs
		if (Input.GetKeyDown(KeyCode.Space)) {
            foreach (Transform child in cameraTransform) {
                ActionIndicatorScript script = child.GetComponent<ActionIndicatorScript>();
                
                if (child.name == "ActionIndicator" && script.active) {
                    script.acceptInput();
                }
            }
        }
	}
    
    /* --------------------------------------------------
    Custom Methods
    -------------------------------------------------- */
    
    void instantiateByChance() {
        int roll = Random.Range(0, 100);
        bool instantiated = false;
        
        beatCount++;
        
        switch (beatCount) {
            case 1: // Beat
                if (roll <= beatChance) {
                    instantiated = true;
                    cameraTransform.GetComponent<MainCameraScript>()
                        .InstantiateActionIndicator(criticalChance);
                }
                break;
            case 3: // Half beat
                if (roll <= halfBeatChance) {
                    instantiated = true;
                    cameraTransform.GetComponent<MainCameraScript>()
                        .InstantiateActionIndicator(criticalChance);
                }
                break;
            default: // Quarter beat
                if (roll <= quarterBeatChance) {
                    instantiated = true;
                    cameraTransform.GetComponent<MainCameraScript>()
                        .InstantiateActionIndicator(criticalChance);
                }
                break;
        }
        
        if (instantiated == true) {
            Invoke("flashActiveArea", 2.0f);
        }
        
        if (beatCount == 4) { // Reset
            beatCount = 0;
        }
    }
    
    void flashActiveArea() {
        ActiveAreaScript script = cameraTransform.Find("ActiveArea").GetComponent<ActiveAreaScript>();
        
        script.flash();
    }
}
