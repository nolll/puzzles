using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Pzl.Common;

public static class PuzzleDataReader
{
    public static List<PuzzleData> ReadData<T>() where T : Puzzle => 
        GetConcreteSubclassesOf<T>().Select(CreateData).ToList();

    private static PuzzleData CreateData(Type type) => new(
        type,
        GetName(type),
        GetComment(type),
        IsSlow(type),
        NeedsRewrite(type),
        IsFunToOptimize(type),
        GetNumberOfParts(type),
        HasUniqueInputsForParts(type));

    private static string GetName(MemberInfo type) =>
        type.GetCustomAttribute<NameAttribute>(false)?.Name ?? "No name provided";

    private static string? GetComment(MemberInfo type) =>
        type.GetCustomAttribute<CommentAttribute>(false)?.Comment;

    private static bool IsSlow(MemberInfo type) =>
        type.GetCustomAttribute<IsSlowAttribute>(false) is not null;

    private static bool NeedsRewrite(MemberInfo type) =>
        type.GetCustomAttribute<NeedsRewriteAttribute>(false) is not null;

    private static bool IsFunToOptimize(MemberInfo type) =>
        type.GetCustomAttribute<IsFunToOptimizeAttribute>(false) is not null;

    private static int GetNumberOfParts(MemberInfo type) =>
        type.GetCustomAttribute<NumberOfPartsAttribute>(true)?.NumberOfParts ?? 1;
    
    private static bool HasUniqueInputsForParts(MemberInfo type) =>
        type.GetCustomAttribute<HasUniqueInputsForParts>(true) is not null;

    private static IEnumerable<Type> GetConcreteSubclassesOf<T>() where T : class =>
        Assembly
            .GetAssembly(typeof(T))?
            .GetTypes()
            .Where(o => o.IsSubclassOf(typeof(T)) && o is
            {
                IsClass: true,
                IsAbstract: false
            })
        ?? new List<Type>();
}
