using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameInput input;
    void Start()
    {
        input.crouch = KeyCode.C;
        input.run = KeyCode.LeftShift;
        input.jumping = KeyCode.Space;
    }

    
}
