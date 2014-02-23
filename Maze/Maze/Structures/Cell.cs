using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        private Texture2D texture;

        public Texture2D Texture
        { 
            get
        {
            if(this.texture == null)
                this.texture = this.buildTex();
            return this.texture;
        } 
            private set
            {
                this.texture = value; 
            }
        }

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

        private Texture2D buildTex()
        {
            Texture2D tex = new Texture2D(Game1.graphics.GraphicsDevice, 3, 3, false, SurfaceFormat.Color);
            Color[] cArray = new Color[9];
            for (int i = 0; i < 9; i++)
                cArray[i] = Color.Black;
            if (!Walls[0]) cArray[1] = Color.White;
            if (!Walls[3]) cArray[3] = Color.White;
            if (this.Visited) cArray[4] = Color.White;
            if (!Walls[1]) cArray[5] = Color.White;
            if (!Walls[2]) cArray[7] = Color.White;
            tex.SetData<Color>(cArray);
            return tex;
        }

    }
}
