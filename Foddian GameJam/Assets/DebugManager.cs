using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        Debug.developerConsoleVisible = false;
    }
}
