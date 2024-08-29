using UnityEditor;

namespace Editor.Compiles.Uses.Android
{
    public class APKCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory factory;

        public APKCompileFactory()
        {
            factory = new SimpleCompileFactory(BuildTarget.Android);
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            EditorUserBuildSettings.buildAppBundle = false;
            factory.Compile(path, buildOptions);
        }
    }
}