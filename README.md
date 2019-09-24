# CubeSummation
Project base on 'Cube Summation' problem from HackerRank.

## Problem
You are given a 3-D Matrix in which each block contains 0 initially. The first block is defined by the coordinate (1,1,1) and the last block is defined by the coordinate (N,N,N). There are two types of queries.

`UPDATE x y z W`

Updates the value of block (x,y,z) to W.

`QUERY x1 y1 z1 x2 y2 z2`

Calculates the sum of the value of blocks whose x coordinate is between x1 and x2 (inclusive), y coordinate between y1 and y2 (inclusive) and z coordinate between z1 and z2 (inclusive).

### Input format
The first line contains an integer 'T', the number of test-cases. 'T' testcases follow. <br />
For each test case, the first line will contain two integers 'N' and 'M' separated by a single space. <br />
'N' defines the N * N * N matrix. <br />
'M' defines the number of operations. <br />
The next 'M' lines will contain either <br />

 ```cofee
 1. UPDATE x y z W
 2. QUERY  x1 y1 z1 x2 y2 z2
 ```

### Output format
Print the result for each QUERY.

### Constraints
1 <= T <= 50 <br />
1 <= N <= 100 <br />
1 <= M <= 1000 <br />
1 <= x1 <= x2 <= N <br />
1 <= y1 <= y2 <= N <br />
1 <= z1 <= z2 <= N <br />
1 <= x,y,z <= N <br />
-109 <= W <= 109 <br />

### Sample input
```cofee
2
4 5
UPDATE 2 2 2 4
QUERY 1 1 1 3 3 3
UPDATE 1 1 1 23
QUERY 2 2 2 4 4 4
QUERY 1 1 1 3 3 3
2 4
UPDATE 2 2 2 1
QUERY 1 1 1 1 1 1
QUERY 1 1 1 2 2 2
QUERY 2 2 2 2 2 2
```

### Sample output
```cofee
4
4
27
0
1
1
```

### Explanation
First test case, we are given a cube of 4 * 4 * 4 and 5 queries. Initially all the cells (1,1,1) to (4,4,4) are 0.<br />

`UPDATE 2 2 2 4` makes the cell (2,2,2) = 4. <br />
`QUERY 1 1 1 3 3 3` as (2,2,2) is updated to 4 and the rest are all 0. The answer to this query is 4. <br />
`UPDATE 1 1 1 23` updates the cell (1,1,1) to 23. <br />
`QUERY 2 2 2 4 4 4` only the cell (1,1,1) and (2,2,2) are non-zero and (1,1,1) is not between (2,2,2) and (4,4,4). So, the answer is 4. <br />
`QUERY 1 1 1 3 3 3` 2 cells are non-zero and their sum is 23+4 = 27. <br />

## Installation

Please, go to the realease tab, download the project, and open it in Visual Studio 2017 or Visual Studio 2019 (.sln). Feel free to input custom data.

## License

[MIT](https://github.com/dguo/make-a-readme/blob/master/LICENSE)
