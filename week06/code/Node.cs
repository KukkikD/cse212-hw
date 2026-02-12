public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1: ignore duplicates
        if (value == Data) return;
        
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data) //if value equa current data
            return true; // can go to the tree

        // if value less than current data 
        if (value < Data)
        {
            if (Left is null) //go to the left
            return false; // can't go no value in tree
            
           else return Left.Contains(value); //recursive
                  
        }
        else // if value more than current data
        {
            if (Right is null)//  go to the right
            return false; // can't go no value in tree

            else return Right.Contains(value); //recursive
        }      
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = (Left is null) ? 0 : Left.GetHeight();
        int rightHeight = (Right is null) ? 0 : Right.GetHeight();

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}