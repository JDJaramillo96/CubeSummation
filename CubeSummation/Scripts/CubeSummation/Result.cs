namespace CubeSummation
{
    /// <summary>
    /// Stores query results for the test-cases
    /// </summary>
    public class Result
    {
        #region Properties

        // Getters & Setters
        public int value
        {
            get; private set;
        }

        #endregion

        #region Class function

        // Constructor
        public Result(int value)
        {
            this.value = value;
        }

        #endregion
    }
}
