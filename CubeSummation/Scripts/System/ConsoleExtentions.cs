using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// Provides extention methods for the standard Console class
    /// </summary>
    public static class ConsoleExtentions
    {
        #region Properties

        public static bool consolePrinting = false;

        public static Queue<string> data = new Queue<string>();

        #endregion

        #region Class functions

        public static void TryWriteLine(string value)
        {
            if (consolePrinting)
                Console.WriteLine(value);
        }

        // Data functions based on: https://stackoverflow.com/questions/42727664/how-can-i-simulate-user-input-from-a-console
        public static void SetTestData(string data)
        {
            ConsoleExtentions.data = new Queue<string>(data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.TrimStart()));
        }

        public static void SetTestDataFromFile(string path)
        {
            data = new Queue<string>(File.ReadAllLines(path));
        }

        public static string ReadData()
        {
            return data.Dequeue();
        }

        #endregion
    }
}
