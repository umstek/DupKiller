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
    }
}