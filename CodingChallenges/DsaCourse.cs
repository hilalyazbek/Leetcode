public class DSACourse_UnionFind
{
    private int[] ids { get; set; }

    // O(n)
    public DSACourse_UnionFind(int n)
    {
        ids = new int[n];
        for (int i = 0; i < n; i++)
        {
            ids[i] = i;
        }
    }

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
}