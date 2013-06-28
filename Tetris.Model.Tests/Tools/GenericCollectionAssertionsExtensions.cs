using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using FluentAssertions;
using FluentAssertions.Collections;

namespace Tetris.Model.Tests.Tools
{
    public static class GenericCollectionAssertionsExtensions
    {
        public static void NotHaveTheSame<TItem, TValue>(this GenericCollectionAssertions<TItem> assertions,
                                                         Expression<Func<TItem, TValue>> expression) 
        {
            var propertyFunc = expression.Compile();
            var lastValue = default(TValue);
            var foundDifferentValue = false;
            foreach (var thisValue in assertions.Subject.Select(propertyFunc))
            {
                if (!lastValue.Equals(default(TValue)))
                {
                    foundDifferentValue = !thisValue.Equals(lastValue);
                    if (foundDifferentValue)
                        break;
                }
                lastValue = thisValue;
            }
            if (!foundDifferentValue)
            {
                var reason = GetReason(expression, lastValue);
                false.Should().BeTrue(reason);
            }
        }

        private static string GetReason<TItem, TValue>(Expression<Func<TItem, TValue>> expression, TValue value)
        {
            var propertyName = GetPropertyName(expression);
            var itemTypeName = typeof (TItem).Name;
            var reason = string.Format("not all {0}s should have the same value for {1}", itemTypeName, propertyName);
            if (IsNiceToString<TValue>())
            {
                reason += string.Format(" (they all are {0})", value);
            }
            return reason;
        }

        private static bool IsNiceToString<TValue>()
        {
            if (typeof (TValue).IsValueType)
                return true;
            return IsMethodOverridden<TValue>("ToString");
        }

        private static bool IsMethodOverridden<TValue>(string methodName)
        {
            var methodInfo = typeof(TValue).GetMethod(methodName, BindingFlags.Instance);
            return methodInfo != null && methodInfo.DeclaringType == typeof (TValue);
        }

        private static string GetPropertyName<TItem, TValue>(Expression<Func<TItem, TValue>> expression)
        {
            var body = (MemberExpression)expression.Body;
            return body.Member.Name;
        }
    }
}