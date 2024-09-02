using UnityEditor;
using UnityEngine;
using Editor.Compiles.Uses.Android;
using Editor.Compiles.Structure;
using Editor.Compiles.Uses;
using Editor.Compiles.Uses.WebGL;

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
                ),
                new ExtentionFolderPath(
                    new SimpleCompileFactory(BuildTarget.WebGL),
                    ".html" 
                ),
                new ExtentionFolderPath(
                    new WebGLCompileFactory(), 
                    ".html"
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