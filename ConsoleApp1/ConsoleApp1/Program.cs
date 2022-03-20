using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            // option i
            Expression<Func<int, int>> expression1 = x => x * 2;

            // option ii
            Expression<Func<int, int>> expression2 = x => { return x * 2; };

            // option iii
            Expression<Func<int, int>> expression3 = x => x * (Int32.Parse("2"));

            // option iv
            Expression<Func<int, int>> expression4 = x => x * (() => Int32.Parse("2"));
        }
    }
}
