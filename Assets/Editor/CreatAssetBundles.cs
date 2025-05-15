using UnityEditor;

public class CreatAssetBundles
{
    static string PATH = "";
    [MenuItem("资源/创建所有资源包")]
    static void CreatAB()
    {
        BuildPipeline.BuildAssetBundles(PATH, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }
}
