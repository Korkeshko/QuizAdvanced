using UnityEditor;
using UnityEngine;
using Editor.Compiles.Uses.Android;
using Editor.Compiles.Structure;
using Editor.Compiles.Uses;

namespace Editor.Compiles
{
    public class CompileFactory : MonoBehaviour
    {
        [MenuItem("CompileFactory/Compile")]
        public static void Compile()
        {    
            new ManyCompileFactory(
                new ExtentionFolderPath(
                    new APKCompileFactory(),
                    ".apk"
                ), 
                new ExtentionFolderPath(
                    new AABCompileFactory(),
                    ".aab"
                ),
                new ExtentionFolderPath(
                    new SimpleCompileFactory(BuildTarget.StandaloneWindows64), 
                    ".exe"
                )             
            ).Compile(
                EditorUtility.OpenFolderPanel(
                    "Select Folder",
                    "Assets",
                    "Build" 
                ),
                GetBuildOptions()
            );
        }

        private static BuildOptions GetBuildOptions()
        {
            return GetCurrentBuildPlayerOptions().options;
        }

        private static BuildPlayerOptions GetCurrentBuildPlayerOptions(BuildPlayerOptions buildPlayerOptions = new())
        {
            return BuildPlayerWindow.DefaultBuildMethods.GetBuildPlayerOptions(buildPlayerOptions);
        }
    }
}