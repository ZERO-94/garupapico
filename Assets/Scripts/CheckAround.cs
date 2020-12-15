using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAround : Movement
{
    private List<Tuple<int, int>> squarePosition = new List<Tuple<int, int>>();
    // Update is called once per frame
    void Update()
    {
        checkGrid();
    }

    void dq(int x, int y)
    {
        squarePosition.Add(new Tuple<int, int>(x, y));
        count++;
        visited[x, y] = true;
        if (count < 10)
        {
            int leftSideX = (x > 0) ? (x - 1) : x; int leftSideY = y;
            int rightSideX = (x < width - 1) ? (x + 1) : x; int rightSideY = y;
            int upSideX = x; int upSideY = (y < height - 1) ? (y + 1) : y;
            int downSideX = x; int downSideY = (y > 0) ? (y - 1) : y;

            //Debug.Log(visited[leftSideX, leftSideY]);
            if ((visited[leftSideX, leftSideY] == false) && (grid[leftSideX, leftSideY] != null) && grid[leftSideX, leftSideY].tag == grid[x, y].tag)
                dq(leftSideX, leftSideY);
            if ((visited[rightSideX, rightSideY] == false) && (grid[rightSideX, rightSideY] != null) && grid[rightSideX, rightSideY].tag == grid[x, y].tag)
                dq(rightSideX, rightSideY);
            if ((visited[upSideX, upSideY] == false) && (grid[upSideX, upSideY] != null) && grid[upSideX, upSideY].tag == grid[x, y].tag)
                dq(upSideX, upSideY);
            if ((visited[downSideX, downSideY] == false) && (grid[downSideX, downSideY] != null) && grid[downSideX, downSideY].tag == grid[x, y].tag)
                dq(downSideX, downSideY);
        }
    }

    void checkGrid()
    {
        //check for each square
        for (int y = 0; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if (grid[j, y] != null)
                {
                    dq(j, y);
                    if (count == 10)
                    {
                        foreach (Tuple<int, int> square in squarePosition)
                        {
                            Destroy(grid[square.Item1, square.Item2].parent.gameObject);
                            grid[square.Item1, square.Item2] = null;
                        }
                    }
                    squarePosition.Clear();
                    count = 0;
                }
            }
        }

        //reset the visited array into false for the next check
        for (int y = 0; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                visited[j, y] = false;
            }
        }


    }
}
