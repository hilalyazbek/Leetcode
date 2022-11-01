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
}

public class BST
{

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
        if (node.key < key) Delete(node.left, key);
        else if (node.key > key) Delete(node.right, key);

        else
        {
            // no right child
            if (node.right == null) return node.left;

            // no left child
            if (node.left == null) return node.right;

            // replace with successor
            Node t = node;
            node.Min(t.right);
            node.right = DeleteMin(t.right);
            node.left = t.left;
        }
        node.count = Size(node.left) + Size(node.right) + 1;

        return node;

    }
    //TODO: Implement Floor Function
    //TODO: Implement Ceiling Function

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
}
