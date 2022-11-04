public class Graph
{
    public int Vertices { get; set; }
    public List<int>[] Adj { get; set; }
    public Graph(int V)
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
}

public class Paths
{
    public Graph? G { get; set; }
    public int Source { get; set; }

    public Paths(Graph g, int s)
    {
        this.G = G;
        this.Source = s;
    }
}

public class DepthFirstPaths
{
    public bool[]? Visited { get; set; }
    public int[]? EdgeTo { get; set; }
    public int S { get; set; }
    public DepthFirstPaths(Graph G, int s)
    {
        G = new Graph(4);
        Visited = new bool[4];
        EdgeTo = new int[4];
        this.S = s;

        DFS(G, S);
    }

    private void DFS(Graph g, int vertex)
    {
        Visited[vertex] = true;
        foreach (int w in g.AdjVertices(vertex))
        {
            if (!Visited[w])
            {
                DFS(g, w);
                EdgeTo[w] = vertex;
            }
        }
    }
}