using System.Collections.Generic;
using System.Diagnostics;

namespace CodeGenerator.LIB.Base
{
    public abstract class Version
    {
        protected List<CodeFile> Files { get; set; } = new List<CodeFile>();
        
        protected abstract string VersionId { get; }

        public static bool operator ==(Version version, object obj)
            => Equals(version, obj);

        public static bool operator !=(Version version, object obj)
            => !(version == obj);

        public override bool Equals(object obj)
            => obj is string str && VersionId.Equals(str, System.StringComparison.InvariantCultureIgnoreCase) ||
            obj is Version version && version.Equals(VersionId);

        public override int GetHashCode() => 1655515818 + EqualityComparer<string>.Default.GetHashCode(VersionId);

        public CodeFile CreateFile()
        {
            var file = CreateSpecifiedFile();
            Files.Add(file);
            return file;
        }

        public Version Generate()
        {
            Files.ForEach(file => file.Generate());
            Files.Clear();
            return this;
        }

        protected abstract CodeFile CreateSpecifiedFile();
    }
}
