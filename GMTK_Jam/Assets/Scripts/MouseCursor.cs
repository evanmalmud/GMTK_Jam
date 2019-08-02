using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MouseCursor : MonoBehaviour
{
    private Camera cam;

    private Vector3 cursorPosition;

    private bool IsShot; // = false

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsShot && Input.GetMouseButtonDown(0)) {
            IsShot = true;
            FindObjectOfType<BulletController>().SetAxisSpeed(cam.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
