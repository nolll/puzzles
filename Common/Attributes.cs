using System;

namespace Pzl.Common;

[AttributeUsage(AttributeTargets.Class)]
public class NameAttribute(string name) : Attribute
{
    public string Name { get; } = name;
}

[AttributeUsage(AttributeTargets.Class)]
public class CommentAttribute(string comment) : Attribute
{
    public string Comment { get; } = comment;
}

[AttributeUsage(AttributeTargets.Class)]
public class Attributes : Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class IsFunToOptimizeAttribute : Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class NeedsRewriteAttribute : Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class NumberOfPartsAttribute(int numberOfParts) : Attribute
{
    public int NumberOfParts { get; } = numberOfParts;
}