using CodeGenerator.LIB.Base;
using CodeGenerator.LIB.ProgramingLanguages.CSharpProgramingLanguage.CodeStructures;

namespace CodeGenerator.LIB.ProgramingLanguages.CSharpProgramingLanguage.Versions.NetStandard2
{
    public class NetStandard20 : Version
    {
        protected override string VersionId => "NET Standard 2.0";

        protected override CodeFile CreateSpecifiedFile()
            => new CSharpCodeFile(this);
    }
}