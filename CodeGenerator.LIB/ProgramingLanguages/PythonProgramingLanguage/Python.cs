using CodeGenerator.LIB.Base;
using System;

namespace CodeGenerator.LIB.ProgramingLanguages.PythonProgramingLanguage
{
    public class Python : ProgramingLanguage
    {
        public override string FileExtension => ".py";

        protected override string LanguageName => "Python";

        protected override Base.Version[] Versions => Array.Empty<Base.Version>();
    }
}
