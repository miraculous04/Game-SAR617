using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameInput input;
    void Start()
    {
        input.crouch = KeyCode.C;
        input.jump = KeyCode.Space;
    }

    
}
