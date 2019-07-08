using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class God : MonoBehaviour
{
    public GameObject[,] world;
    public GameObject cell;
    public Life[,] cellLife;
    public int sizeX;
    public int sizeY;
    public int seed;
    public Camera mainCamera;
    public bool randomized = true;
    public float popDensity = 0.5f;
    int width;

    public Text population;
    public Text generationText;
    int generation;
    float isRandomized;

    //public Canvas ui;

    // Start is called before the first frame update
    void Start()
    {
        width = Screen.width;
        seed = (int)System.DateTime.Now.Ticks;
        world = new GameObject[sizeX + 2, sizeY + 2];
        cellLife = new Life[sizeX + 2, sizeY + 2];
        if (sizeX >= sizeY)
        {
            mainCamera.orthographicSize = (sizeX / 2) + 2;
        }
        else
        {
            mainCamera.orthographicSize = sizeY / 2 + 2;
        }

        mainCamera.transform.position = new Vector3(sizeX * 0.11f - 1, 1, sizeY / 2);
        Random.InitState(seed);
        
        for (int i = 0; i < sizeY + 2; i++)
        {
            world[0, i] = Instantiate(cell, new Vector3Int(0, 0, i), Quaternion.identity);
            cellLife[0, i] = world[0, i].GetComponent<Life>();
            cellLife[0, i].CreateBorader();
            world[sizeX + 1, i] = Instantiate(cell, new Vector3Int(sizeX + 1, 0, i), Quaternion.identity);
            cellLife[sizeX + 1, i] = world[sizeX + 1, i].GetComponent<Life>();
            cellLife[sizeX + 1, i].CreateBorader();
        }
        for (int i = 0; i < sizeX + 2; i++)
        {
            world[i, 0] = Instantiate(cell, new Vector3Int(i, 0, 0), Quaternion.identity);
            cellLife[i, 0] = world[i, 0].GetComponent<Life>();
            cellLife[i, 0].CreateBorader();
            world[i, sizeY + 1] = Instantiate(cell, new Vector3Int(i, 0, sizeY + 1), Quaternion.identity);
            cellLife[i, sizeY + 1] = world[i, sizeY + 1].GetComponent<Life>();
            cellLife[i, sizeY + 1].CreateBorader();
        }

        for (int i = 1; i < sizeX + 1; i++)
        {
            for (int j = 1; j < sizeY + 1; j++)
            {
                //Debug.Log(i + " " + j);
                world[i, j] = Instantiate(cell, new Vector3Int(i, 0, j), Quaternion.identity);
                cellLife[i, j] = world[i, j].GetComponent<Life>();
                if (randomized == true)
                {
                    //Debug.Log("random");
                    isRandomized = Random.Range(0.0f, 1.0f);
                    //Debug.Log(isRandomized);
                    if (isRandomized < popDensity)
                    {
                        cellLife[i, j].MakeAlive(true);
                    }
                }
            }
        }
        for (int i = 1; i < sizeX + 1; i++)
        {
            for (int j = 1; j < sizeY + 1; j++)
            {
                cellLife[i, j].MakeNeighbor(0, world[i - 1, j - 1]); //Bottom Left
                cellLife[i, j].MakeNeighbor(1, world[i - 1, j]); //Left
                cellLife[i, j].MakeNeighbor(2, world[i - 1, j + 1]); //Top Left
                cellLife[i, j].MakeNeighbor(3, world[i, j + 1]); //Top
                cellLife[i, j].MakeNeighbor(4, world[i + 1, j + 1]); //Top Right
                cellLife[i, j].MakeNeighbor(5, world[i + 1, j]); //Right
                cellLife[i, j].MakeNeighbor(6, world[i + 1, j - 1]); //Bottom Right
                cellLife[i, j].MakeNeighbor(7, world[i, j - 1]); //Bottom
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            Step();
        }*/
        population.text = "Population: " + PopulationCounter().ToString();
        generationText.text = "Generation: " + generation.ToString();
        if(Input.GetKey(KeyCode.Space))
        {
            Step();
        }
    }

    void Step()
    {
        for (int i = 1; i < sizeX + 1; i++)
        {
            for (int j = 1; j < sizeY + 1; j++)
            {
                cellLife[i, j].NextGeneration();
            }
        }
        for (int i = 1; i < sizeX + 1; i++)
        {
            for (int j = 1; j < sizeY + 1; j++)
            {
                cellLife[i, j].ApplyGeneration();
            }
        }
        generation++;
    }

    public int PopulationCounter()
    {
        int population = 0;
        for (int i = 1; i < sizeX + 1; i++)
        {
            for (int j = 1; j < sizeY + 1; j++)
            {
                if(cellLife[i, j].ReturnStatus())
                {
                    population++;
                }
            }
        }
        return population;
    }
}
