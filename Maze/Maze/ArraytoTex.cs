using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Maze
{
    class ArraytoTex
    {

        public static Texture2D Convert(GraphicsDevice device, Boolean[,] arrayToConvert)
        {
            // create a 1D array of colors so that we can turn the array into a Texture;
            int aWidth = arrayToConvert.GetLength(0);
            int aLength = arrayToConvert.GetLength(1);
            Color[] colorArray = new Color[aLength * aWidth];
            for (int x = 0; x < aWidth; x++)
            {
                for (int y = 0; y < aLength; y++)
                {
                    if (arrayToConvert[x, y]) colorArray[x + (y * aLength)] = Color.Black;
                    else colorArray[x + (y * aLength)] = Color.White;
                }
            }
            Texture2D mazeTexture = new Texture2D(device, aWidth, aLength, false, SurfaceFormat.Color);
            mazeTexture.SetData(colorArray);
            return mazeTexture;
        }

    }
}
