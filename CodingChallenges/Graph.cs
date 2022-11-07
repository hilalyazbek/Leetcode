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

    //DFS traversal starting from "vertex" 
    public void DFS(int vertex)
    {
        bool[] visited = new bool[vertex];
        DFSUtil(vertex, visited);
    }

    private void DFSUtil(int v, bool[] visited)
    {
        //mark current node as visited, and print it
        visited[v] = true;
        Console.WriteLine(v);

        //recurse all the adj vertices of v
        List<int> adjacent = AdjVertices(v);
        foreach (int i in adjacent)
        {
            if (!visited[i])
                DFSUtil(i, visited);
        }
    }
}