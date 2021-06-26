using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassTarget : MonoBehaviour {
    
    RectTransform rt;
    public Transform[] targets;
    public Transform activeTarget;

    void Start() {
        rt = GetComponent<RectTransform>();
        DialogueManager dialogueManager = GetComponent<DialogueManager>();

        SearchObject();
    }

    void Update() {
        if(!activeTarget) {
            SearchObject();
        }

        // Pega a posicao do objeto no espaco da tela
        Vector3 objScreenPos = Camera.main.WorldToScreenPoint(activeTarget.transform.position);

        // // Pega a direcao entre o compasso e a TargetArea
        Vector3 dir = (objScreenPos - rt.position).normalized;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(dir.z, dir.x);
        rt.rotation = Quaternion.AngleAxis(angle - 145, Vector3.forward);
    }

    void SearchObject() {
        for (int i = 0; i < targets.Length; i++) {
            if(targets[i]) {
                Debug.Log(targets[i]);
                activeTarget = targets[i];
                return;
            }
        }
    }
}
