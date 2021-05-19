using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPopup : MonoBehaviour
{
    public GameObject uiObject;
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }

    void OnTriggerEnter(Collider triggerCollider) {
        if(triggerCollider.gameObject.tag == "Ship") {
            uiObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
