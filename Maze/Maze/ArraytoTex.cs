using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Maze.Structures;

namespace Maze
{
    class ArraytoTex
    {

        public static Texture2D Convert(GraphicsDevice device, Cell[,] arrayToConvert)
        {            
            int totWidth = arrayToConvert.GetLength(0) *2;
            int totLength = arrayToConvert.GetLength(1) * 2;
            //  create a 2D color array for easy transition
            Color[,] c2Array = new Color[totWidth, totLength];
            // create a 1D array of colors so that we can turn the array into a Texture;
            Color[] colorArray = new Color[totLength * totWidth];
            for (int x = 0; x < colorArray.GetLength(0); x++)
                colorArray[x] = Color.Black;
            // We're only going to loop through the cells, not the extended array and address every
            // area around each individual cell.
            for (int y = 0; y < arrayToConvert.GetLength(1); y++)                
            {
                for (int x = 0; x < arrayToConvert.GetLength(0); x++)
                {
                    c2Array[(x * 2) + 1, (y * 2) + 1] = Color.Black;
                    if(arrayToConvert[x, y].Visited)
                        c2Array[(x * 2), (y * 2)] = Color.White;
                    else
                        c2Array[(x * 2), (y * 2)] = Color.Black;
                    if(!arrayToConvert[x, y].Walls[2])
                        c2Array[(x * 2) + 1, (y * 2)] = Color.White;
                    else c2Array[(x * 2) + 1, (y * 2)] = Color.Black;
                    if (!arrayToConvert[x, y].Walls[1])
                        c2Array[(x * 2), (y * 2) + 1] = Color.White;
                    else c2Array[(x * 2), (y * 2) + 1] = Color.Black;
                }
            }
            for (int y = 0; y < c2Array.GetLength(1); y++)
            {
                for (int x = 0; x < c2Array.GetLength(0); x++)
                {
                    colorArray[x + y * c2Array.GetLength(0)] = c2Array[x, y];
                }
            }
            Texture2D mazeTexture = new Texture2D(device, totWidth, totLength, false, SurfaceFormat.Color);
            mazeTexture.SetData(colorArray);
            return mazeTexture;
        }

        private static Color detirmineColor(Cell[,] array, int x, int y, int iX, int iY)
        {
            Color c = Color.Red;
            if (iX == 0 && iY == 0) c = Color.Blue;
            else if(iX == 1 && iY == 0)c = Color.White;
            else if (iX == 1 && iY == 1) c = Color.Yellow;
            else if (iX == 0 && iY == 1) c = Color.Purple;
            return c;
        }

    }
}
