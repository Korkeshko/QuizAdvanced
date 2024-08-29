using System.IO;
using UnityEditor;

namespace Editor.Compiles.Uses
{
    public class ExtentionFolderPath : ICompileFactory
    {
        private readonly ICompileFactory origin;
        private readonly string extention;

        public ExtentionFolderPath(ICompileFactory origin, string extention)
        {
            this.origin = origin;
            this.extention = extention;
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            if (Directory.Exists(path))
            {
                path = Path.ChangeExtension(path, extention);
            }
            origin.Compile(path, buildOptions);
        }
    }
}