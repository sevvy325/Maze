using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Maze.Structures
{
    class MazeStruct
    {

        public Cell[,] CellArray { get; private set; }

        public int vCount = 0;

        public Vector2 Dimensions { get; private set; }

        /// <summary>
        /// Basic constructor for the Maze object. Creates a Maze with  the provided dimensions.
        /// By default all walls are up or closed
        /// </summary>
        /// <param name="Width">The Width of the maze</param>
        /// <param name="Height">The height of the maze</param>
        public MazeStruct(int width, int height)
        {
            // Initialization
            CellArray = new Cell[width, height];
            for (int x = 0; x < CellArray.GetLength(0); x++)
                for (int y = 0; y < CellArray.GetLength(1); y++)
                    CellArray[x, y] = new Cell();
            Dimensions = new Vector2(50, 50);

        }

        public void visit(Vector2 cellLocation)
        {
            vCount++;
            CellArray[(int)cellLocation.X, (int)cellLocation.Y].Visited = true;
        }

        public void visitAndLower(Vector2 cellLocation, Wall eWall)
        {
            vCount++;
            CellArray[(int)cellLocation.X, (int)cellLocation.Y].Visited = true;
            CellArray[(int)cellLocation.X, (int)cellLocation.Y].Walls[(int)eWall] = false;
        }

        /// <summary>
        /// Searches all directions around a cell to fing which neighbors are valid
        /// </summary>
        /// <param name="cell">The cell around which to search</param>
        /// <returns>A 4 integer array in the format of the Structures.Walls enum 
        /// with 1 being a valid neighbor</returns>
        internal int[] findValidNeighbors(Vector2 cell)
        {
            // Assume all are invalid
            int[] iL = new int[] { 0, 0, 0, 0 };
            for (int n = 0; n < 4; n++)
                if (!getNeighborStatus(cell, n)) iL[n] = 1;
            return iL;
        }
        
        /// <summary>
        /// Determines weather or not a neighbor has been visited and that it is in range
        /// </summary>
        /// <param name="cell">The current cell, not its neighbors</param>
        /// <param name="dir">The direction to check from the current cell. Uses the Wall enum from
        /// Structures namespace</param>
        /// <returns>true if the cell has been visited or is invalid, false if the cell is valid</returns>
        private bool getNeighborStatus(Vector2 cell, int dir)
        {
            if ((Wall)dir == Wall.North)
                if (cell.Y + 1 < CellArray.GetLength(1))
                    return CellArray[(int)cell.X, (int)cell.Y + 1].Visited;
                else return true;
            else if ((Wall)dir == Wall.East)
                if (cell.X + 1 < CellArray.GetLength(0))                                  
                    return CellArray[(int)cell.X + 1, (int)cell.Y].Visited;             
                else return true;
            else if ((Wall)dir == Wall.South)
                if (cell.Y - 1 > 0) 
                    return CellArray[(int)cell.X, (int)cell.Y - 1].Visited;
                else return true;
            else
                if (cell.X - 1 > 0) 
                    return CellArray[(int)cell.X - 1, (int)cell.Y].Visited;
                else return true;
        }
    }
}
