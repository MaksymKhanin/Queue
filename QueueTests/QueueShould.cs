using AutoFixture.Xunit2;
using FluentAssertions;
using Queue;
using System;
using Xunit;

namespace QueueTests
{
    public class QueueShould
    {
        Queue<int> _sut;

        #region privates

        private void CreateQueueWithCapacity(int capacity)
        {
            _sut = new Queue<int>(capacity);
        }

        private void EnqueueFullCapacity(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                var inputValue = i + 1;
                _sut.Enqueue(inputValue);
            }
        }

        private void DequeueFullCapacity(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                _sut.Dequeue();
            }
        }

        #endregion


        [Theory(DisplayName = "Enqueue should fail when enqueuing more than capacity")]
        [InlineAutoData]
        public void Test1(int capacity)
        {
            CreateQueueWithCapacity(capacity);
            EnqueueFullCapacity(capacity);

            Action a = () => _sut.Enqueue(capacity + 1);
            a.Should().Throw<InvalidOperationException>().WithMessage("Queue is full");

        }

        [Theory(DisplayName = "Dequeue should fail when dequeuing more than capacity")]
        [InlineAutoData]
        public void Test2(int capacity)
        {
            CreateQueueWithCapacity(capacity);
            EnqueueFullCapacity(capacity);
            DequeueFullCapacity(capacity);

            Action a = () => _sut.Dequeue();
            a.Should().Throw<InvalidOperationException>().WithMessage("Queue is empty");

        }

        [Theory(DisplayName = "Enqueue should success when enqueuing full capacity")]
        [InlineAutoData]
        public void Test3(int capacity)
        {
            CreateQueueWithCapacity(capacity);
            EnqueueFullCapacity(capacity - 1);

            Action a = () => _sut.Enqueue(capacity + 1);
            a.Should().NotThrow();
        }

        [Theory(DisplayName = "Enqueue should success when enqueuing full capacity and dequeuing full capacity")]
        [InlineAutoData]
        public void Test4(int capacity)
        {
            CreateQueueWithCapacity(capacity);
            EnqueueFullCapacity(capacity);
            DequeueFullCapacity(capacity - 1);

            Action a = () => _sut.Dequeue();
            a.Should().NotThrow();

        }

        [Theory(DisplayName = "Enqueue should success when enqueuing full capacity and dequeuing full capacity and adding again full")]
        [InlineAutoData]
        public void Test5(int capacity)
        {
            CreateQueueWithCapacity(capacity);
            EnqueueFullCapacity(capacity);
            DequeueFullCapacity(capacity);
            EnqueueFullCapacity(capacity - 1);

            Action a = () => _sut.Enqueue(capacity + 1);
            a.Should().NotThrow();
        }
    }
}
