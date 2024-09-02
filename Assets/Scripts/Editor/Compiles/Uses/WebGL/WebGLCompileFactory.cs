using UnityEditor;
using UnityEngine;

namespace Editor.Compiles.Uses.WebGL
{
    public class WebGLCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory factory;

        public WebGLCompileFactory()
        {
            factory = new SimpleCompileFactory(BuildTarget.WebGL);
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            QualitySettings.SetQualityLevel(2, true);
            PlayerSettings.WebGL.memorySize = 256;
            factory.Compile(path, buildOptions);
        }
    }
}