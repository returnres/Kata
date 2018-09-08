using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClassLibrary2
{

    public class Class1
    {
        [Fact]
        public void test()
        {
            int[] exampleTest1 = { 2, 6, 8, -10, 3 };
            Assert.True(3 == Kata.Find(exampleTest1));
        }
       
    }


    public class Kata
    {
        public static int Find(int[] integers)
        {
            List<int> pari = new List<int>();
            List<int> dispari = new List<int>();
            foreach (var item in integers)
            {
                if (item % 2 == 0)
                    pari.Add(item);

                if (item % 2 != 0)
                    dispari.Add(item);
            }

            if (pari.Count > dispari.Count)
                return dispari[0];
            if (dispari.Count > pari.Count)
                return pari[0];
            return -1;
        }

    }
}



