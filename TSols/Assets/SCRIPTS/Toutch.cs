using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toutch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            int i = 0;
            Touch touch = Input.GetTouch(i);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    Debug.Log("Finger " + i + " " + hit.collider.name);
                    hit.collider.SendMessage("Touched", SendMessageOptions.DontRequireReceiver);
                }
            }
            ++i;
        }
    }
}
