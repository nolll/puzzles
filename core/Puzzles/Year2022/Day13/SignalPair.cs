namespace Core.Puzzles.Year2022.Day13;

public class SignalPair
{
    public SignalItem Left { get; }
    public SignalItem Right { get; }

    public SignalPair(SignalItem left, SignalItem right)
    {
        Left = left;
        Right = right;
    }

    public int Compare()
    {
        return Compare(Left, Right);
    }

    public static int Compare(SignalItem left, SignalItem right)
    {
        if (left.IsValueItem && right.IsValueItem)
        {
            if (left.Value > right.Value)
                return 1;
            if (left.Value < right.Value)
                return -1;
        }

        if (left.IsListItem && right.IsValueItem)
        {
            var newItem = new SignalItem(right);
            newItem.Value = right.Value;
            right.List.Add(newItem);
            right.Value = null;
        }

        if (left.IsValueItem && right.IsListItem)
        {
            var newItem = new SignalItem(left);
            newItem.Value = left.Value;
            left.List.Add(newItem);
            left.Value = null;
        }

        if (left.IsListItem && right.IsListItem)
        {
            for (var i = 0; i < left.List.Count; i++)
            {
                if (right.List.Count < i + 1)
                    return 1;

                var result = Compare(left.List[i], right.List[i]);
                if (result != 0)
                    return result;
            }

            if (left.List.Count < right.List.Count)
                return -1;
        }

        return 0;
    }
}