using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{

    public string URL = "https://play.google.com/store/apps/dev?id=4906466646487874564";

    public void openLink()
    {
        Application.OpenURL(URL);
    }
}
