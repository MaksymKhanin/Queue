# Queue implementation
Queue is implemented such that it doesn't run into the size limitation issue. 
I check on enqueue that the queue has space. If it does not, you create a new array of larger size (double) and copy the elements over. 
This isn't the most efficient, and will have an effect on Big O complexity. But it gets the job done.

# Methods
Enqueue method:
Adds elements to queue.

Dequeue method:
Removes elements from queue.

Peek method:
Shows first element.

Clear method:
Removes all elements.

Count method:
Returns queue length.
