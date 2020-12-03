using System.Collections.Generic;

namespace DotnetDISingletonDisposingPoC
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Peeks into stack, and returns default value if stack is empty
        /// </summary>
        /// <param name="stack">Stack to peek to</param>
        /// <typeparam name="T">Type of objects in stack</typeparam>
        /// <returns>Peeked value or default(T) if stack is empty</returns>
        public static T NullPeek<T>(this Stack<T> stack)
        {
            if(stack.Count == 0)
                return default(T);

            return stack.Peek();
        }
    }
}