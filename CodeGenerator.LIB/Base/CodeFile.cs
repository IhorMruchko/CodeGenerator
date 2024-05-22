using System.Collections.Generic;

namespace CodeGenerator.LIB.Base
{
    public abstract class CodeFile
    {
        protected string FileExtension { get; set; }
        
        protected Version ReturningVersion { get; set; }

        protected List<CodeStructure> CodeStructures { get; set; } = new List<CodeStructure>();
        
        public CodeFile(Version returnVersion, string fileExtension) 
        {
            ReturningVersion = returnVersion;
            FileExtension = fileExtension;
        }

        public abstract void Generate();
             
        public virtual Version Return() => ReturningVersion;

        public virtual CodeFile AddStructure(CodeStructure structure)
        {
            CodeStructures.Add(structure);
            return this;
        }
    }
}