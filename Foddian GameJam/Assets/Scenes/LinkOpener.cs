using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkOpener : MonoBehaviour
{
    public string Link;

    public void OpenLink()
    {
        Application.OpenURL(Link);
    }
}
