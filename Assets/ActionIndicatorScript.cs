using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionIndicatorScript : MonoBehaviour {
    const float distance = 8.0f;
    public bool active = false;
        
    /* --------------------------------------------------
    Built-in Methods
    -------------------------------------------------- */
	void Update() {
		transform.Translate(Vector3.left * (Time.deltaTime * distance));
	}
    
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
    
    void OnTriggerEnter2D() {
        active = true;
    }
    
    void OnTriggerExit2D() {
        active = false;
    }
    
    /* --------------------------------------------------
    Custom Methods
    -------------------------------------------------- */
    public void acceptInput() {
        Destroy(gameObject);
    }
}
