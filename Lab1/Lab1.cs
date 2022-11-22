using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

namespace Lab1
{
    public class Lab1 : GameWindow
    {
        private string _pathToVertexShader = "Shaders/shader.vert";
        private string _pathToFragmentShader = "Shaders/shader.frag";

        private int _vertexBufferObject;
        private int _vertexArrayObject;

        private float _velocity = 0.01f;

        private Shader _shader;
        private FigureToDraw _figure;

        public Lab1(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings, string pathToVertexShader, string pathToFragmentShader, FigureToDraw figure)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            _pathToVertexShader = pathToVertexShader;
            _pathToFragmentShader = pathToFragmentShader;
            _figure = figure;
        }
        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(249/255f, 146/255f, 69/255f, 1.0f);

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _figure.Vertices.Length * sizeof(float), _figure.Vertices, BufferUsageHint.DynamicDraw);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            if (!File.Exists(_pathToVertexShader))
            {
                throw new Exception($"No shader file {_pathToVertexShader}");
            }
            if (!File.Exists(_pathToFragmentShader))
            {
                throw new Exception($"No shader file {_pathToFragmentShader}");
            }
            _shader = new Shader(_pathToVertexShader, _pathToFragmentShader);
            _shader.Use();

            _figure.Scale(0.05f);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.BufferData(BufferTarget.ArrayBuffer, _figure.Vertices.Length * sizeof(float), _figure.Vertices, BufferUsageHint.DynamicDraw);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            _shader.Use();
            GL.BindVertexArray(_vertexArrayObject);
            int vertexColorLocation = GL.GetUniformLocation(_shader.Handle, "myColor");
            foreach (var sahpes in _figure.Shapes)
            {
                if (sahpes.IsColor)
                {
                    GL.Uniform3(vertexColorLocation, sahpes.R, sahpes.G, sahpes.B);
                    continue;
                }
                GL.DrawArrays(sahpes.Type, sahpes.First, sahpes.Count);
            }

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            var input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            if (input.IsKeyDown(Keys.W))
            {
                _figure.Move(0, _velocity);
            }
            if (input.IsKeyDown(Keys.S))
            {
                _figure.Move(0, -_velocity);
            }
            if (input.IsKeyDown(Keys.A))
            {
                _figure.Move(-_velocity, 0);
            }
            if (input.IsKeyDown(Keys.D))
            {
                _figure.Move(_velocity, 0);
            }
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
        }
        //not necessarily
        protected override void OnUnload()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
            GL.UseProgram(0);
            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteVertexArray(_vertexArrayObject);
            GL.DeleteProgram(_shader.Handle);

            base.OnUnload();
        }
    }
}