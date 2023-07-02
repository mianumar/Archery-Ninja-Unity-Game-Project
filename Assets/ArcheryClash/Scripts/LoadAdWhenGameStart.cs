using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAdWhenGameStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Adcontrol.instace.showAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
