using UnityEditor;

namespace Editor.Compiles.Structure
{
    public class ManyCompileFactory : ICompileFactory
    {
        private readonly ICompileFactory[] factories;

        public ManyCompileFactory(params ICompileFactory[] factories)
        {
            this.factories = factories;
        }

        public void Compile(string path, BuildOptions buildOptions)
        {
            foreach (var factory in factories)
            {
                factory.Compile(path, buildOptions);
            }
        }
    }
}