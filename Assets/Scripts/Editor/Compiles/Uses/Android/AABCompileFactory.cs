using UnityEditor;

namespace Editor.Compiles.Uses.Android
{
    public class AABCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory factory;

        public AABCompileFactory()
        {
            factory = new SimpleCompileFactory(BuildTarget.Android);
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            EditorUserBuildSettings.buildAppBundle = true;
            factory.Compile(path, buildOptions);
        }
    }
}