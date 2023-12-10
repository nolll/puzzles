using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Pzl.Common;

public class PuzzleFactory
{
    public static List<PuzzleData> GetTypes<T>() where T : Puzzle
    {
        return GetConcreteSubclassesOf<T>().Select(CreateData).ToList();
    }

    private static PuzzleData CreateData(Type type)
    {
        var comment = GetComment(type);
        var isSlow = IsSlow(type);
        var needsRewrite = NeedsRewrite(type);
        var isFunToOptimize = IsFunToOptimize(type);
        return new PuzzleData(type, comment, isSlow, needsRewrite, isFunToOptimize);
    }

    public static Puzzle CreateInstance<T>(Type t) where T : Puzzle
    {
        if (Activator.CreateInstance(t) is not T puzzle)
            throw new Exception($"Could not create puzzle: {t}");

        return puzzle;
    }

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

    private static string? GetComment(MemberInfo type) => 
        type.GetCustomAttribute<CommentAttribute>(false)?.Comment;

    private static bool IsSlow(MemberInfo type) =>
        type.GetCustomAttribute<IsSlowAttribute>(false) is not null;

    private static bool NeedsRewrite(MemberInfo type) =>
        type.GetCustomAttribute<NeedsRewriteAttribute>(false) is not null;

    private static bool IsFunToOptimize(MemberInfo type) =>
        type.GetCustomAttribute<IsFunToOptimizeAttribute>(false) is not null;
}