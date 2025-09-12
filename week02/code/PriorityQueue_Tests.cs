using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items: A (priority 1), B (priority 3), C (priority 2).
    // Call Dequeue three times.
    // Expected Result: First "B" (highest priority 3), then "C" (priority 2), then "A" (priority 1).
    // Defect(s) Found: Dequeue does not remove the item from the list (queue never shrinks).
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        Assert.AreEqual("B", pq.Dequeue()); // highest priority
        Assert.AreEqual("C", pq.Dequeue()); // next highest
        Assert.AreEqual("A", pq.Dequeue()); // lowest priority
    }

    [TestMethod]
    // Scenario: Enqueue two items: X (priority 5), Y (priority 5).
    // Call Dequeue twice.
    // Expected Result: "X" should come first, then "Y" (FIFO order for equal priority).
    // Defect(s) Found: Tie-breaking is incorrect. Current code returns the last enqueued item
    // when priorities are equal instead of preserving FIFO order.
    public void TestPriorityQueue_TieBreakerFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 5);
        pq.Enqueue("Y", 5);

        Assert.AreEqual("X", pq.Dequeue()); // first in
        Assert.AreEqual("Y", pq.Dequeue()); // second in
    }

    [TestMethod]
    // Add more test cases as needed below.
    // Scenario: Enqueue single item Z (priority 10). Call Dequeue.
    // Expected Result: Returns "Z" and queue becomes empty.
    // Defect(s) Found: Last item is ignored by the loop due to incorrect loop bounds (< Count - 1).
    public void TestPriorityQueue_SingleItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Z", 10);

        Assert.AreEqual("Z", pq.Dequeue());
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to Dequeue from an empty queue.
    // Expected Result: Throws InvalidOperationException with correct message.
    // Defect(s) Found: None (this already worked).
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }
}