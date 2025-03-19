using System.Numerics;
using Raylib_cs;

namespace HelloWorld;

class Program
{
    public static void Main()
    {
        Raylib.InitWindow(800, 480, "Hello World");

        PlayerCamera camera = new PlayerCamera();
        Model fox = Raylib.LoadModel("/auto_mnt/shared/current_projects/raylib_csharp/assets/Fox.gltf");

        float zoom = 1.0f;

        Vector3 foxPosition = new Vector3(0, 0, 0);
        while (!Raylib.WindowShouldClose())
        {
            float speed = 0.05f;
            string keys = "a";
            int key = Raylib.GetKeyPressed();
            while (key != 0)
            {
                keys += $"{key} ";
                key = Raylib.GetKeyPressed();

            }

            camera.SetTarget(foxPosition);
            camera.SetPosition(foxPosition + (new Vector3(0, 3, -10) * zoom));
            if (Raylib.IsKeyDown(KeyboardKey.Z))
                zoom = zoom * 1.001f;

            if (Raylib.IsKeyDown(KeyboardKey.X))
                zoom = zoom / 1.001f;

            if (Raylib.IsKeyDown(KeyboardKey.W))
                foxPosition += new Vector3(0, 0, speed);
            if (Raylib.IsKeyDown(KeyboardKey.A))
                foxPosition += new Vector3(speed, 0, 0);
            if (Raylib.IsKeyDown(KeyboardKey.S))
                foxPosition += new Vector3(0, 0, -speed);
            if (Raylib.IsKeyDown(KeyboardKey.D))
                foxPosition += new Vector3(-speed, 0, 0);
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.DrawText(keys, 12, 32, 20, Color.Black);
            Raylib.DrawText("Hello, world2!", 12, 12, 20, Color.Black);
            camera.DrawWithCamera(() =>
            {
                Raylib.DrawGrid(10, 10.0f);
                Raylib.DrawModel(fox, foxPosition, 1.0f, Color.White);
            });
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}
