namespace ApplicationForm.Tests
{
    /// <summary>
    /// Base class for all unit tests.
    /// </summary>
    public abstract class UnitTestContainer
    {
        /// <summary>
        /// Provides common asserts for all tests.
        /// </summary>
        protected virtual void AssertCore()
        {
        }

        /// <summary>
        /// Stubs the methods of the mocked dependencies.
        /// </summary>
        protected virtual void Stub()
        {
        }
    }
}
