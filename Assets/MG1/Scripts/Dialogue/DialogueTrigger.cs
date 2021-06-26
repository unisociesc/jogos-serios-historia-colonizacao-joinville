using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject uiObject;

    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start() {
        uiObject.SetActive(false);
    }

    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, this);
    }

    void OnTriggerEnter(Collider triggerCollider) {
        if(triggerCollider.gameObject.tag == "Player") {
            TriggerDialogue();
            uiObject.SetActive(true);
        }
    }

    public void DestroyActor() {
        Destroy(gameObject);
    }
}
