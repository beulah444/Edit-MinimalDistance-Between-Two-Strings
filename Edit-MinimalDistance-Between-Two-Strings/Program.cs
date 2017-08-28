using System;

class Program
 {
        static void Main()
        {
        string strl = "saturday";
        string str2 = "sunday";
        Console.WriteLine("time complexity is exponential O(3 powerr m) with "
            +editDistanceStrings(strl, str2, strl.Length, str2.Length) +" operations required");
        Console.WriteLine("using Recursive time complexity exponential O(m x n) with "
            + Recursive_editDistanceStrings(strl, str2, strl.Length, str2.Length) + " operations required");
        Console.ReadKey();
        }
    static int min(int x,int y,int z)
    {
        if (x > y && x < z) return x;
        else if (y < x && y < z) return y;
        else return z;
    }
    static int editDistanceStrings(string str1,string str2,int m,int n)
    {
        //create table to store results of sunproblems
        int[,] dp = new int[m + 1, n + 1];
        //fill the 2D array with bottom up manner
        for(int i=0;i<=m;i++)
        {
            for(int j=0;j<=n; j++)
            {
                //If 1st string is empty only option is to insert all the characters of 2nd string
                if (i == 0)
                    dp[i, j] = j; //Min.operations=j
                //If 2st string is empty only option is to insert all the characters of 1nd string
                else if (j == 0)
                    dp[i, j] = i; //Min.operations=i
                //If last characters are same then ignore last char and recur for remaining string
                else if (str1[i - 1] == str2[j - 1])
                    dp[i, j] = dp[i - 1, j - 1];
                //If last characters are different ,consider all the possibilities and find minimum
                else
                    dp[i, j] = 1 + min(dp[i, j - 1],   //Insert
                                       dp[i - 1, j],   //Remove
                                       dp[i - 1, j - 1]); //Replace
            }
        }
        return dp[m, n];
    }

    static int Recursive_editDistanceStrings(string str1, string str2, int m, int n)
    {

        //If 1st string is empty only option is to insert all the characters of 2nd string
        if (m == 0)
            return n; 
       //If 2st string is empty only option is to insert all the characters of 1nd string
        if (n == 0)
            return m; 
       //If last characters are same then ignore last char and recur for remaining string
        if (str1[m - 1] == str2[n - 1])
            return Recursive_editDistanceStrings(str1, str2, m - 1, n - 1);
        //If last characters are different ,consider all the possibilities 
        //and compute minimum cost of 3 operations and take minimum of 3 values
        else
            return 1 + min(Recursive_editDistanceStrings(str1,str2,m,n-1),   //Insert
                              Recursive_editDistanceStrings(str1, str2, m-1, n),   //Remove
                             Recursive_editDistanceStrings(str1, str2, m-1, n - 1)); //Replace
            
        
        
    }
}

