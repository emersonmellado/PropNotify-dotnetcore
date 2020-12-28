using System;
using System.Linq.Expressions;

namespace PropNotify.Core
{
    public class ActionHolder<T>
    {
        public ActionHolder(Action<T, string> action, Expression<Func<T, bool>> expressionBool)
        {
            Action = action;
            ExpressionBool = expressionBool;
            ConditionExp = true;
        }
        public ActionHolder(Action<T, string> action, Expression<Func<T, object>> expressionProperty)
        {
            Action = action;
            ExpressionProperty = expressionProperty;
            ConditionExp = false;
        }

        public Action<T, string> Action { get; set; }
        public Expression<Func<T, bool>> ExpressionBool { get; set; }
        public Expression<Func<T, object>> ExpressionProperty { get; set; }
        public bool ConditionExp { get; set; }
    }
}
