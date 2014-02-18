using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Structures;
using Microsoft.Xna.Framework;

namespace Maze
{
    class MazeGen
    {
        int north, east, south, west = 0;

        public MazeStruct maze { get; private set; }

        /// <summary>
        /// To serve as a list of visited cells. Instead of storing the actual cells
        /// we store the location of the cell in the Maze.
        /// </summary>
        private List<Vector2> cList;

        /// <summary>
        /// Holder for the current cell being manipulated
        /// </summary>
        private Vector2 _currCell;

        private Random _rng = new Random(200);

        /// <summary>
        /// Standard Constructor for a MazeGen Object. Creates a new maze with the default dimensons of 
        /// 50 x 50. Overwrites any previous Maze object for this instance.
        /// </summary>
        public MazeGen()
        {
            // Initialization
            maze = new MazeStruct(50, 50);
            cList = new List<Vector2>();

            // Creating first cell for maze creation.
            _currCell = new Vector2(_rng.Next((int)maze.Dimensions.X), _rng.Next((int)maze.Dimensions.Y));
            maze.visit(_currCell);
            cList.Add(_currCell);
            // Once the final cell has been removed from the list the maze is complete
            while (cList.Count > 0)
            {
                carvePassage(_currCell);
            }
            Console.WriteLine("Went North {0} time(s).", north);
            Console.WriteLine("Went East {0} time(s).", east);
            Console.WriteLine("Went South {0} time(s).", south);
            Console.WriteLine("Went West {0} time(s).", west);
        }

        private void carvePassage(Vector2 cell)
        {
            int[] neghbors = maze.findValidNeighbors(cell);
            // Create a list from the array to easily choose a passage
            List<int> validNList = new List<int>();
            for (int i = 0; i < neghbors.GetLength(0); i++)
                if (neghbors[i] == 1) validNList.Add(i);
            // if there is a valid neghbor, choose one at random to progress to
            if (validNList.Count > 0)
            {
                int nextDir = _rng.Next(validNList.Count);
                if ((Wall)nextDir == Wall.North)
                {
                    north++;
                    Vector2 nCell = new Vector2(cell.X, cell.Y + 1);
                    maze.visitAndLower(cell, (Wall)nextDir);
                    // Should essentaly make the Wall enum circular. Only works for 4 sided
                    // mazes. Could use a more eligant method to determine the mod number so
                    // it will work for multiple maze types.
                    maze.visitAndLower(nCell, (Wall)((nextDir + 2) % 4));
                    cList.Add(nCell);
                    carvePassage(nCell);
                }
                else if ((Wall)nextDir == Wall.East)
                {
                    if (cell.X == 49)
                        east++;
                    east++;
                    Vector2 nCell = new Vector2(cell.X + 1, cell.Y);
                    maze.visitAndLower(cell, (Wall)nextDir);
                    // Should essentaly make the Wall enum circular. Only works for 4 sided
                    // mazes. Could use a more eligant method to determine the mod number so
                    // it will work for multiple maze types.
                    maze.visitAndLower(nCell, (Wall)((nextDir + 2) % 4));
                    cList.Add(nCell);
                    carvePassage(nCell);
                }
                else if ((Wall)nextDir == Wall.South)
                {
                    south++;
                    Vector2 nCell = new Vector2(cell.X, cell.Y - 1);
                    maze.visitAndLower(cell, (Wall)nextDir);
                    // Should essentaly make the Wall enum circular. Only works for 4 sided
                    // mazes. Could use a more eligant method to determine the mod number so
                    // it will work for multiple maze types.
                    maze.visitAndLower(nCell, (Wall)((nextDir + 2) % 4));
                    cList.Add(nCell);
                    carvePassage(nCell);
                }
                else
                {
                    west++;
                    Vector2 nCell = new Vector2(cell.X - 1, cell.Y);
                    maze.visitAndLower(cell, (Wall)nextDir);
                    // Should essentaly make the Wall enum circular. Only works for 4 sided
                    // mazes. Could use a more eligant method to determine the mod number so
                    // it will work for multiple maze types.
                    maze.visitAndLower(nCell, (Wall)((nextDir + 2) % 4));
                    cList.Add(nCell);
                    carvePassage(nCell);
                }
            }
            // Base Case, no valid neghbors so we use the selected method to choose another
            // Cell to test, or if there are no more cells, exit the stack.
            else
            {
                // I think this is inefficient. May need to be optimized
                cList.Remove(cell);
                // Make sure there still are places to go
                if (cList.Count > 0)
                {
                    // Going to assume we want to choose the most recent cell in the list
                    // can change later to support other methods.
                    _currCell = cList[cList.Count - 1];
                }
            }
        }
        
    }
}
