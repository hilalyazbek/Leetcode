public class DiGraph
{
    public int Vertices { get; set; }
    public List<int>[] Adj { get; set; }
    public DiGraph(int V)
    {
        //create list<int> for each vertex.
        Vertices = V;
        Adj = new List<int>[V];
        for (int i = 0; i < V; i++)
        {
            Adj[i] = new List<int>();
        }
    }
    //add a link between 2 vertices (v and w)
    public void AddEdge(int v, int w)
    {
        Adj[v].Add(w);
        Adj[w].Add(v);
    }
    public List<int> AdjVertices(int v)
    {
        return Adj[v];
    }

    public void DFS(int v)
    {
        bool[] visited = new bool[Vertices];
        DFSUtil(v, visited);
    }

    private void DFSUtil(int v, bool[] visited)
    {
        visited[v] = true;
        Console.Write($"{v} ");
        List<int> adj = AdjVertices(v);
        foreach (int x in adj)
        {
            if (!visited[x])
                DFSUtil(x, visited);
        }
    }
}