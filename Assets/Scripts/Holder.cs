using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Holder : MonoBehaviour
{
    public InputField textX, textY;
    public Toggle isRandom;
    public Slider dense;
    public Button done;

    int sizeX, sizeY, random;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("X", 10);
        PlayerPrefs.SetInt("Y", 10);
        PlayerPrefs.SetInt("Random", 0); //0 = true, 1 = false
        PlayerPrefs.SetFloat("Dense", 0.5f);

        textX.text = PlayerPrefs.GetInt("X").ToString();
        textY.text = PlayerPrefs.GetInt("Y").ToString();

        dense.value = PlayerPrefs.GetFloat("Dense");
    }

    // Update is called once per frame
    void Update()
    {
        done.onClick.AddListener(Set);
    }

    void Set()
    {
        sizeX = int.Parse(textX.text);
        sizeY = int.Parse(textY.text);
        if (isRandom.isOn == true)
        {
            PlayerPrefs.SetInt("Random", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Random", 1);
        }
        PlayerPrefs.SetFloat("Dense", dense.value);

        PlayerPrefs.SetInt("X", sizeX);
        PlayerPrefs.SetInt("Y", sizeY);
        //PlayerPrefs.SetInt("Random", 0); //0 = true, 1 = false
        PlayerPrefs.SetFloat("Dense", dense.value);

        SceneManager.LoadScene(1);
    }
}
