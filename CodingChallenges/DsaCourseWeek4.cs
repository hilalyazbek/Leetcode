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
    public void Put(int key,string value)
    {
        root = Put(root, key, value);
    }
    public Node Put(Node x, int key, string value)
    {
        if (x == null) return new Node(key, value);
        if(key < x.key)
        {
            x.left = Put(x.left, key, value);
        }
        else if (key > x.key)
        {
            x.right = Put(x.right, key, value);
        }
        else if(key == x.key)
        {
            x.val = value;//update the value if the key exists
        }
        return x;
    }

}
