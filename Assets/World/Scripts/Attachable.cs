using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Attachable : MonoBehaviour
{
    public GameObject[,] grid;
    public int[,] attachedGrid;
    public GameObject attached;

    public int width = -1;
    public int height = -1;

    void Start()
    {
        if (width != -1 && height != -1)
        {
            CreateGrid(width, height);
        }
    }

    public void CreateGrid(int width, int height)
    {
        grid = new GameObject[width, height];
    }

    void Update()
    {

    }
}
