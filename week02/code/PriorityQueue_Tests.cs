using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue several items with different priorities and ensure the highest is removed first.
    // Expected Result: Item with priority 5, then 3, then 1.
    // Defect(s) Found: The original code skipped the last item in the list and didn't actually remove items.
    public void TestPriorityQueue_1()
    {
        var bob = "Bob";
        var tim = "Tim";
        var sue = "Sue";

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(bob, 1);
        priorityQueue.Enqueue(tim, 5);
        priorityQueue.Enqueue(sue, 3);

        Assert.AreEqual(tim, priorityQueue.Dequeue());
        Assert.AreEqual(sue, priorityQueue.Dequeue());
        Assert.AreEqual(bob, priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items where multiple items have the same highest priority.
    // Expected Result: The item added first (closest to front) should be dequeued first (FIFO).
    // Defect(s) Found: The original code used >= which picked the last item added rather than the first.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First High", 5);
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Second High", 5);

        Assert.AreEqual("First High", priorityQueue.Dequeue());
        Assert.AreEqual("Second High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}