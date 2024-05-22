using CodeGenerator.LIB.Base;
using CodeGenerator.LIB.ProgramingLanguages.CSharpProgramingLanguage.Versions.NetStandard2;

namespace CodeGenerator.LIB.ProgramingLanguages.CSharpProgramingLanguage
{
    internal class CSharp : ProgramingLanguage
    {
        public override string FileExtension => ".cs";

        protected override string LanguageName => "C#";

        protected override Version[] Versions => new[] { new NetStandard20() };
    }
}
