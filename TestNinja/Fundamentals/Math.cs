using System.Collections.Generic;


namespace TestNinja.Fundamentals
{
    public class Math
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        public IEnumerable<int> GetOddNumbers(int limit)
        {
            for (var i = 0; i <= limit; i++)
                if (i % 2 != 0)
                    //State Machine: The yield keyword creates a state machine behind the scenes. 
                    //This state machine keeps track of the current position in the code and the current state of local variables.
                    //The yield keyword allows you to create an iterator method that can return values one at a time.
                    yield return i;
        }
    }
}