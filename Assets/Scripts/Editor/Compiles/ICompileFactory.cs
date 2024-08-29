using UnityEditor;
namespace Editor.Compiles
{
    public interface ICompileFactory
    {
        public void Compile(string path, BuildOptions buildOptions);
    }
}