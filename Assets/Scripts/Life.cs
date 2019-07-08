using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public Life[] neighbors = new Life[8];
    public bool isAlive = false;
    public bool willLive;
    public bool isBoarder;
    
    // Start is called before the first frame update
    void Start()
    {
        //neighbors = new Life[8];
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        {
            this.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        }
        else if(isBoarder)
        {
            this.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
        else
        {
            this.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
        }
    }

    public void MakeAlive(bool alive)
    {
        isAlive = alive;
    }

    public void MakeNeighbor(int direction, GameObject neighbor)
    {
        neighbors[direction] = neighbor.GetComponent<Life>();
        //Debug.Log(direction + "neighbor");
    }

    public void NextGeneration()
    {
        int aliveNeighbors = 0;
        for(int i = 0; i < 8; i++)
        {
            if (neighbors[i].ReturnStatus() == true)
            {
                aliveNeighbors++;
            }
        }
        if(isAlive && aliveNeighbors < 2)
        {
            willLive = false;
        }
        else if(isAlive && (aliveNeighbors == 2 || aliveNeighbors == 3))
        {
            willLive = true;
        }
        else if(isAlive && aliveNeighbors > 3)
        {
            willLive = false;
        }
        else if(isAlive == false && aliveNeighbors == 3)
        {
            willLive = true;
        }
        else
        {
            //Debug.Log("Error in Next Generation");
        }
    }

    public void ApplyGeneration()
    {
        isAlive = willLive;
    }

    public void CreateBorader()
    {
        isBoarder = true;
    }

    public bool ReturnStatus()
    {
        return isAlive;
    }
}
