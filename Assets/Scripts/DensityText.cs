using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DensityText : MonoBehaviour
{
    public Slider density;
    Text number;
    // Start is called before the first frame update
    void Start()
    {
        number = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        number.text = density.value.ToString();
    }
}
