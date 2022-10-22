public class DSACourse_UnionFind
{
    private int[] ids { get; set; }
    private int[] size { get; set; }

    // O(n)
    public DSACourse_UnionFind(int n)
    {
        size = new int[n];
        ids = new int[n];
        for (int i = 0; i < n; i++)
        {
            ids[i] = i;
        }
    }

    #region Quick Find - SLOW

    //quick find algorithm O(1)
    public bool IsConnected(int p, int q)
    {
        return ids[p] == ids[q];
    }

    //change all entries with idp to idq O(n)
    public void Union(int p, int q)
    {
        int idP = ids[p];
        int idQ = ids[q];

        if (idP != idQ)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i] == idP)
                {
                    ids[i] = idQ;
                }
            }
        }
    }
    #endregion

    #region Quick Union - Still slow but better than quick find.
    public void QuickUnion(int p, int q)
    {
        int i = GetRoot(p);
        int j = GetRoot(q);
        ids[i] = j;
    }

    //chase parent pointer until you reach the root node => 
    //i = ids[i] -> this indicates a root node. it references itself
    public int GetRoot(int i)
    {
        while (i != ids[i])
        {
            i = ids[i];
        }
        return i;
    }

    public bool QuickIsConnected(int p, int q)
    {
        return GetRoot(p) == GetRoot(q);
    }

    #endregion

    #region Weighted Quick Union
    public void WeightedQuickUnion(int p, int q)
    {
        int i = GetRoot(p);
        int j = GetRoot(q);
        if (i == j) { return; }

        if (size[i] < size[j])
        {
            ids[i] = j;
            size[j] += size[i];
        }
        else
        {
            ids[j] = i;
            size[i] += size[j];
        }
    }
    #endregion

    #region Path Compression
    // make every node point to its grandparent node, to make the tree as flat as possible
    public int GetRootPathCompression(int i)
    {
        while (i != ids[i])
        {
            ids[i] = ids[ids[i]]; // set id of each node to the root.
            i = ids[i];
        }
        return i;
    }
    #endregion
}