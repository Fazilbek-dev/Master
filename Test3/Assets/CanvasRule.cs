using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRule : MonoBehaviour
{

    Touch touch;

    Transform tr;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) transform.eulerAngles = new Vector3(0, 0, 20.1f);
        var rotateNeed = Quaternion.LookRotation(Input.mousePosition - transform.position);
        //tr.eulerAngles = Quaternion.Euler(0, 0, rotateNeed);
    }
}
