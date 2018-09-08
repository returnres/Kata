using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

 

namespace ClassLibrary1
{

    public class Class1
    {
        readonly decimal[] _discountRates = { 1, 0.95m, 0.90m, 0.80m, 0.75m };

        #region test1
        [Fact]
        public void unacoppiareturnnodiff()
        {
            string[] books = new[] { "1", "1" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diff = basketCalculator.GetDifferrentBooks();
            Assert.True(diff  == 0);
        }
        [Fact]
        public void cinqueugualireturnnodiff()
        {
            string[] books = new[] { "1", "1", "1", "1", "1" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diff = basketCalculator.GetDifferrentBooks();
            Assert.True(diff == 0);
        }

        [Fact]
        public void duediversereturn1diff()
        {
            string[] books = new[] { "1", "2" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diff = basketCalculator.GetDifferrentBooks();
            Assert.True(diff - basketCalculator.GetCoppieUguali() == 2);
        }

        [Fact]
        public void trediversereturn3diff()
        {
            string[] books = new[] { "1", "2", "3" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diff = basketCalculator.GetDifferrentBooks();
            Assert.True(diff - basketCalculator.GetCoppieUguali() == 3);
        }

       

        [Fact]
        public void quattrodiversereturn4diff()
        {
            string[] books = new[] { "1", "2", "3","4" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diff = basketCalculator.GetDifferrentBooks();
            Assert.True(diff - basketCalculator.GetCoppieUguali() == 4);
        }

       


        [Fact]
        public void cinquediversereturn5diff()
        {
            string[] books = new[] { "1", "2", "3","4","5" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diff = basketCalculator.GetDifferrentBooks();
            Assert.True(diff- basketCalculator.GetCoppieUguali() == 5);
        }

        [Fact]
        public void test()
        {
            string[] books = new[] { "1", "2", "3", "3" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diff = basketCalculator.GetDifferrentBooks();
            Assert.True(diff- basketCalculator.GetCoppieUguali() == 3);
        }

        [Fact]
        public void test1()
        {
            string[] books = new[] { "1", "2", "3", "3" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var coppieuguali = basketCalculator.GetCoppieUguali();
            Assert.True(coppieuguali == 1);
        }

        [Fact]
        public void test4()
        {
            string[] books = new[] { "1", "2", "3", "4", "5", "6", "6", "1" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diverse = basketCalculator.GetDifferrentBooks();
            var res = books.Length - diverse;
            Assert.True(0 == res);
        }


        [Fact]
        public void test2()
        {
            string[] books = new[] { "1", "1", "2", "2","3","3","4","5" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diverse = basketCalculator.GetDifferrentBooks();
            var res = books.Length - diverse;
            Assert.True(0 == res);
        }


        [Fact]
        public void test8()
        {
            string[] books = new[] { "1", "1" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diverse = basketCalculator.GetDifferrentBooks();
            var res = basketCalculator.LibriDaScontare(diverse, 0);
            Assert.True(res["nonscontare"] == 1);
        }
     

        [Fact]
        public void test6()
        {
            string[] books = new[] { "1", "2"};
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diverse = basketCalculator.GetDifferrentBooks();
            var res = basketCalculator.LibriDaScontare(diverse,0);
            Assert.True(res["scontare"] == 2);
        }

        [Fact]
        public void test7()
        {
            string[] books = new[] { "1", "2", "3", "4", "5" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diverse = basketCalculator.GetDifferrentBooks();
            var res = basketCalculator.LibriDaScontare(diverse, 0);
            Assert.True(res["scontare"] == 5);
        }
        [Fact]
        public void test10()
        {
            string[] books = new[] { "1", "1", "2" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diverse = basketCalculator.GetDifferrentBooks();
            Assert.True(diverse- basketCalculator.GetCoppieUguali() == 2);
        }
        #endregion

        [Fact]
        public void test99()
        {
            string[] books = new[] { "1", "2", "3" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diverse = basketCalculator.GetDifferrentBooks();
            var res = basketCalculator.LibriDaScontare(diverse, basketCalculator.GetCoppieUguali());
            Assert.True(res["nonscontare"] == 0);
            Assert.True(res["scontare"] == 3);
        }

        [Fact]
        public void test9()
        {
            string[] books = { "1", "1", "2" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diverse = basketCalculator.GetDifferrentBooks();
            var res = basketCalculator.LibriDaScontare(diverse, basketCalculator.GetCoppieUguali());
            Assert.True(res["nonscontare"] == 1);
            Assert.True(res["scontare"] == 2);
        }

        [Fact]
        public void test11()
        {
            string[] books = new[] { "1", "1", "2", "2" };
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diverse = basketCalculator.GetDifferrentBooks();
            var res = basketCalculator.LibriDaScontare(diverse , basketCalculator.GetCoppieUguali());
            Assert.True(res["scontare"] == 4);
            Assert.True(res["nonscontare"] == 0);
        }

        [Fact]
        public void testfinale()
        {
            string[] books = new[] { "1", "1", "2", "2","3","3","4","5"};
            BasketCalculator basketCalculator = new BasketCalculator(books);
            var diverse = basketCalculator.GetDifferrentBooks();
            var res = basketCalculator.LibriDaScontare(diverse, basketCalculator.GetCoppieUguali());
            Assert.True(res["scontare"] == 8);
            Assert.True(res["nonscontare"] == 0);
        }
    }
   
    public class BasketCalculator
    {
        private string[] _books;
        public BasketCalculator(params string[] books)
        {
            this._books = books;
        }

        public Dictionary<string, int> LibriDaScontare(int diff, int uguali)
        {
            Dictionary<string, int> disc = new Dictionary<string, int>();
            disc.Add("nonscontare",0);
            disc.Add("scontare", 0);
            
            int dascontare = 0;
            if (diff > 0)
                 dascontare = diff - uguali;

            //solo sconti
            bool solosconto = false;
            if (dascontare > 0 && diff == _books.Length )
            {
                disc["scontare"] = diff;
                solosconto = true;
            }

            //nosconti
            if (dascontare == 0)
                disc["nonscontare"]++;

            //sconti e non 
            if (dascontare > 0 && _books.Length > dascontare && solosconto == false)
            {
                disc["scontare"]= dascontare;

                if (uguali % 2 == 0)
                {
                    disc["nonscontare"] = uguali / 2;
                }
                else
                {
                    disc["nonscontare"] = uguali;
                }

            }
            return disc;
        }


        public int GetCoppieUguali()
        {
            int same = 0;
            string temp = "";
            foreach (var book in _books)
            {
                if (book == temp)
                {
                    same++;
                }

                temp = book;
            }

            return same;
        }

        public int GetDifferrentBooks()
        {
            int different = 0;
            foreach (var book in _books)
            {
                foreach (var currbook in _books)
                {
                    if (book != currbook)
                    {
                        different++;
                        break;
                    }
                }
            }
            return different;
        }
    }

}