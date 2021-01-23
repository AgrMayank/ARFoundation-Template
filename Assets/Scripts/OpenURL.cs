using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public string URL = "https://agrmayank.github.io";

    public void OpenURLInBrowser()
    {
        Application.OpenURL(URL);
    }
}
