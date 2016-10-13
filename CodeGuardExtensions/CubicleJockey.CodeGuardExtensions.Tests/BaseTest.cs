namespace CubicleJockey.CodeGuardExtentions.Tests
{
    public abstract class BaseTest
    {
        protected string ExpectedCustomeInvalidErrorMessage(string methodName)
        {
            return $"Cannot pass Null, Empty or Whitespace as customMessage for {methodName} extension.";
        }
    }
}
