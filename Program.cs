using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using System.Numerics;
using static HeightMap;

const int ScreenWidth = 1280;
const int ScreenHeight = 720;
InitWindow(ScreenWidth, ScreenHeight, "Balls");

Camera3D camera = new();
camera.Position = new Vector3(18f, 21f, 18f);
camera.Target = new Vector3();
camera.Up = new Vector3(0, 1.0f, 0);
camera.FovY = 45f;
camera.Projection = CameraProjection.Perspective;

InitNoise();
InitModelMesh();
Vector3 MapPosition = new(-8.0f, 0.0f, -8.0f);
UnloadImage(img);

SetTargetFPS(60);

while(!WindowShouldClose()){
    UpdateCamera(ref camera, CameraMode.Orbital);

    BeginDrawing();
    // HeightMap.TestMap();
    ClearBackground(RayWhite);
    BeginMode3D(camera);
    DrawModel(model, MapPosition, 1.0f, DarkGreen);
    EndMode3D();

    // DrawTexture(texture, ScreenWidth - texture.Width - 20, 20, White);
    // DrawRectangleLines(ScreenWidth - texture.Width - 20, 20, texture.Width, texture.Height, Green);
    
    DrawFPS(10, 10);

    EndDrawing();
}

UnloadTexture(texture);
UnloadModel(model);
CloseWindow();

Console.WriteLine("Skibidi Ohio\n");
