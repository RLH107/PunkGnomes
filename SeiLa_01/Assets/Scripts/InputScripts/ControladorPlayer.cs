using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorPlayer : MonoBehaviour
{
    InputAction mover, girar;

    private void Awake()
    {
        InputActionsJogo iaj = new InputActionsJogo();
        mover = iaj.Jogo.Mover;
        girar = iaj.Jogo.Girar;
    }



    // Start is called before the first frame update
    void Start()
    {
        mover.Enable();
        girar.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,
            mover.ReadValue<float>()*5*Time.deltaTime);
        transform.Rotate(0,
            girar.ReadValue<float>()*180*Time.deltaTime,0);
    }
}
