using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toutch : MonoBehaviour
{
    [SerializeField] private Camera CameraUsed;
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            int i = 0;
            Touch touch = Input.GetTouch(i);
            Ray ray = CameraUsed.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //Debug.Log("Finger " + i + " " + hit.collider.name);
                    hit.collider.SendMessage("Touched", SendMessageOptions.DontRequireReceiver);
                }
            }
            ++i;
        }
    }
}
