using UnityEditor;

namespace Editor.Compiles.Uses
{
    public class SimpleCompileFactory : ICompileFactory
    {
        private readonly BuildTarget target;

        public SimpleCompileFactory(BuildTarget target)
        {
            this.target = target;
        }
        
        public void Compile(string path, BuildOptions buildOptions)
        {
            BuildPipeline.BuildPlayer(GetScenes(), path, target, buildOptions);
        }

        private static EditorBuildSettingsScene[] GetScenes()
        {
            return EditorBuildSettings.scenes;
        }
    }
}