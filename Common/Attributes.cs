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
public class IsSlowAttribute : Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class IsFunToOptimizeAttribute : Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class NeedsRewriteAttribute : Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class NumberOfPartsAttribute(int numberOfParts) : Attribute
{
    public int NumberOfParts { get; } = numberOfParts;
}

[AttributeUsage(AttributeTargets.Class)]
public class HasUniqueInputsForParts : Attribute;

[AttributeUsage(AttributeTargets.Method)]
public class AdditionalCommonInputFileAttribute(string fileName) : Attribute
{
    public string FileName { get; } = fileName;
}

[AttributeUsage(AttributeTargets.Method)]
public class AdditionalLocalInputFileAttribute(string fileName) : Attribute
{
    public string FileName { get; } = fileName;
}