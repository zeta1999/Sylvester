﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sylvester.DataFrame.Dynamic
{
    public class AmbiguousMatchInFrameException : Exception
    {
        public AmbiguousMatchInFrameException(string name) : base($"Ambiguous match: {name}.") {}
    }

    public class SameKeyExistsInFrameException : Exception
    {
        public SameKeyExistsInFrameException(string key) : base($"Same key exists: {key}.") { }
    }

    public class KeyDoesNotExistInFrameException : Exception
    {
        public KeyDoesNotExistInFrameException(string key) : base($"Same key exists: {key}.") { }
    }

    public class TypeIsGenericException : Exception
    {
        public TypeIsGenericException(Type type) : base($"Type is generic: {type.Name}.") { }
    }

    public class TypeContainsGenericParametersException : Exception
    {
        public TypeContainsGenericParametersException(Type type) : base($"Type contains generic parameters: {type.Name}.") { }
    }

    public class CollectionReadOnlyException : Exception {}

    public class CollectionModifiedWhileEnumeratingException : Exception {}

    //public class CollectionReadOnlyException : Exception { }
}
