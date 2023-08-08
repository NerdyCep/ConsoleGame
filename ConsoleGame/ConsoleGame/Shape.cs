using System;


namespace ConsoleGame
{
    public class Shape
    {
        protected Vector2 position;
        protected char[] texture;

        public Shape(Vector2 position, char[] texture)
        {
            this.position = position;
            this.texture = texture;
        }
        public virtual char[] Draw(Grafics grafics)
        {
            return new char[grafics.width * grafics.height];
        }
        public void Move(Vector2 direction)
        {
            position += direction;
        }

        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;

        }

        public Vector2 GetPosition()
        {
            return position;
        }

    }
    public class Circle : Shape
    {
        protected float size;
        public Circle(Vector2 position, float size, char[] texture) : base(position, texture)
        {
            this.size = size;
        }

        override public char[] Draw(Grafics grafics)
        {
            char[] buffer = new char[grafics.buffer.Length];
            for (int i = 0; i < grafics.width; i++)
                for (int j = 0; j < grafics.height; j++)
                {
                    float x = (float)i / grafics.width * 2.0f * grafics.multiplier - 1.0f * grafics.multiplier;
                    float y = (float)j / grafics.height * 2.0f * grafics.multiplier - 1.0f * grafics.multiplier;
                    x *= grafics.aspect * grafics.pixelAspect;
                    float f = (x - position.x) * (x - position.x) + (y - position.y) * (y - position.y);

                    char pixel;

                    if (f < size)
                    {
                        if (f < size / 8)
                            pixel = texture[3];
                        else if (f < size / 3)
                            pixel = texture[2];
                        else if (f < size / 1.5f)
                            pixel = texture[1];
                        else 
                            pixel = texture[0];

                        buffer[i + j * grafics.width] = pixel;
                    }
                }
             return buffer;
        }
    }
}
