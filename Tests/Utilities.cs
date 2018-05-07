using System;
using System.Reflection;

namespace Tests
{
    public static class Utilities
    {
        public static object ExecuteStaticPrivateMethod(Type type, string method, object[] input)
        {
            return type.GetMethod(method, BindingFlags.Static | BindingFlags.NonPublic)
                .Invoke(null, input);
        }

        public static object ExecutePrivateMethod<T>(T instance, string method, object[] input)
        {
            return typeof(T).GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(instance, input);
        }
    }
}