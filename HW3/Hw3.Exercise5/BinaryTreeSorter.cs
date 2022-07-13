#pragma warning disable IDE0160
namespace Hw3.Exercise5;
#pragma warning restore IDE0160

public static class BinaryTreeSorter
{
    private static readonly List<int> _list = new();

    public static List<int> Sort(BinaryNode? node)
    {
        if (node is null)
            return new List<int>();

        GetValues(node);

        _list.Insert(0, node.Value);

        var resultList = new List<int>(_list);
        _list.Clear();

        return resultList;
    }

    private static void GetValues(BinaryNode node)
    {
        while (true)
        {
            if (node.Left is not null)
                _list.Add(node.Left.Value);
            if (node.Right is not null)
                _list.Add(node.Right.Value);

            if (node.Left is not null)
            {
                GetValues(node.Left);
            }

            if (node.Right is not null)
            {
                GetValues(node.Right);
            }

            return;
        }
    }
}
