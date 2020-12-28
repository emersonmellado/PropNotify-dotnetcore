using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PropNotify.Interfaces;

namespace PropNotify.Core
{
    public abstract class PropNotify<T> : IPropNotify<T> where T : IEquatable<T>
    {
        protected PropNotify()
        {
            Actions = new List<ActionHolder<T>>();
            Notifications = new List<Dictionary<string, T>>();
        }

        public List<Dictionary<string, T>> Notifications { get; set; }

        public void AddNotification(string trigger, T obj)
        {
            Notifications.Add(new Dictionary<string, T> { { trigger, obj } });
        }
        public List<ActionHolder<T>> Actions { get; set; }

        public void AddWatchCondition(params Expression<Func<T, bool>>[] conditionsToWatch)
        {
            if (conditionsToWatch == null)
                throw new ArgumentNullException(nameof(conditionsToWatch));
            foreach (var expression in conditionsToWatch)
            {
                Actions.AddCondition(OnNotify, expression);
            }
        }

        public void AddWatchProperty(params Expression<Func<T, object>>[] propsToObserver)
        {
            if (propsToObserver == null)
                throw new ArgumentNullException(nameof(propsToObserver));
            foreach (var expression in propsToObserver)
            {
                Actions.AddProperty(OnNotify, expression);
            }
        }

        public abstract void OnNotify(T obj, string triggeredBy);

    }
}