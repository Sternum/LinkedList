namespace LinkedList;

public class LinkedList
{
    private LinkedListNode head = null;
    
    public LinkedList() { }

    public LinkedList(int value)
    {
        this.head = new LinkedListNode() { Value = value };
    }

    private LinkedListNode GetLast()
    {
        LinkedListNode current = this.head;
        while (current.Next != null)
        {
            current = current.Next;
        }

        return current;
    }

    private LinkedListNode GetNodeAtIndex(int index)
    {
        LinkedListNode current = this.head;
        int currentIndex = 0;
        while (current != null)
        {
            if (currentIndex == index)
            {
                return current;
            }

            current = current.Next;
            currentIndex++;
        }

        return null;
    }

    private LinkedListNode GetNodeByValue(int value)
    {
        LinkedListNode current = this.head;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                return current;
            }

            current = current.Next;
        }

        return null;
    }

    private void RemoveNode(LinkedListNode nodeToRemove)
    {
        LinkedListNode nextNode = nodeToRemove.Next;
        LinkedListNode prevNode = nodeToRemove.Prev;
        if (prevNode == null)
        {
            this.head = nextNode;
        }
        if(prevNode != null) prevNode.Next = nextNode;
        if(nextNode != null) nextNode.Prev = prevNode;
        nodeToRemove = null;
    }
    public void Add(int value)
    {
        if (this.head == null)
        {
            this.head = new LinkedListNode() { Value = value };
            return;
        }
        LinkedListNode lastItem = GetLast();
        lastItem.Next = new LinkedListNode() { Value = value, Prev = lastItem};
    }
    
    public void Remove(int value)
    {
        LinkedListNode nodeToRemove = GetNodeByValue(value);
        if (nodeToRemove != null)
        {
            RemoveNode(nodeToRemove);
        }
    }

    public void RemoveAtIndex(int index)
    {
        LinkedListNode nodeToRemove = GetNodeAtIndex(index);
        if (nodeToRemove != null)
        {
            RemoveNode(nodeToRemove);   
        }
    }

    public void Find(int value)
    {
        LinkedListNode current = GetNodeByValue(value);
        if (current != null)
        {
            Console.WriteLine("Value Found: " + current.Value);
        } else
        {
            Console.WriteLine("Value Did not Found");    
        }
    }
    
    public void Print()
    {
        LinkedListNode current = this.head;
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Next;
        }
    }

    public void PrintReverse()
    {
        LinkedListNode current = GetLast();
        while (current != null)
        {
            Console.WriteLine(current.Value);
            current = current.Prev;
        }
    }
}