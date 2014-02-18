using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Structures
{
    public enum Wall { North, East, South, West };
    class Cell
    {

       

        /// <summary>
        /// Represents the states of the walls of walls.
        /// True is Raised or Closed.
        /// Wall enum is best used
        /// 0 - North/Up
        /// 1 - East/Right
        /// 2 - South/Down
        /// 3 - West/Left 
        /// </summary>
        public bool[] Walls { get; set; }

        public bool Visited { get; set; }

        /// <summary>
        /// Default Constructor for the Cell object. Creates a basic cell with its 
        /// walls up or closed and un-visited
        /// </summary>
        public Cell()
        {
            Walls = new bool[4];

            // Set all walls up
            for (int i = 0; i < Walls.GetLength(0); i++) Walls[i] = false;
            // Set Cell as unvisited
            Visited = false;
        }

    }
}
