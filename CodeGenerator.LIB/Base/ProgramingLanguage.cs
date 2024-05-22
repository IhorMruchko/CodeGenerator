using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.LIB.Base
{
    public abstract class ProgramingLanguage
    {
        public abstract string FileExtension { get; }

        protected abstract string LanguageName { get; }
        
        protected abstract Version[] Versions { get; }

        public virtual Version OnVersion(string version)
        {
            var selectedVersion = Versions.FirstOrDefault(v => v == version);
            return selectedVersion is null ? throw new System.Exception() : selectedVersion;
        }

        public override bool Equals(object obj) 
            => obj is string name && 
            LanguageName.Equals(name, System.StringComparison.InvariantCultureIgnoreCase);

        public override int GetHashCode()
        {
            int hashCode = -1957462228;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LanguageName);
            hashCode = hashCode * -1521134295 + EqualityComparer<Version[]>.Default.GetHashCode(Versions);
            return hashCode;
        }

        public static bool operator ==(ProgramingLanguage language, string name) 
            => language.Equals(name);

        public static bool operator != (ProgramingLanguage language, string name)
            => !language.Equals(name);
    }
}
