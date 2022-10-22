class DsaCourseWeek2
{

}

public class StackUsingLinkedList
{
    private Node first = null;
    class Node
    {
        public string Item { get; set; }
        public Node Next { get; set; }
    }

    public bool IsEmpty()
    {
        //check if node points to NULL, then the list is null, then the stack is empty
        return first == null;
    }

    public void Push(string str)
    {
        // inserts a new node at the start of the linked list
        Node oldFirst = first;
        first = new Node();
        first.Item = str;
        first.Next = oldFirst;
    }

    public string Pop()
    {
        string item = first.Item;
        first = first.Next;
        return item;
    }
}