using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public class Cell
    {
        public bool visited = false;
        public bool[] state = new bool[4];
    }

    public Vector2 size;
    public int startPos = 0;

    private List<Cell> board;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MazeGenerator()
    {
        board = new List<Cell>();

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
            }
        }

        int currentCell = startPos;

        Stack<int> path = new Stack<int>();

        int k = 0;
        while (k < 1000)
        {
            k++;

            board[currentCell].visited = true;
            
            // Check neighbors
            List<int> neighbors = CheckNeighbors(currentCell);

            if (neighbors.Count == 0)
            {
                if (path.Count == 0)
                {
                    break;
                }
                else
                {
                    currentCell = path.Pop();
                }
            }
            else
            {
                 path.Push(currentCell);

                 int newCell = neighbors[Random.Range(0, neighbors.Count)];

                 if (newCell > currentCell)
                 {
                     if (newCell - 1 == currentCell)
                     {
                         board[currentCell].state[2] //continue 
                     }
                 }
            }
        }
    }

    List<int> CheckNeighbors(int cell)
    {
        List<int> neighbors = new List<int>();
        // north
        if (cell - size.x >= 0 && !board[Mathf.FloorToInt(cell-size.x)].visited) 
            neighbors.Add(Mathf.FloorToInt(cell-size.x));
        // south
        if (cell + size.x < board.Count && !board[Mathf.FloorToInt(cell+size.x)].visited)
            neighbors.Add(Mathf.FloorToInt(cell+size.x));
        // east
        if ((cell+1) % size.x != 0 && !board[Mathf.FloorToInt(cell + 1)].visited)
            neighbors.Add(Mathf.FloorToInt(cell+1));
        // west
        if (cell % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].visited)
            neighbors.Add(Mathf.FloorToInt(cell-1));

        return neighbors;
    }
}
