using CodeGenerator.LIB.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodeGenerator.LIB;

public static class GenerationAPI
{
    private static readonly ProgramingLanguage?[] _languages;

    static GenerationAPI()
    {
        _languages = Assembly.GetExecutingAssembly()
                             .GetTypes()
                             .Where(
                                t => t != null 
                                && t.IsAbstract == false 
                                && (t.BaseType?.Equals(typeof(ProgramingLanguage)) ?? false)
                             )
                             .Select(t => Activator.CreateInstance(t) as ProgramingLanguage)
                             .ToArray();
    }

    public static IEnumerable<TResult> ExctactFromLanguages<TResult>(Func<ProgramingLanguage?, TResult> selector) 
        => _languages.Select(selector);

    public static IEnumerable<string> Extensions => 
         ExctactFromLanguages(language => language?.FileExtension ?? string.Empty)
        .Where(result => result != string.Empty);
}
