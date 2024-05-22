using CodeGenerator.LIB.Base;
using System;
using System.IO;
using System.Linq;

namespace CodeGenerator.LIB.ProgramingLanguages.CSharpProgramingLanguage.CodeStructures
{
    public class CSharpCodeFile : CodeFile
    {
        public CSharpCodeFile(Base.Version returnVersion) : base(returnVersion, ".cs")
        {
        }

        public override void Generate()
        {
            File.WriteAllText("E:\\Programming\\C#\\CodeGenerator\\Testing\\result.cs",
                string.Join("\n\n", CodeStructures.Select(cs => cs.Generate())));
            Console.WriteLine(string.Join("\n\n", CodeStructures.Select(cs => cs.Generate())));
        }
    }
}
