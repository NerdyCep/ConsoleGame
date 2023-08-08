using System;
using System.Reflection.Metadata;

namespace ConsoleGame
{
    public class Grafics
    {
        public int width {  get; }
        public int height { get; }

        public float aspect { get; }
        public float pixelAspect { get; }
        public float multiplier { get; }
        public char[] buffer { get; private set; }

        public Grafics(int width, int height, float multiplier)
        {
            this.width = width;
            this.height = height;
            this.multiplier = multiplier;   
            aspect = (float)width / height;
            pixelAspect = 8.0f / 12.0f;
            buffer = new char[width * height];
        }

        private void Reset()
        {
            for (int i=0; i < width; i++)
                for (int j = 0; j < height; j++)
                    buffer[i + j * width] = ' ';
        }
        public void Begin()
        {
            Reset();
            Console.SetCursorPosition(0, 0);
        }
        public void Draw(Shape shape)
        {
            char[] shapeBuffer = shape.Draw(this);
            for (int i = 0; i < width; i++) 
                for(int j = 0; j < height; j++)
                {
                    if (shapeBuffer[i + j * width] != 0)
                        buffer[i + j * width] = shapeBuffer[i + j * width];
                }
        }
        public void End()
        {
            Console.WriteLine(buffer);
        }
    }
}
