public static class DsaCourseWeek4
{

}

//BST class implementation
public class Node
{
    public int key { get; set; }
    public string val { get; set; }
    public Node left { get; set; }
    public Node right { get; set; }
    public int count { get; set; }

    public Node(int key, string val)
    {
        this.key = key;
        this.val = val;
    }

    Node root = new Node(1, "root node");
    // search in a BST
    public string Search(int key)
    {
        Node x = root;
        while (x != null)
        {
            if (key < x.key)
            {
                x = x.left;
            }
            else if (key > x.key)
            {
                x = x.right;
            }
            else if (key == x.key)
            {
                return x.val;
            }
        }
        return null;
    }

    // insert in a BST
    public void Put(int key, string value)
    {
        root = Put(root, key, value);
    }
    public Node Put(Node x, int key, string value)
    {
        if (x == null) return new Node(key, value);
        if (key < x.key)
        {
            x.left = Put(x.left, key, value);
        }
        else if (key > x.key)
        {
            x.right = Put(x.right, key, value);
        }
        else if (key == x.key)
        {
            x.val = value;//update the value if the key exists
        }
        x.count = 1 + Size(x.left) + Size(x.right);
        return x;
    }

    //Inorder Tree Traversal
    public Queue<int> Keys()
    {
        Queue<int> q = new();
        Inorder(root, q);
        return q;
    }

    private void Inorder(Node root, Queue<int> q)
    {
        if (root == null) return;
        Inorder(root.left, q);
        q.Enqueue(root.key);
        Inorder(root.right, q);
    }

    //implement breadth first search
    private void LevelOrder(Node root, Queue<Node> q)
    {

        q.Enqueue(root);
        while (q.Count != 0)
        {
            Node temp = q.Dequeue();
            Console.Write(temp.key + " ");

            if (temp.left != null)
                q.Enqueue(temp.left);
            if (temp.right != null)
                q.Enqueue(temp.right);
        }
    }
    public int Size()
    {
        return Size(root);
    }
    public int Size(Node node)
    {
        if (node == null) return 0;
        return node.count;
    }
    public void DeleteMin()
    {
        root = DeleteMin(root);
    }

    private Node DeleteMin(Node root)
    {
        if (root.left == null) return root.right;
        root.left = DeleteMin(root.left);
        root.count = 1 + Size(root.left) + Size(root.right);
        return root;
    }

    public void Delete(int key)
    {
        root = Delete(root, key);
    }

    private Node Delete(Node node, int key)
    {
        // search the tree
        if (node == null) return null;
        if (key < node.key) Delete(root.left, key);
        else if (key > node.key) Delete(node.right, key);

        else
        {
            // no right child
            if (node.right == null) return node.left;
            // no left child
            else if (node.left == null) return node.right;

            // if node has 2 children.
            Node x = node.Min(node.right); // find min node from right subtree
            node.key = x.key; node.val = x.val; //replace node to be deleted with min node

            node.DeleteMin(node.right); //delete the min node in the right subtree
        }
        node.count = Size(node.left) + Size(node.right) + 1;

        return node;
    }

    private int Min()
    {
        return Min(root).key;
    }
    private Node Min(Node x)
    {
        if (x.left == null) return x;
        else return Min(x.left);
    }

    private int Max()
    {
        return Max(root).key;
    }

    private Node Max(Node x)
    {
        if (root.right == null) return root;
        else return Max(x.right);
    }

    private int Floor(int key)
    {
        return Floor(root, key);
    }

    private int Floor(Node root, int key)
    {
        if (root == null) return -1;
        if (root.key == key) return root.key;
        if (root.key > key) return Floor(root.left, key);

        int floorVal = Floor(root.right, key);
        return floorVal <= key ? floorVal : root.key;
    }


    private int Ceiling(int key)
    {
        return Ceiling(root, key);
    }

    private int Ceiling(Node root, int key)
    {
        if (root == null) return -1;

        //if node key is smaller, they ceil must be in the right subtree
        if (root.key < key)
        {
            return Ceiling(root.right, key);
        }
        //else, either its in left subtree or root key == key
        int ceil = Ceiling(root.left, key);
        return ceil >= key ? ceil : root.key;
    }
}
