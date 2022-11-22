using OpenTK.Graphics.OpenGL4;

namespace Lab1
{
    public class FigureToDraw
    {
        private float[] _vertices =
        {
        //triangles
        0f,0f,0f, 
        4f,0f,0f, 
        4f,-4f,0f, 

        0f,0f,0f, 
        -4f,-4f,0f,
        -4f,0f,0f,

        0f,0f,0f,
        2f,-2f,0f, 
        -2f,-2f,0f,

        -4f,3f,0f, 
        -4f,1f,0f,
        -6f,1f,0f,

        -4.5f,2.5f,0f, 
        -6f,1f,0f,
        -6f,4f,0f, 
        //squares
        4f,0f,0f,
        5f,2f,0f, 
        9f,3f,0f,
        8f,1f,0f,

        -4f,1f,0f, 
        -4f,-1f,0f,
        -6f,-1f,0f,
        -6f,1f,0f,

        //colored triangles
        0f,0f,0f, 
        4f,0f,0f,
        4f,-4f,0f, 

        0f,0f,0f, 
        -4f,-4f,0f,
        -4f,0f,0f, 

        0f,0f,0f,
        2f,-2f,0f, 
        -2f,-2f,0f, 

        -4f,3f,0f, 
        -4f,1f,0f, 
        -6f,1f,0f,

        -4.5f,2.5f,0f, 
        -6f,1f,0f, 
        -6f,4f,0f, 

        //colored squares
        4f,0f,0f, 
        5f,2f,0f, 
        9f,3f,0f, 

        4f,0f,0f, 
        9f,3f,0f,
        8f,1f,0f, 

        
        -4f,1f,0f, 
        -4f,-1f,0f, 
        -6f,-1f,0f, 
        
        -4f,1f,0f, 
        -6f,-1f,0f, 
        -6f,1f,0f, 
        };
        private ShapeToDraw[] _shapes =
        {
            new ShapeToDraw(0f,0.8f,0f),
            new ShapeToDraw(PrimitiveType.Triangles, 23, 27),
            new ShapeToDraw(0f,0f,0f),
            new ShapeToDraw(PrimitiveType.LineLoop, 0, 3),
            new ShapeToDraw(PrimitiveType.LineLoop, 3, 3),
            new ShapeToDraw(PrimitiveType.LineLoop, 6, 3),
            new ShapeToDraw(PrimitiveType.LineLoop, 9, 3),
            new ShapeToDraw(PrimitiveType.LineLoop, 12, 3),
            new ShapeToDraw(PrimitiveType.LineLoop, 15, 4),
            new ShapeToDraw(PrimitiveType.LineLoop, 19, 4),

        };

        public float[] Vertices { get{ return _vertices; } }
        public ShapeToDraw[] Shapes { get { return _shapes; } }

        public void Move(float x, float y)
        {
            //for x
            for (int i = 0; i < _vertices.Length; i+=3)
            {
                _vertices[i] += x;
            }
            //for y
            for (int i = 1; i < _vertices.Length; i+=3)
            {
                _vertices[i] += y;
            }
        }

        public void Scale(float amount)
        {
            for (int i = 0; i < _vertices.Length; i++)
            {
                _vertices[i] *= amount;
            }
        }

    }
    public class ShapeToDraw
    {
        public readonly PrimitiveType Type;
        public readonly int First;
        public readonly int Count = -1;
        public bool IsColor { get { return Count == -1; } }
        public readonly float R,G,B;
        public ShapeToDraw(PrimitiveType type, int first, int count)
        {
            Type = type;
            First = first;
            Count = count;
        }
        public ShapeToDraw(float r, float g, float b)
        {
            R= r;
            G= g;
            B= b;
        }
    }
}
