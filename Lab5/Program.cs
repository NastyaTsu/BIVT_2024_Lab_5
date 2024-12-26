using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        static long Combinations(int n, int k)
        {
            if (k > n) return 0;
            if (k == 0 || k == n) return 1;
            long numm = Factorial(n);
            long d = Factorial(k) * Factorial(n - k);
            return numm / d;
        }

        static long Factorial(int num)
        {
            long result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }
        answer = Factorial(n) / (Factorial(k) * Factorial(n - k));

        // create and use Combinations(n, k);
        // create and use Factorial(n);

        // end

        return answer;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        // create and use GeronArea(a, b, c);
        double a1 = first[0], b1 = first[1], c1 = first[2];
        double a2 = second[0], b2 = second[1], c2 = second[2];

        if (a1 < 0 || b1 < 0 || c1 < 0 || !(a1 < b1 + c1 && b1 < a1 + c1 && c1 < a1 + b1))
        {
            return -1;
        }

        if (a2 < 0 || b2 < 0 || c2 < 0 || !(a2 < b2 + c2 && b2 < a2 + c2 && c2 < a2 + b2))
        {
            return -1;
        }

        double s = GeronArea(a1, b1, c1);
        double k = GeronArea(a2, b2, c2);

        if (s > k && answer != -1)
            answer = 1;
        else if (k > s && answer != -1)
            answer = 2;
        else if (answer != -1)
            answer = 0;
        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }
    double GeronArea(double a, double b, double c)
    {
        double p = (a + b + c) / 2.0;
        double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        return S;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        double dist1 = 0, dist2 = 0;
        dist1 = GetDistance(v1, a1, time);
        dist2 = GetDistance(v2, a2, time);

        if (dist1 < dist2)
        {
            answer = 2;
        }
        else if (dist2 < dist1)
        {
            answer = 1;
        }
        else
        {
            answer = 0;
        }
        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }
    double GetDistance(double v, double a, int t)
    {
        double S = v * t + a * t * t / 2;
        return S;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        int time = 1;
        while (GetDistance(v1, a1, time) > GetDistance(v2, a2, time))
        {
            time++;
        }
        answer = time;
        // use GetDistance(v, a, t); t - hours

        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here
        int rowA, rowB, columnA, columnB;

        FindMaxIndex(A, out rowA, out columnA);
        FindMaxIndex(B, out rowB, out columnB);

        (A[rowA, columnA], B[rowB, columnB]) = (B[rowB, columnB], A[rowA, columnA]);
        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }
    void FindMaxIndex(int[,] matrix, out int row, out int column)
    {
        int max = int.MinValue;
        row = column = 0;
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] > max)
                {
                    max = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
    }


    public void Task_2_2(double[] A, double[] B)
    {
        // code here

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here
        if (B.GetLength(0) != B.GetLength(1) || B.GetLength(1) != 5 || C.GetLength(0) != C.GetLength(1) || C.GetLength(0) != 6) return;
        B = Change(B);
        C = Change(C);
        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }
    int[,] Change(int[,] matrix)
    {
        int[,] ans = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
        int row = FindDiagonalMaxInde(matrix);
        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i < row)
                    ans[i, j] = matrix[i, j];
                else
                    ans[i, j] = matrix[i + 1, j];
            }
        }
        return ans;
    }
    int FindDiagonalMaxInde(int[,] matrix)
    {
        int max = int.MinValue;
        int row = 0, column = 0;
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            if (matrix[i, i] > max)
            {
                max = matrix[i, i];
                row = i;
                column = i;
            }
        }
        return row;
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here
        int maxRowA = FindMaxInColumn(A, 0);
        int maxRowB = FindMaxInColumn(B, 0);
        int colsA = A.GetLength(1);
        int colsB = B.GetLength(1);

        if (A.GetLength(1) != B.GetLength(1)) return;
        for (int j = 0; j < colsA; j++)
        {
            (A[maxRowA, j], B[maxRowB, j]) = (B[maxRowB, j], A[maxRowA, j]);
        }
        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }
    int FindMaxInColumn(int[,] matrix, int columnIndex)
    {
        int rowIndex = 0;
        int maxValue = matrix[0, columnIndex];

        for (int i = 1; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, columnIndex] > maxValue)
            {
                maxValue = matrix[i, columnIndex];
                rowIndex = i;
            }
        }
        return rowIndex;
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here

        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here
        int maxi, maxj;

        maxi = maxelement(B);
        maxj = maxelement(C);

        B = answer(B, C, maxi, maxj);
        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }
    int CountRowPositive(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[rowIndex, j] > 0)
            {
                count++;
            }
        }
        return count;
    }
    int[,] answer(int[,] B, int[,] C, int maxi, int maxj)
    {
        int[,] result = new int[C.GetLength(0), B.GetLength(1)];
        for (int i = 0; i < C.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (i <= maxi)
                {
                    result[i, j] = B[i, j];
                }
                else if (i == maxi + 1)
                {
                    result[i, j] = C[j, maxj];
                }
                else
                {
                    result[i, j] = B[i - 1, j];
                }
            }
        }

        return result;
    }
    int maxelement(int[,] matrix)
    {
        int ii = -1, max = -1;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (ii < CountRowPositive(matrix, i))
            {
                ii = CountRowPositive(matrix, i);
                max = i;
            }
        }
        return max;
    }

    int CountColumnPositive(int[,] matrix, int columnIndex)
    {
        int count = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, columnIndex] > 0)
            {
                count++;
            }
        }
        return count;
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here

        // create and use SortArrayPart(array, startIndex);

        // end
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here
        int[] resultA = SumPositiveElementsInColumns(A);
        int[] resultC = SumPositiveElementsInColumns(C);

        int n = resultA.Length, m = resultC.Length;
        answer = new int[n + m];

        for (int i = 0; i < n; i++)
        {
            answer[i] = resultA[i];
        }

        for (int i = 0; i < m; i++)
        {
            answer[i + n] = resultC[i];
        }
        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }
    int[] SumPositiveElementsInColumns(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[] sums = new int[cols];

        for (int j = 0; j < cols; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, j] > 0)
                {
                    sums[j] += matrix[i, j];
                }
            }
        }

        return sums;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here

        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here
        int rowA, rowB, columnA, columnB;

        FindMaxIndex(A, out rowA, out columnA);
        FindMaxIndex(B, out rowB, out columnB);

        (A[rowA, columnA], B[rowB, columnB]) = (B[rowB, columnB], A[rowA, columnA]);
        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    
    public void Task_2_12(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxColumnIndex(matrix);

        // end
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here
        int maxrow, maxcolumn, minrow, mincolumn;

        FindMaxIndex(matrix, out maxrow, out maxcolumn);
        FindMinIndex(matrix, out minrow, out mincolumn);

        int max = Math.Max(maxrow, minrow), min = Math.Min(maxrow, minrow);
        RemoveRow(ref matrix, max);

        if (max != min)
        {
            RemoveRow(ref matrix, min);
        }
        // create and use RemoveRow(matrix, rowIndex);

        // end
    }
    void FindMinIndex(int[,] matrix, out int row, out int column)
    {
        int min = int.MaxValue;
        row = column = 0;
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    row = i;
                    column = j;
                }
            }
        }
    }
    public void RemoveRow(ref int[,] matrix, int row)
    {
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        int[,] answer = new int[n - 1, m];
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (i < row)
                {
                    answer[i, j] = matrix[i, j];
                }
                else
                {
                    answer[i, j] = matrix[i + 1, j];
                }
            }
        }
        matrix = answer;
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here

        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here
        double[] averages = new double[3];

        averages[0] = GetAverageWithoutMinMax(A);
        averages[1] = GetAverageWithoutMinMax(B);
        averages[2] = GetAverageWithoutMinMax(C);

        if (averages[0] > averages[1] && averages[0] > averages[2] && averages[1] > averages[2])
        {
            answer = -1;
        }
        else if (averages[0] < averages[1] && averages[0] < averages[2] && averages[1] < averages[2])
        {
             answer = 1;
        }
        else
        {
            answer = 0;
        }
        // create and use GetAverageWithoutMinMax(matrix);

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }
    static double GetAverageWithoutMinMax(int[,] matrix)
    {
        int rowCount = matrix.GetLength(0);
        int colCount = matrix.GetLength(1);

        int min = int.MaxValue;
        int max = int.MinValue;
        int sum = 0;
        int count = 0;

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                int value = matrix[i, j];
                sum += value;
                count++;

                if (value < min) min = value;
                if (value > max) max = value;
            }
        }

        double average = (sum - min - max) / (count - 2);
        return average;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);

        // end
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here
        SortRowsByMaxElement(A);
        SortRowsByMaxElement(B);
        // create and use SortRowsByMaxElement(matrix);

        // end
    }
    static void SortRowsByMaxElement(int[,] matrix)
    {
        int row = matrix.GetLength(0);
        int col = matrix.GetLength(1);

        for (int i = 0; i < row - 1; i++)
        {
            int max = i;
            for (int j = i + 1; j < row; j++)
            {
                int max1 = matrix[j, 0];
                int col1 = matrix.GetLength(1);

                for (int k = 1; k < col1; k++)
                {
                    if (matrix[j, k] > max1)
                    {
                        max1 = matrix[j, k];
                    }
                }
                int max2 = matrix[j, 0];
                int col2 = matrix.GetLength(1);

                for (int k = 1; k < col2; k++)
                {
                    if (matrix[max, k] > max2)
                    {
                        max2 = matrix[max, k];
                    }
                }
                if (max1 > max2)
                {
                    max = j;
                }
            }
            if (max != i)
            {
                int c = matrix.GetLength(1);
                for (int j = 0; j < c; j++)
                {
                    (matrix[i, j], matrix[max, j]) = (matrix[max, j], matrix[i, j]);
                }
            }
        }
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);

        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here
        int n = matrix.GetLength(0), m = matrix.GetLength(1);
        int[] m0 = new int[n];
        int f = 1;
        for (int i = 0; i < n; i++)
        {
            f = 1;
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] == 0)
                {
                    n--;
                    f = 0;
                    break;
                }
            }
            if (f == 1)
            {
                m0[i] = 1;
            }
        }
        for (int i = 0; i < m0.Length; i++)
        {
            if (m0[i] == 0)
            {
                RemoveRow(ref matrix, i);
            }
        }
        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here
        answerA = CreateArrayFromMins(A, answerA);
        answerB = CreateArrayFromMins(B, answerB);
        // create and use CreateArrayFromMins(matrix);

        // end
    }
    int[] CreateArrayFromMins(int[,] A, int[] answer)
    {
        int n = A.GetLength(0);
        answer = new int[n];
        for (int i = 0; i < n; i++)
        {
            int min = int.MaxValue;
            for (int j = i; j < n; j++)
            {
                if (min > A[i, j]) min = A[i, j];
            }
            answer[i] = min;
        }
        return answer;
    }
    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        // code here

        // create and use CountNegativeInRow(matrix, rowIndex);
        // create and use FindMaxNegativePerColumn(matrix);

        // end
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here
        MatrixValuesChange(A);
        MatrixValuesChange(B);
        // create and use MatrixValuesChange(matrix);

        // end
    }
    public void MatrixValuesChange(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        double[] answer = new double[n * m];
        int index = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                answer[index++] = matrix[i, j];
            }
        }

        for (int i = 0; i < n * m - 1; i++)
        {
            for (int j = 0; j < n * m - 1 - i; j++)
            {
                if (answer[j] < answer[j + 1])
                {
                    ( answer[j], answer[j + 1]) = (answer[j + 1], answer[j]);
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                double c = matrix[i, j];

                bool f = false;

                for (int ind = 0; ind < Math.Min(5, n * m); ind++)
                {
                    if (c == answer[ind])
                    {
                        matrix[i, j] = (c > 0) ? (c * 2) : (c / 2);
                        f = true;
                        break;
                    }
                }

                if (!f)
                {
                    matrix[i, j] = (c > 0) ? (c / 2) : (c * 2);
                }
            }
        }
    }
    public void Task_2_24(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here
        maxA = FindRowWithMaxNegativeCount(A);
        maxB = FindRowWithMaxNegativeCount(B);
        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }
    static int FindRowWithMaxNegativeCount(int[,] matrix)
    {
        int row = matrix.GetLength(0);
        int max = int.MinValue;
        int ind = -1;

        for (int i = 0; i < row; i++)
        {
            int neg = CountNegativeInRow(matrix, i);
            if (neg > max)
            {
                max = neg;
                ind = i;
            }
        }

        return ind;
    }

    static int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;
        int col = matrix.GetLength(1);

        for (int j = 0; j < col; j++)
        {
            if (matrix[rowIndex, j] < 0)
            {
                count++;
            }
        }

        return count;
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here
        RemoveReplace(ref A);
        RemoveReplace(ref B);

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }
    static void FindRowMaxIndex(int[,] matrix, int rowIndex, out int columnIndex)
    {
        int max = int.MinValue;
        columnIndex = -1;
        int colCount = matrix.GetLength(1);

        for (int j = 0; j < colCount; j++)
        {
            if (matrix[rowIndex, j] > max)
            {
                max = matrix[rowIndex, j];
                columnIndex = j;
            }
        }
    }
    public void ReplaceMaxElementOdd(ref int[,] matrix, int row, int column)
    {
        matrix[row, column] *= column + 1;
    }
    
    public void ReplaceMaxElementEven(ref int[,] matrix, int row, int column)
    {
        matrix[row, column] = 0;
    }

    public void RemoveReplace(ref int[,] matrix)
    {
        int row = matrix.GetLength(0);

        for (int i = 0; i < row; i++)
        {
            int columnIndex;
            FindRowMaxIndex(matrix, i, out columnIndex);

            if ((i + 1) % 2 == 0)
            {
                ReplaceMaxElementEven(ref matrix, i, columnIndex);
            }
            else
            {
                ReplaceMaxElementOdd(ref matrix, i, columnIndex);
            }
        }
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create and use FindSequence(array, A, B); // 1 - increasing, 0 - no sequence,  -1 - decreasing
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
        // A and B - start and end indexes of elements from array for search

        // end
    }

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

        // end
    }
    #endregion

    #region Level 3
    public delegate double SumFunction(int i, double x, ref int change);
    public delegate double YFunction(double x);
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        double a1 = 0.1, b1 = 1, h1 = 0.1;
        firstSumAndY = new double[(int)((b1 - a1) / h1) + 1, 2];
        GetSumAndY(s1Term, y3_1_1, a1, b1, h1, firstSumAndY);

        double a2 = Math.PI / 5, b2 = Math.PI, h2 = Math.PI / 25;
        secondSumAndY = new double[(int)((b2 - a2) / h2) + 1, 2];
        GetSumAndY(s2Term, y3_1_2, a2, b2, h2, secondSumAndY, 1);
        // create and use public delegate SumFunction(x, a, b, h) and public delegate YFunction(x, a, b, h)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions
        // end
    }
    public double s1Term(int i, double x, ref int iFactorial)
    {
        if (i > 0)
        {
            iFactorial *= i;
        }
        double n = Math.Cos(i * x) / iFactorial;
        return n;
    }
    public double s2Term(int i, double x, ref int sign)
    {
        sign *= -1;
        double n = sign * Math.Cos(i * x) / (i * i);
        return n;
    }
    public double y3_1_1(double x)
    {
        double n = Math.Exp(Math.Cos(x)) * Math.Cos(Math.Sin(x)); 
        return n;
    }
    public double y3_1_2(double x)
    {
        double n = ((x * x) - Math.PI * Math.PI / 3) / 4;
        return n;
    }
    public double CalculateSum(SumFunction sumFunction, double x, int i)
    {
        double e = 0.0001, sum = 0;
        int c = 1;
        double n = sumFunction(i, x, ref c);

        while (Math.Abs(n) > e)
        {
            sum += n;
            n = sumFunction(++i, x, ref c);
        }
        return sum;
    }
    public void GetSumAndY(SumFunction sFunction, YFunction yFunction, double a, double b, double h, double[,] SumAndY, int startI = 0)
    {
        for (int i = 0; i < (b - a) / h + 1; i++)
        {
            double x = a + i * h;

            double sum = CalculateSum(sFunction, x, startI);
            double y = yFunction(x);

            SumAndY[i, 0] = sum;
            SumAndY[i, 1] = y;
        }
    }
    public void Task_3_2(int[,] matrix)
    {
        // SortRowStyle sortStyle = default(SortRowStyle); - uncomment me

        // code here

        // create and use public delegate SortRowStyle(matrix, rowIndex);
        // create and use methods SortAscending(matrix, rowIndex) and SortDescending(matrix, rowIndex)
        // change method in variable sortStyle in the loop here and use it for row sorting

        // end
    }

    public delegate void SwapDirection(double[] array);

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        SwapDirection swapper = default(SwapDirection);
        double sum = CalculateSum(array);
        double avg = CalculateAverage(array, sum);

        swapper = array[0] > avg ? SwapLeft : SwapRight;

        swapper(array);

        answer = GetSum(array, 1, 2);
        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end

        return answer;
    }
    public static double CalculateAverage(double[] numbers, double sum)
    {
        return sum / numbers.Length;
    }

    public static void SwapLeft(double[] numbers)
    {
        for (int i = 0; i < numbers.Length - 1; i += 2)
        {
            (numbers[i], numbers[i + 1]) = (numbers[i + 1], numbers[i]);
        }
    }

    public static void SwapRight(double[] numbers)
    {
        for (int i = numbers.Length - 1; i > 0; i -= 2)
        {
            (numbers[i], numbers[i - 1]) = (numbers[i - 1], numbers[i]);
        }
    }

    public static double GetSum(double[] numbers, int start, int step)
    {
        double sum = 0;
        for (int i = start; i < numbers.Length; i += step)
        {
            sum += numbers[i];
        }
        return sum;
    }

    public static double CalculateSum(double[] numbers)
    {
        double sum = 0;
        foreach (var number in numbers)
        {
            sum += number;
        }
        return sum;
    }


    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        // end

        return answer;
    }

    public void Task_3_5(out int func1, out int func2)
    {
        // code here
        func1 = CountSignFlips(Function1, 0, 2, 0.1);
        func2 = CountSignFlips(Function2, -1, 1, 0.2);

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }
    public int CountSignFlips(YFunction YFunction, double a, double b, double h)
    {
        int Count = 0;

        for (double x = a + h; x <= b; x += h)
        {
            double n = YFunction(x - h), m = YFunction(x);
            if ((n > 0 && m < 0) || (n < 0 && m > 0) || (x == b)) Count++;
        }
        return Count;
    }
    public static double Function1(double x)
    {
        return x * x - Math.Sin(x);
    }

    public static double Function2(double x)
    {
        return Math.Exp(x) - 1;
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);

        // end
    }

    public delegate int CountPositive(int[,] matrix, int index);

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here
        CountPositive countRowPositive = CountRowPositive;
        CountPositive countColumnPositive = CountColumnPositive;

        int rowIndex = FindRowMaxPositive(B, countRowPositive);
        int colIndex = FindColumnMaxPositive(C, countColumnPositive);

        B = InsertColumn(B, rowIndex, C, colIndex);


        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }

    public static int FindRowMaxPositive(int[,] matrix, CountPositive countFunc)
    {
        int maxCount = 0;
        int rowIndex = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int count = countFunc(matrix, i);
            if (count > maxCount)
            {
                maxCount = count;
                rowIndex = i;
            }
        }

        return rowIndex;
    }

    public static int FindColumnMaxPositive(int[,] matrix, CountPositive countFunc)
    {
        int maxCount = 0;
        int colIndex = 0;

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int count = countFunc(matrix, j);
            if (count > maxCount)
            {
                maxCount = count;
                colIndex = j;
            }
        }

        return colIndex;
    }
    public static int[,] InsertColumn(int[,] matrixB, int rowIndex, int[,] matrixC, int colIndex)
    {
        int[,] resultMatrix = new int[5, 5];

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (i <= rowIndex)
                {
                    resultMatrix[i, j] = matrixB[i, j];
                }
                else if (i == rowIndex + 1)
                {
                    resultMatrix[i, j] = matrixC[j, colIndex];
                }
                else
                {
                    resultMatrix[i, j] = matrixB[i - 1, j];
                }
            }
        }

        return resultMatrix;
    }


    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me

        // code here

        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }

    public delegate void FindElementDelegate(int[,] matrix, out int foundI, out int foundJ);

    public void RemoveRows(ref int[,] matrix, FindElementDelegate findElementDelegate1, FindElementDelegate findElementDelegate2)
    {
        int i1 = 0, j1 = 0, i2 = 0, j2 = 0;
        findElementDelegate1(matrix, out i1, out j1);
        findElementDelegate2(matrix, out i2, out j2);

        RemoveRow(ref matrix, i1);

        if (i2 < i1)
        {
            RemoveRow(ref matrix, i2);
        }
        else if (i2 > i1)
        {
            RemoveRow(ref matrix, i2 - 1);
        }
    }

    public void Task_3_13(ref int[,] matrix)
    {
        // code here
        RemoveRows(ref matrix, FindMaxIndex, FindMinIndex);
        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }


    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }

    public delegate void ReplaceMaxElement(int[,] matrix, int i, out int col);
    public delegate void ReplaceMaxElement2(ref int[,] matrix, int i, int col);
    public void EvenOddRowsTransform(int[,] matrix, ReplaceMaxElement Find, ReplaceMaxElement2 replaceMaxElement1, ReplaceMaxElement2 replaceMaxElement2)
    {
        int col, n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            Find(matrix, i, out col);
            if ((i + 1) % 2 > 0)
            {
                replaceMaxElement1(ref matrix, i, col);
            }
            else
            {
                replaceMaxElement2(ref matrix, i, col);
            }
        }
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);
        EvenOddRowsTransform(A, FindRowMaxIndex, ReplaceMaxElementOdd, ReplaceMaxElementEven);
        EvenOddRowsTransform(B, FindRowMaxIndex, ReplaceMaxElementOdd, ReplaceMaxElementEven);

        // end
    }


    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here

        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    #endregion
    #region bonus part
    public delegate void MatrixConverter(double[,] matrix);

    public double[,] Task_4(double[,] matrix, int index)
    {

        // code here
        MatrixConverter[] mc = { ToUpperTriangular, ToLowerTriangular, ToLeftDiagonal, ToRightDiagonal };
        mc[index](matrix);
        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    public static void ToUpperTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int j = 0; j < n - 1; j++)
        {
            for (int k = j + 1; k < n; k++)
            {
                double p = matrix[k, j] / matrix[j, j];
                for (int m = j; m < n; m++)
                {
                    matrix[k, m] -= matrix[j, m] * p;
                }
            }
        }
    }

    public static void ToLowerTriangular(double[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int j = n - 1; j > 0; j--)
        {
            for (int k = j - 1; k >= 0; k--)
            {
                double p = matrix[k, j] / matrix[j, j];
                for (int m = j; m >= 0; m--)
                {
                    matrix[k, m] -= matrix[j, m] * p;
                }
            }
        }
    }
    public static void ToLeftDiagonal(double[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int j = 0; j < n - 1; j++)
        {
            for (int k = j + 1; k < n; k++)
            {
                double p = matrix[k, j] / matrix[j, j];
                for (int m = 0; m < n; m++)
                {
                    matrix[k, m] -= matrix[j, m] * p;
                }
            }
        }
    }

    public static void ToRightDiagonal(double[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int j = 0; j < n - 1; j++)
        {
            for (int k = n - 1 - j; k >= 0; k--)
            {
                double p = matrix[k, n - 1 - j] / matrix[n - 1 - j, n - 1 - j];
                for (int m = n - 1 - j; m < n; m++)
                {
                    matrix[k, m] -= matrix[n - 1 - j, m] * p;
                }
            }
        }
    }

    #endregion
}
