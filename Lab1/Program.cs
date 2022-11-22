using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Lab1
{
    public static class Program
    {
        private const string pathToVertexShader = "Shaders/shader.vert";
        private const string pathToFragmentShader = "Shaders/shader.frag";
        private static void Main()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(1024, 1024),
                Title = "Lab1",
                Flags = ContextFlags.ForwardCompatible,
            };

            FigureToDraw figure = new FigureToDraw();

            using (var window = new Lab1(GameWindowSettings.Default, nativeWindowSettings, pathToVertexShader, pathToFragmentShader, figure))
            {
                window.Run();
            }
        }
    }
}