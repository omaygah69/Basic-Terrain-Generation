using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;
public static class HeightMap
{
    public static Image img;
    public static Texture2D texture;
    public static Mesh mesh;
    public static Model model;

    public static void InitNoise()
    {
        img = GenImagePerlinNoise(500, 500, 200, 200, 1.0f);
        texture = LoadTextureFromImage(img);
        ExportImage(img, "./perlinNoise.png");
    }

    public static unsafe void InitModelMesh()
    {
        mesh = GenMeshHeightmap(img, new Vector3(16, 8, 16));
        model = LoadModelFromMesh(mesh);
        model.Materials[0].Maps[(int)MaterialMapIndex.Diffuse].Texture = texture;
    }

    public static void TestMap()
    {
        DrawTexture(texture, 100, 100, Color.RayWhite);
    }
}
