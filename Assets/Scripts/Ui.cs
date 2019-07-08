using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{

    public GameObject panel;
    public GameObject god;
    public Text Population;
    // Start is called before the first frame update
    void Start()
    {
        int width = Screen.width;
        panel.transform.position = new Vector3(width*0.21875f, Screen.height / 2, 0);
        panel.transform.localScale = new Vector2(width*0.4375f, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
