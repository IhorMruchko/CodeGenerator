using CodeGenerator.LIB.Base;
using System;

namespace CodeGenerator.LIB.ProgramingLanguages.CSharpProgramingLanguage.CodeStructures
{
    public class Property : CodeStructure
    {
        protected string PropertyName { get; set; }

        protected Type PropertyType { get; set; }

        public string PropertyTypeStr { get; set; }

        public Property(string propertyName, Type propertyType) 
        {
            PropertyName = propertyName;
            PropertyType = propertyType;
        }

        public Property(string propertyName, string propertyType)
        {
            PropertyName = propertyName;
            PropertyTypeStr = propertyType;
        }

        public override string Generate() 
            => $"\n\t{PropertyType?.FullName ?? PropertyTypeStr} {PropertyName} {{ get; set; }}\n";
    }
}
