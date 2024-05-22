using CodeGenerator.LIB.Base;
using System.Linq;

namespace CodeGenerator.LIB.ProgramingLanguages.CSharpProgramingLanguage.CodeStructures
{
    public class Class : CodeStructure
    {
        protected string ClassName { get; set; }
        
        public Class(string className) 
        { 
            ClassName = className;
        }

        public override string Generate() 
            => $"class {ClassName} \n{{ {string.Join("\n", InnerStructures.Select(inS => inS.Generate()))} \n}}";
    }
}
