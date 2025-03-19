using System.Numerics;
using Raylib_cs;

public class PlayerCamera
{
    private Camera3D _camera;
    public PlayerCamera()
    {
        _camera = new Camera3D();
        _camera.Position = new Vector3(6, 6, 6);
        _camera.Up = new Vector3(0, 1, 0);
        _camera.FovY = 45;
        _camera.Projection = CameraProjection.Perspective;
        Raylib.UpdateCamera(ref _camera, CameraMode.Free);
    }

    public void SetPosition(Vector3 position)
    {
        _camera.Position = position;
    }

    public void SetTarget(Vector3 target)
    {
        _camera.Target = target;
    }

    public void DrawWithCamera(Action method)
    {
            Raylib.BeginMode3D(_camera);
            method();
            Raylib.EndMode3D();
    }
}
