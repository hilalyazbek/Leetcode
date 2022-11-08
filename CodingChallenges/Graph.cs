public class Graph
{
    public int Vertices { get; set; }
    public List<int>[] Adj { get; set; }
    public int[] CC { get; set; }
    public int Count { get; set; }
    public Graph(int V)
    {
        //create list<int> for each vertex.
        Vertices = V;
        Adj = new List<int>[V];
        for (int i = 0; i < V; i++)
        {
            Adj[i] = new List<int>();
        }

        CC = new int[V]; // array used to keep track of each vertex and its group
        Count = 0; // used as component group id
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
        bool[] visited = new bool[Vertices];
        DFSUtil(vertex, visited);
    }

    private void DFSUtil(int v, bool[] visited)
    {
        //mark current node as visited, and print it
        visited[v] = true;
        Console.WriteLine(v);

        //assign same group id for every connected component
        CC[v] = Count;

        //recurse all the adj vertices of v
        List<int> adjacent = AdjVertices(v);
        foreach (int i in adjacent)
        {
            if (!visited[i])
                DFSUtil(i, visited);
        }
    }

    public void BFS(int vertex)
    {
        bool[] visited = new bool[Vertices];
        Queue<int> queue = new Queue<int>();

        visited[vertex] = true;
        queue.Enqueue(vertex);
        while (queue.Count > 0)
        {
            //dequeue and print the vertex
            Console.WriteLine(queue.Dequeue());

            List<int> adjacent = AdjVertices(vertex);
            foreach (int i in adjacent)
            {
                visited[i] = true;
                queue.Enqueue(i);
            }
        }
    }

    public void ConnectedComponents(int vertex)
    {
        DFS(vertex);
        Count++;
    }
}