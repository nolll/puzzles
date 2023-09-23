using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Common.CoordinateSystems.CoordinateSystem3D;

namespace Aoc.Puzzles.Year2021.Day22;

[DebuggerDisplay("{From.X},{From.Y},{From.Z}..{To.X},{To.Y},{To.Z}")]
public class RebootArea : IEquatable<RebootArea>
{
    public Matrix3DAddress From { get; }
    public Matrix3DAddress To { get; }
    
    public RebootArea(Matrix3DAddress from, Matrix3DAddress to)
    {
        From = from;
        To = to;
    }

    public long GetSize()
    {
        long width = To.X - From.X + 1;
        long height = To.Y - From.Y + 1;
        long depth = To.Z - From.Z + 1;

        return width * height * depth;
    }
    
    public List<RebootArea> GetSortedRemainingParts(RebootArea other)
    {
        return GetRemainingParts(other)
            .OrderBy(o => o.From.X)
            .ThenBy(o => o.From.Y)
            .ThenBy(o => o.From.Z)
            .ThenBy(o => o.To.X)
            .ThenBy(o => o.To.Y)
            .ThenBy(o => o.To.Z).ToList();
    }

    public List<RebootArea> GetRemainingParts(RebootArea other)
    {
        var parts = new List<RebootArea>();
        var cropped = new RebootArea(new Matrix3DAddress(From.X, From.Y, From.Z), new Matrix3DAddress(To.X, To.Y, To.Z));

        // x-axis pos
        if (cropped.From.X <= other.To.X && other.To.X <= cropped.To.X)
        {
            parts.Add(new RebootArea(new Matrix3DAddress(other.To.X + 1, cropped.From.Y, cropped.From.Z), new Matrix3DAddress(cropped.To.X, cropped.To.Y, cropped.To.Z)));
            cropped = new RebootArea(new Matrix3DAddress(cropped.From.X, cropped.From.Y, cropped.From.Z), new Matrix3DAddress(other.To.X, cropped.To.Y, cropped.To.Z));
        }

        // x-axis neg
        if (cropped.From.X <= other.From.X && other.From.X <= cropped.To.X)
        {
            parts.Add(new RebootArea(new Matrix3DAddress(cropped.From.X, cropped.From.Y, cropped.From.Z), new Matrix3DAddress(other.From.X - 1, cropped.To.Y, cropped.To.Z)));
            cropped = new RebootArea(new Matrix3DAddress(other.From.X, cropped.From.Y, cropped.From.Z), new Matrix3DAddress(cropped.To.X, cropped.To.Y, cropped.To.Z)); 
        }

        // y-axis pos
        if (cropped.From.Y <= other.To.Y && other.To.Y <= cropped.To.Y)
        {
            parts.Add(new RebootArea(new Matrix3DAddress(cropped.From.X, other.To.Y + 1, cropped.From.Z), new Matrix3DAddress(cropped.To.X, cropped.To.Y, cropped.To.Z)));
            cropped = new RebootArea(new Matrix3DAddress(cropped.From.X, cropped.From.Y, cropped.From.Z), new Matrix3DAddress(cropped.To.X, other.To.Y, cropped.To.Z)); 
        }

        // y-axis neg
        if (cropped.From.Y <= other.From.Y && other.From.Y <= cropped.To.Y)
        {
            parts.Add(new RebootArea(new Matrix3DAddress(cropped.From.X, cropped.From.Y, cropped.From.Z), new Matrix3DAddress(cropped.To.X, other.From.Y - 1, cropped.To.Z)));
            cropped = new RebootArea(new Matrix3DAddress(cropped.From.X, other.From.Y, cropped.From.Z), new Matrix3DAddress(cropped.To.X, cropped.To.Y, cropped.To.Z)); 
        }

        // z-axis pos
        if (cropped.From.Z <= other.To.Z && other.To.Z <= cropped.To.Z)
        {
            parts.Add(new RebootArea(new Matrix3DAddress(cropped.From.X, cropped.From.Y, other.To.Z + 1), new Matrix3DAddress(cropped.To.X, cropped.To.Y, cropped.To.Z)));
            cropped = new RebootArea(new Matrix3DAddress(cropped.From.X, cropped.From.Y, cropped.From.Z), new Matrix3DAddress(cropped.To.X, cropped.To.Y, other.To.Z)); 
        }

        // z-axis neg
        if (cropped.From.Z <= other.From.Z && other.From.Z <= cropped.To.Z)
        {
            parts.Add(new RebootArea(new Matrix3DAddress(cropped.From.X, cropped.From.Y, cropped.From.Z), new Matrix3DAddress(cropped.To.X, cropped.To.Y, other.From.Z - 1)));
        }

        return parts;
    }

    public bool IsOverlapping(RebootArea other) =>
        (From.X <= other.To.X && To.X >= other.From.X) &&
        (From.Y <= other.To.Y && To.Y >= other.From.Y) &&
        (From.Z <= other.To.Z && To.Z >= other.From.Z);
    
    public bool IsContaining(RebootArea other) =>
        From.X < other.From.X && To.X > other.To.X &&
        From.Y < other.From.Y && To.Y > other.To.Y &&
        From.Z < other.From.Z && To.Z > other.To.Z;

    public bool Equals(RebootArea? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Equals(From, other.From) && Equals(To, other.To);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((RebootArea)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(From, To);
    }
}