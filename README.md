# Robot Coin Collection Algorithm
We solved the problem by Dynamic
Programming and Brute Force using C#. With a focus on applying several
input size in order to determine which
solution is more efficient, we have come
to the conclusion that the Dynamic
Programming is faster which has time
complexity O(R*C) unlike the Brute Force
with the exponential time .

## Introduction
### The problrm
Imagine a robot sitting on the upper left corner of
grid with r rows and c columns. The robot can only
move in two directions, right and down, but certain
cells are "off limits" such that the robot cannot step
on them. Design an algorithm to find a path for the
robot from the top left to the bottom right.
> Given a character matrix where every cell has one of the following
values.

### The Movment Rules 
Initial position is cell (0, 0) and initial direction is right.
Following are rules for movements across cells.
If face is Right, then we can move to below cells:
- Move one step ahead, i.e., cell (i, j+1) 
- Move one step down and face left, i.e., cell (i+1, j) 

## Brute Force (Recursively)
To find a path from the origin, we just work backwards, starting from
the last cell, we try to find a path to each of its adjacent cells.

### The Recursive Algorithm
```
maxCoins(i, j, d): Maximum number of coins that can be
 collected if we begin at cell (i, j)
 and direction d.
 d can be either 0 (left) or 1 (right)
 // If this is a blocking cell, return 0. isValid() checks
 // if i and j are valid row and column indexes.
 If (arr[i][j] == '#' or isValid(i, j) == false)
 return 0
 // Initialize result
 If (arr[i][j] == 'C')
 result = 1;
 Else
 result = 0;
 return result + max(maxCoins(i+1, j, 1), // Down
 maxCoins(i, j+1, 0)); // Ahead in right
```
### C# Implementation
```C#
public class MaxCollectByRec
 {
 int R, C;
 public MaxCollectByRec(int arrsize ) {
 R = arrsize;
 C = arrsize;
 }
 // to check whether current cell is out of the grid or not
 bool IsValid(int i, int j)
 {
 return (i >= 0 && i < R && j >= 0 && j < C);
 }
 public int MaxCoinRec(char[,] arr, int i, int j, int dir)
 {
 if (IsValid(i, j) == false || arr[i, j] == '#')
 return 0;
 else
 {
 int result = (arr[i, j] == 'C') ? 1 : 0;


 return result + Math.Max(MaxCoinRec(arr, i +
1, j, 0), // Down
 MaxCoinRec(arr, i, j + 1, 1));
// Ahead in right


 }
 }
 }
```
### Analisis
The time Complexity of the
Recursive IS exponential, O( 2<sup>r+c</sup> )
![image](https://user-images.githubusercontent.com/70070721/180981858-c53dea40-1b73-4a4e-8f71-2fdfa65d7218.png)



## Dynamic Programming 
Dynamic programming is mostly just a matter of taking a recursive algorithm and
finding the overlapping subproblems (that is, the repeated calls). You then cache
those results for future recursive calls.
The time complexity of above solution recursive is exponential.
We should look for a faster way. Often, we can optimize exponential algorithms by
finding duplicate work. What work are we repeating? If we walk through the
algorithm, we'll see that we are visiting squares multiple times. We can solve this
problem in Polynomial Time using Dynamic Programming.

### The Dynamic Programming Algorithm

![image](https://user-images.githubusercontent.com/70070721/180964949-c7ee2745-bb01-4e82-a941-3561695be5a9.png)

### C# Implementation
```C#
public class MaxCollectByDynamicP
 {
 int R, C;
 public MaxCollectByDynamicP(int arrsize)
 {
 R = arrsize;
 C = arrsize;
 }
 // to check whether current cell is out of the grid or not
 bool IsValid(int i, int j)
 {
 return (i >= 0 && i < R && j >= 0 && j < C);
 }
 public int MaxCoinUtil(char[,] arr, int i, int j, int dir,
int[,,] dp)
 {
 if (IsValid(i, j) == false || arr[i, j] == '#')
 return 0;
 else if (dp[i, j, dir] != -1)
 return dp[i, j, dir];
 else
 {
 dp[i, j, dir] = (arr[i, j] == 'C') ? 1 : 0;


 dp[i, j, dir] += Math.Max(MaxCoinUtil(arr, i + 1, j,
0, dp), MaxCoinUtil(arr, i, j + 1, 1, dp));
 return dp[i, j, dir];
 }
 }
 // This function mainly creates a lookup table and calls
 public int MaxCoinDP(char[,] arr)
 {
 int[,,] dp = new int[R, C, 2];
 for (int i = 0; i < dp.GetLength(0); i++)
 {
 for (int j = 0; j < dp.GetLength(1); j++)
 {
 for (int k = 0; k < dp.GetLength(2); k++)
 dp[i, j, k] = -1;
 }
 }
 return MaxCoinUtil(arr, 0, 0, 1, dp);
 }
 }
 ```
 ### Analisis
 The time
complexity =
O(R x C x d).
Since d is 2
which is
constant , time
complexity can
be written as
O(R x C).
![image](https://user-images.githubusercontent.com/70070721/180981680-ca874a3e-4298-46c8-a021-7e054f5e3ac9.png)


 ## The Algorithm Analysis's Outcome
The Dynamic programming O(R*C) method is much faster than the Brute Force O( 2<sup>r+c</sup> )

| Input Size  |  8 | 16 | 32 | 64 | 128 | 256 |
|---|---|---|---|---|---|---|
| Recursive | 00.0004262  | 05.5861244 | 05.5861244 | 776.0468821 | 602248.7631 | 36.27035121<sup>11</sup>|
| Dynamic Programming | 00.0013798 | 00.0022474 | 00.0048734 | 00.0037144 | 00.0068638  | 00.0184453 |

## Time Chart
![image](https://user-images.githubusercontent.com/70070721/180982148-be9df4fb-3e5c-4670-97a3-1c44b5385311.png)





