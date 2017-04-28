using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAreaScript : MonoBehaviour {
    const float DEFAULT_ALPHA = 0.2f;
    const float FLASHED_ALPHA = 0.4f;
    
    /* --------------------------------------------------
    Custom Methods
    -------------------------------------------------- */
    Color getCurrentColor() {
        return transform.GetComponent<SpriteRenderer>().color;
    }
    
    void resetAlpha() {
        Color newColor = getCurrentColor();
        
        newColor.a = DEFAULT_ALPHA;
        transform.GetComponent<SpriteRenderer>().color = newColor;
    }
    
    public void flash() {
        Color newColor = getCurrentColor();
        
        newColor.a = FLASHED_ALPHA;
        transform.GetComponent<SpriteRenderer>().color = newColor;
        Invoke("resetAlpha", 0.1f);
    }
}
