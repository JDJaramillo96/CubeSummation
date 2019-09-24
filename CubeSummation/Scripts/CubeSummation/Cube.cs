namespace CubeSummation
{
    /// <summary>
    /// Represents a 3-D Matrix object
    /// </summary>
    public class Cube
    {
        #region Properties

        // Getters & Setters
        public int[][][] matrix
        {
            get; private set;
        }

        public int n
        {
            get; private set;
        }

        #endregion

        #region Class functions

        // Constructor
        public Cube(int n)
        {
            matrix = new int[n][][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n][];

                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = new int[n];
                }
            }

            this.n = n;
        }

        // Queries
        public void Update(int x, int y, int z, int w)
        {
            matrix[x][y][z] = w;
        }

        public int Query(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            int sum = 0;

            // Iterates for each cube dimension...
            for (int x = x1; x <= x2; x++)
            {
                for (int y = y1; y <= y2; y++)
                {
                    for (int z = z1; z <= z2; z++)
                    {
                        sum += matrix[x][y][z];
                    }
                }
            }

            return sum;
        }

        #endregion
    }
}
