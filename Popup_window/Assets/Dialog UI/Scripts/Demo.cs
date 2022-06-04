using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.Dialogs;

public class Demo : MonoBehaviour
{
    public string title = "YOU ARE GOING LIVE";
    public string message = "Please ensure you follow the Community Guidelines.";

    // Start is called before the first frame update
    void Start()
    {
        DialogUI.Instance
            .SetTitle(title)
            .SetMessage(message)
            .OnClose(() => Debug.Log("Closed"))
            .Show();   

        
    }

   
}
