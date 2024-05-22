using System.Collections.Generic;

namespace CodeGenerator.LIB.Base
{
    public abstract class CodeStructure
    {
        protected List<CodeStructure> InnerStructures { get; set; } = new List<CodeStructure>();
        
        public virtual CodeStructure AddStructure(CodeStructure structure)
        {
            InnerStructures.Add(structure);
            return this;
        }

        public abstract string Generate();
    }
}
