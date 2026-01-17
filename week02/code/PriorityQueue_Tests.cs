using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: FAIL 
    // Dequeue did not always return the highest priority item and did not remove
    // the dequeued item from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("mid", 5);
        priorityQueue.Enqueue("high-last", 10); // highest priority at LAST index

        Assert.AreEqual("high-last", priorityQueue.Dequeue(), "Should remove highest priority even if it's last.");
        Assert.AreEqual("mid", priorityQueue.Dequeue(), "After removing highest, next Dequeue should return next highest (and prove removal happened).");
    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: FAIL - Queue did not maintain FIFO order when multiple items had the same priority.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 10);
        priorityQueue.Enqueue("B", 10);
        priorityQueue.Enqueue("C", 1);

        Assert.AreEqual("A", priorityQueue.Dequeue(), "Ties must be FIFO (A before B).");
        Assert.AreEqual("B", priorityQueue.Dequeue(), "Second tie item should be next.");
        Assert.AreEqual("C", priorityQueue.Dequeue(), "Remaining item should dequeue normally.");

        var ex = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    // Add more test cases as needed below.
}