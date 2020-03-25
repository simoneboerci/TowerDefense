using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SB.TextureConverter
{
    public class TextureConverter
    {
        #region Texture -> Objects

        //Convert a 2D texture to a list of objects
        public static List<GameObject> FromTextureToObjects(Texture2D texture, ColorCode colorCode)
        {
            //List creation
            //Create an empty list
            List<GameObject> _objects = CreateEmptyList<GameObject>();

            //Texture scanning
            //Loop through every pixel of the texture
            for (int x = 0; x < texture.width; x++)
            {
                for (int y = 0; y < texture.height; y++)
                {
                    //Color code scanning
                    //Loop through every object reference in the color code
                    for (int i = 0; i < colorCode.code.Count; i++)
                    {
                        Color _pixelColor = texture.GetPixel(x, y);

                        //Store the current object reference
                        ObjectReference _currentObjectReference = colorCode.code[i];

                        Color _referenceColor = _currentObjectReference.color;

                        if(ColorMatch(_pixelColor, _referenceColor))
                        {
                            _objects.Add(_currentObjectReference.obj);
                            break;
                        }
                    }
                }
            }

            //Return the list of converted objects
            return _objects;
        }

        private static List<T> CreateEmptyList<T>()
        {
            return new List<T>();
        }

        //Check if there is a match between two colors
        private static bool ColorMatch(Color color1, Color color2)
        {
            if (color1 == null || color2 == null)
                Debug.LogErrorFormat("Color 1 -> {0}\nColor 2 -> {1}", color1, color2);
            else
            {
                if (color1 == color2)
                    return true;
            }

            return false;
        }

        #endregion

        #region Objects -> Texture

        //Convert a list of objects to a 2D texture
        public static Texture2D FromObjectsToTexture(int width, List<GameObject> objects, ColorCode colorCode)
        {
            //Calculate texture height
            int _height = objects.Count / width;

            //Create the texture
            Texture2D _texture = new Texture2D(width, _height);

            //Create an index for the color code
            int _index = 0;

            //Loop through every pixel of the texture
            for (int x = 0; x < _texture.width; x++)
            {
                for (int y = 0; y < _texture.height; y++)
                {
                    //Loop through every object reference in color code
                    for (int i = 0; i < colorCode.code.Count; i++)
                    {
                        //Store the current object reference
                        ObjectReference _currentObjectReference = colorCode.code[i];

                        //Check if the selected object is equal to the object of the current object reference
                        if (objects[_index] == _currentObjectReference.obj)
                        {
                            //Set the pixel color of the texture
                            _texture.SetPixel(x, y, _currentObjectReference.color);
                        }
                    }

                    //Increase the index of the color code
                    _index++;
                }
            }

            //Return the texture
            return _texture;
        }

        #endregion

        #region Texture -> Bytes

        //Convert a 2D texture to a list of bytes
        public static List<byte> FromTextureToByte(Texture2D texture, ColorCode colorCode)
        {
            //Create an empty list of bytes
            List<byte> _bytes = new List<byte>();

            //Loop through every pixel of the texture
            for (int x = 0; x < texture.width; x++)
            {
                for (int y = 0; y < texture.height; y++)
                {
                    //Loop through every object reference in the color code
                    for (int i = 0; i < colorCode.code.Count; i++)
                    {
                        //Store the current object reference
                        ObjectReference _currentObjectReference = colorCode.code[i];

                        //Check if the current pixel has the same color of the current object reference
                        if (texture.GetPixel(x, y) == _currentObjectReference.color)
                        {
                            //Add the index to the list of bytes
                            _bytes.Add((byte)i);
                            break;
                        }
                    }
                }
            }

            //Return the list of bytes
            return _bytes;
        }

        #endregion

        #region Bytes -> Texture

        //Convert a list of bytes to a 2D texture
        public static Texture2D FromBytesToTexture(int width, List<byte> bytes, ColorCode colorCode)
        {
            //Calculate texture height
            int _height = bytes.Count / width;

            //Create the texture
            Texture2D _texture = new Texture2D(width, _height);

            //Create an index for the color code
            int _index = 0;

            //Loop through every pixel of the texture
            for (int x = 0; x < _texture.width; x++)
            {
                for (int y = 0; y < _texture.height; y++)
                {
                    //Loop through every object reference in color code
                    for (int i = 0; i < colorCode.code.Count; i++)
                    {
                        //Store the current object reference
                        ObjectReference _currentObjectReference = colorCode.code[i];

                        //Check if the selected object is equal to the object of the current object reference
                        if (bytes[_index] == i)
                        {
                            //Set the pixel color of the texture
                            _texture.SetPixel(x, y, _currentObjectReference.color);
                        }
                    }

                    //Increase the index of the color code
                    _index++;
                }
            }

            //Return the texture
            return _texture;
        }

        #endregion
    }
}
