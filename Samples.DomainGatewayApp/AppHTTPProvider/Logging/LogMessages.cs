using System.Diagnostics;

namespace AppHTTPProvider
{
    internal static class LogMessages
    {
        public static class Debug
        {

        }
        public static class Error
        {

            public static string UnknownProblem(string entityId)
            {
                var stackTrace = new StackTrace();
                var method = stackTrace.GetFrame(1).GetMethod();
                return UnknownProblem(method.Name, method.DeclaringType.Name, entityId);
            }

            public static string InvalidInput()
            {
                var stackTrace = new StackTrace();
                var method = stackTrace.GetFrame(1).GetMethod();
                return InvalidInput(method.Name, method.DeclaringType.Name);
            }

            public static string UnknownProblem(string methodName, string className, string entityId) => $"There was an error retrieving data from {className} -> {methodName}(id: {entityId}).";
            public static string InvalidInput(string methodName, string className) => $"An input value for {className} -> {methodName} is invalid.";
        }
    }
}
