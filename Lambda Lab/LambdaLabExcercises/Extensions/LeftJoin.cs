using System.Collections.Generic;

namespace System.Linq
{
    public static class LeftJoinExtension
    {
        public static IEnumerable<TResult> LeftJoin<TLeft, TRight, TKey, TResult>(
            this IEnumerable<TLeft> left,
            IEnumerable<TRight> right,
            Func<TLeft, TKey> leftKeySelector,
            Func<TRight, TKey> rightKeySelector,
            Func<TKey, TLeft, TRight, TResult> resultSelector)
        {
            return left
                .GroupJoin(right,
                           leftKeySelector,
                           rightKeySelector,
                           (l, r) => new { Left = l, Right = r })
                .SelectMany(lr => lr.Right.DefaultIfEmpty(),
                            (l, r) => resultSelector(leftKeySelector(l.Left), l.Left, r));
        }
    }
}