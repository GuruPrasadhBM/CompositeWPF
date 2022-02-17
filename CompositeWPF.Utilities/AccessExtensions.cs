namespace CompositeWPF.Utilities
{
    public static class AccessExtensions
    {
        /// <summary>
        /// /Get private method reference using Reflection.
        /// </summary>
        /// <param name="obj"> The object for which the reference</param>
        /// <param name="methodName">Name of the method</param>
        /// <param name="args">Method Arguments</param>
        /// <returns>Method Reference</returns>
        public static object CallPrivateMethod(this object obj, string methodName, params object[] args)
        {
            var methodInfo = obj.GetType().GetMethod(methodName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (methodInfo != null)
            {
                return methodInfo.Invoke(obj, args);
            }

            return null;
        }
    }
}
