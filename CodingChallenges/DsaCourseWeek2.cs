public static class DsaCourseWeek2
{
    public static int ArithmeticEvaluation(string equation)
    {
        Stack<int> numbers = new();
        Stack<char> operators = new();

        foreach (char c in equation)
        {
            if (char.IsNumber(c))
            {
                numbers.Push(int.Parse(c.ToString()));
            }
            else if (c == '(')
            {
                continue;
            }
            else if (c == ')')
            {
                int num1 = numbers.Pop();
                int num2 = numbers.Pop();
                int op = operators.Pop();
                int res = 0;
                if (op == '+') { res = num1 + num2; }
                else if (op == '-') { res = num1 - num2; }
                else if (op == '*') { res = num1 * num2; }
                else { res = num1 / num2; }
                numbers.Push(res);
            }
            else
            {
                operators.Push(c);
            }
        }
        return numbers.Pop();
    }
}

public class StackUsingLinkedList<Item>
{
    private Node first = null;
    class Node
    {
        public Item Item { get; set; }
        public Node Next { get; set; }
    }

    public bool IsEmpty()
    {
        //check if node points to NULL, then the list is null, then the stack is empty
        return first == null;
    }

    public void Push(Item str)
    {
        // inserts a new node at the start of the linked list
        Node oldFirst = first;
        first = new Node();
        first.Item = str;
        first.Next = oldFirst;
    }

    public Item Pop()
    {
        Item item = first.Item;
        first = first.Next;
        return item;
    }
}

public class StackUsingArray<Item>
{
    public Item[] items { get; set; }
    public int N { get; set; } = 0;
    public StackUsingArray(int capacity)
    {
        items = new Item[capacity];
    }

    public bool IsEmpty()
    {
        return N == 0;
    }
    public void Push(Item item)
    {
        items[N] = item;
        N++;
    }
    public Item Pop()
    {
        return items[--N];
    }
}

public class QueueUsingLinkedList
{
    private Node first;
    private Node last;

    class Node
    {
        public string Item { get; set; }
        public Node Next { get; set; }
    }

    public bool IsEmpty()
    {
        return first == null;
    }

    public void Enqueue(string item)
    {
        Node oldLast = last;
        last = new Node();
        last.Item = item;
        last.Next = null;

        if (IsEmpty())
        {
            first = last;
        }
        else
        {
            oldLast.Next = last;
        }
    }

    public string Dequeue()
    {
        string item = first.Item;
        first = first.Next;
        if (IsEmpty())
        {
            last = null;
        }

        return item;
    }


}