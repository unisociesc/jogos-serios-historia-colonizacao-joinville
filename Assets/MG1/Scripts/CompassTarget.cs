using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassTarget : MonoBehaviour {
    
    RectTransform rt;
    public Transform target;

    void Start() {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() {
        // Pega a posicao do objeto no espaco da tela
        Vector3 objScreenPos = Camera.main.WorldToScreenPoint(target.transform.position);

        // Pega a direcao entre o compasso e a TargetArea
        Vector3 dir = (objScreenPos - rt.position).normalized;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(dir.z, dir.x);
        rt.rotation = Quaternion.AngleAxis(angle - 145, Vector3.forward);
    }
}
