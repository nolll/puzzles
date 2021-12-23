using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2021.Day22;

[DebuggerDisplay("{From.X},{From.Y},{From.Z}..{To.X},{To.Y},{To.Z}")]
public class RebootArea : IEquatable<RebootArea>
{
    public Matrix3DAddress From { get; }
    public Matrix3DAddress To { get; }

    public Matrix3DAddress LeftBottomClose { get; }
    public Matrix3DAddress LeftTopClose { get; }
    public Matrix3DAddress RightTopClose { get; }
    public Matrix3DAddress RightBottomClose { get; }
    public Matrix3DAddress LeftBottomFar { get; }
    public Matrix3DAddress LeftTopFar { get; }
    public Matrix3DAddress RightTopFar { get; }
    public Matrix3DAddress RightBottomFar { get; }

    public List<Matrix3DAddress> Corners;

    public RebootArea(Matrix3DAddress from, Matrix3DAddress to)
    {
        From = from;
        To = to;

        LeftBottomClose = new Matrix3DAddress(From.X, From.Y, From.Z);
        LeftTopClose = new Matrix3DAddress(From.X, To.Y, From.Z);
        RightTopClose = new Matrix3DAddress(To.X, To.Y, From.Z);
        RightBottomClose = new Matrix3DAddress(To.X, From.Y, From.Z);
        LeftBottomFar = new Matrix3DAddress(From.X, From.Y, To.Z);
        LeftTopFar = new Matrix3DAddress(From.X, To.Y, To.Z);
        RightTopFar = new Matrix3DAddress(To.X, To.Y, To.Z);
        RightBottomFar = new Matrix3DAddress(To.X, From.Y, To.Z);

        Corners = new List<Matrix3DAddress>
        {
            LeftBottomClose,
            LeftTopClose,
            RightTopClose,
            RightBottomClose,
            LeftBottomFar,
            LeftTopFar,
            RightTopFar,
            RightBottomFar
        };
    }

    public long GetSize()
    {
        var width = To.X - From.X;
        var height = To.Y - From.Y;
        var depth = To.Z - From.Z;

        return width * height * depth;
    }

    public void Subtract(RebootArea other)
    {

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
        var remaining = new List<RebootArea>();
        var overlapCorners = GetOverlapCorners(other);
        var cornerCount = overlapCorners.Count;
        if (cornerCount == 0)
        {
            
        }
        else if (cornerCount == 1)
        {
            var overlapCorner = overlapCorners.First();
            if (overlapCorner.Equals(other.LeftBottomClose))
            {
                remaining.Add(new RebootArea(LeftBottomClose, new Matrix3DAddress(overlapCorner.X - 1, To.Y, To.Z)));
                remaining.Add(new RebootArea(new Matrix3DAddress(overlapCorner.X, From.Y, From.Z), RightBottomFar));
                remaining.Add(new RebootArea(new Matrix3DAddress(overlapCorner.X, overlapCorner.Y, From.Z), RightTopClose));
            }
            else if (overlapCorner.Equals(other.RightTopFar))
            {
                remaining.Add(new RebootArea(new Matrix3DAddress(overlapCorner.X + 1, From.Y, From.Z), RightTopFar));
                remaining.Add(new RebootArea(LeftTopClose, new Matrix3DAddress(overlapCorner.X, To.Y, To.Z)));
                remaining.Add(new RebootArea(LeftBottomFar, new Matrix3DAddress(overlapCorner.X, overlapCorner.Y, To.Z)));
            }
        }
        else if (cornerCount == 2)
        {
            if (overlapCorners.Contains(other.LeftBottomClose) && overlapCorners.Contains(other.LeftBottomFar))
            {
                var closeCorner = other.LeftBottomClose;
                var farCorner = other.LeftBottomFar;
                remaining.Add(new RebootArea(LeftBottomClose, new Matrix3DAddress(closeCorner.X - 1, To.Y, To.Z)));
                remaining.Add(new RebootArea(new Matrix3DAddress(closeCorner.X, From.Y, From.Z), new Matrix3DAddress(To.X, closeCorner.Y - 1, To.Z)));
                remaining.Add(new RebootArea(new Matrix3DAddress(closeCorner.X, closeCorner.Y, From.Z), new Matrix3DAddress(To.X, To.Y, closeCorner.Z - 1)));
                remaining.Add(new RebootArea(new Matrix3DAddress(closeCorner.X, closeCorner.Y, farCorner.Z + 1), RightTopFar));
            }
        }
        else if (cornerCount == 4)
        {

        }

        return remaining;
    }

    private bool IsOverlapping(RebootArea other) =>
        (From.X <= other.To.X && To.X >= other.From.X) &&
        (From.Y <= other.To.Y && To.Y >= other.From.Y) &&
        (From.Z <= other.To.Z && To.Z >= other.From.Z);

    public List<Matrix3DAddress> GetOverlapCorners(RebootArea other) => IsOverlapping(other)
        ? other.Corners.Where(IsCoordWithin).ToList()
        : new List<Matrix3DAddress>();

    public bool IsCoordWithin(Matrix3DAddress other) =>
        other.X >= From.X && other.X <= To.X &&
        other.Y >= From.Y && other.Y <= To.Y &&
        other.Z >= From.Z && other.Z <= To.Z;

    public bool IsContaining(RebootArea other) =>
        From.X < other.From.X && To.X > other.To.X &&
        From.Y < other.From.Y && To.Y > other.To.Y &&
        From.Z < other.From.Z && To.Z > other.To.Z;

    public bool Equals(RebootArea other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Equals(From, other.From) && Equals(To, other.To);
    }

    public override bool Equals(object obj)
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