/// <summary>
/// Maintains a customer service queue.
/// Allows new customers to be added and customers to be served in FIFO order.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Test cases for the CustomerService queue will be written here
        // Each test should verify behavior based on the given requirements


    
        // Test 1
        // Scenario: Create a queue with an invalid size
        // Expected Result: Queue size should default to 10
        Console.WriteLine("Test 1");
        var cs = new CustomerService(0);
        Console.WriteLine(cs);
        // Defect(s) Found:

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add customers to the queue
        // Expected Result: Customers should be added in the correct order
        Console.WriteLine("Test 2");

        cs = new CustomerService(4);
        cs.AddNewCustomer();
        Console.WriteLine(cs);

        Console.WriteLine("=================");

        // Test 3
        //Scenario: Add more customers than the maximum size
        //Expected Result: Error message is displayed and customer is not added
        Console.WriteLine("Test 3");

        cs = new CustomerService(1);
        cs.AddNewCustomer(); // 1st customber
        cs.AddNewCustomer(); // 2nd customer (must error)
        Console.WriteLine(cs);

        Console.WriteLine("=================");

        // Test 4
        //Scenario: Add two customers and serve them
        //Expected Result: First customer added is served first
        Console.WriteLine("Test 4");

        cs = new CustomerService(4);
        cs.AddNewCustomer();
        cs.AddNewCustomer();
        cs.ServeCustomer();
        cs.ServeCustomer();

        Console.WriteLine("=================");

        // Test 5
        //Scenario: Call ServeCustomer on an empty queue
        //Expected Result: Error message is displayed
        Console.WriteLine("Test 5");

        cs = new CustomerService(4);
        cs.ServeCustomer();

    }

    // Internal list used to store customers in the queue
    private readonly List<Customer> _queue = new();

    // Maximum number of customers allowed in the queue
    private readonly int _maxSize;

    /// <summary>
    /// Initializes the customer service queue.
    /// If the provided size is invalid (<= 0), the queue defaults to size 10.
    /// </summary>
    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Represents a customer record in the service queue.
    /// This is an inner class of CustomerService.
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        // Customer name
        private string Name { get; }

        // Customer account identifier
        private string AccountId { get; }

        // Description of the customer's problem
        private string Problem { get; }

        /// <summary>
        /// Returns a formatted string representing the customer.
        /// </summary>
        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompts the user for customer information and adds the customer to the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Check if the queue has reached its maximum size
        if (_queue.Count >=  _maxSize) { //defect 1  change from > to >=
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        // Read customer information from user input
        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();

        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();

        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create a new customer object and add it to the back of the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Removes the next customer from the front of the queue
    /// and displays the customer's information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count == 0) { // Defect 2: if empty queue send error
        Console.WriteLine("No Customers in the queue"); 
        return;
        }

        var customer = _queue[0]; // if not empty queue, get before remove
        _queue.RemoveAt(0); 
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Returns a string representation of the customer service queue.
    /// Useful for debugging and testing.
    /// </summary>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " +
               string.Join(", ", _queue) + "]";
    }
}
