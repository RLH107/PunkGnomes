using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticFeedBack : MonoBehaviour
{
    private float TimeBeforeNextBuzTemplate = 2f;
    private float TimeBeforeNextBuz = 2f;

    private void Update()
    {
        if (TimeBeforeNextBuz > 0)
        {
            TimeBeforeNextBuz -= Time.deltaTime;
        }
        else
        {
            Vibration.VibratePeek();
            TimeBeforeNextBuz = TimeBeforeNextBuzTemplate;
            Debug.Log("V");
        }
    }
}
