namespace System
{
    /// <summary>
    /// Provides extention methods for the standard Math class
    /// </summary>
    public static class MathExtentions
    {
        #region Class functions

        public static int Clamp(this int n, int min, int max) => (n >= min) ? (n <= max) ? n : max : min;

        #endregion
    }
}
