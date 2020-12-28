
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PropNotify.Core
{
    public static class PropActionExtension
    {
        public static void AddCondition<T>(this List<ActionHolder<T>> actionHolder, Action<T, string> action, Expression<Func<T, bool>> expressionBool)
        {
            actionHolder.Add(new ActionHolder<T>(action, expressionBool));
        }
        public static void AddProperty<T>(this List<ActionHolder<T>> actionHolder, Action<T,string> action, Expression<Func<T, object>> expressionProperty)
        {
            actionHolder.Add(new ActionHolder<T>(action, expressionProperty));
        }
    }
}