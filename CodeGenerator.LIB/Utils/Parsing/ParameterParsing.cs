using System;

namespace CodeGenerator.LIB.Utils.Parsing;

public class ParameterParser
{
    private readonly object[] _source;

    private int _currentIndex = 0;

    private bool _canParse = true;

    public ParameterParser(object[]? source)
    {
        _source = source ?? Array.Empty<object>();
    }

    public ParameterParser(object? source)
    {
        _source = source is object[] src
            ? src
            : source == null
                ? Array.Empty<object>()
                : new object[] { source };
    }

    public ParameterParser Parse<TResult>(out TResult result)
    {
        if (_currentIndex >= _source.Length || _source[_currentIndex] is not TResult)
        {
            _canParse = false;
            result = default!;
        }
        else
        {
            result = (TResult)_source[_currentIndex];
        }
        ++_currentIndex;
        return this;
    }

    public bool CanParse => _canParse;

    public bool Failed => !_canParse;
}