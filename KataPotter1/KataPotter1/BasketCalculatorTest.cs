using System;
using Xunit;

namespace KataPotter1
{
    public class BasketCalculatorTest
    {
        #region GetDiscountedType
        [Fact]
        public void GetDiscountedType()
        {
            string[] basket = new[] { "1", "1", "2" };
            BasketCalculator basketCalculator = new BasketCalculator(basket);
            var discountedType = basketCalculator.GetDiscountedType();
            Assert.True(discountedType[0] == 1);
        }

        [Fact]
        public void GetDiscountedType1()
        {
            string[] basket = new[] { "1", "1", "2", "2" };
            BasketCalculator basketCalculator = new BasketCalculator(basket);
            var discountedType = basketCalculator.GetDiscountedType();
            Assert.True(discountedType[0] == 2);
        }

        [Fact]
        public void GetDiscountedType2()
        {
            string[] basket = new[] { "1", "1", "2", "2", "3", "3", "4", "5" };
            BasketCalculator basketCalculator = new BasketCalculator(basket);
            var discountedType = basketCalculator.GetDiscountedType();
            Assert.True(discountedType[2] == 2);
        }

        #endregion

        #region GetFinalAmount

        [Fact]
        public void GetFinalAmount0()
        {
            string[] basket = new[] { "1", "1", "1"};
            BasketCalculator basketCalculator = new BasketCalculator(basket);
            var finalAmount = basketCalculator.GetFinalAmount();
            Assert.True(finalAmount == 24.0m);
        }

        [Fact]
        public void GetFinalAmount2()
        {
            string[] basket = new[] { "1", "1", "2" };
            BasketCalculator basketCalculator = new BasketCalculator(basket);
            var finalAmount = basketCalculator.GetFinalAmount();
            Assert.True(finalAmount == 23.2m);
        }

        [Fact]
        public void GetFinalAmount()
        {
            string[] basket = new[] { "1", "1", "2", "2" };
            BasketCalculator basketCalculator = new BasketCalculator(basket);
            var finalAmount = basketCalculator.GetFinalAmount();
            Assert.True(finalAmount == 30.40m);
        }

        [Fact]
        public void GetFinalAmount1()
        {
            string[] basket = new[] { "1", "1", "2", "2", "3", "3", "4", "5" };
            BasketCalculator basketCalculator = new BasketCalculator(basket);
            var finalAmount = basketCalculator.GetFinalAmount();
            Assert.True(finalAmount == 51.20m);
        }

        #endregion

        public class BasketCalculator
        {
            readonly decimal[] _discountRates = { 1, 0.95m, 0.90m, 0.80m, 0.75m };
            private readonly string[] _basket;
            public BasketCalculator(params string[] basket)
            {
                this._basket = basket;
            }

            public decimal GetFinalAmount()
            {
                decimal res = 0;
                var type = GetDiscountedType();
                if (!Array.Exists(type, x => x >0))
                    return _basket.Length *8;

                res = res + (type[0] * 2) * 8 * _discountRates[1];
                res = res + (type[1] * 3) * 8 * _discountRates[2];
                res = res + (type[2] * 4) * 8 * _discountRates[3];
                res = res + (type[3] * 5) * 8 * _discountRates[4];

                int fullpricebook = _basket.Length - CountTotDiff(type);

                return res+(fullpricebook*8);
            }

            public int[] GetDiscountedType()
            {
                int[] res = new int[4];
                int[] booksCheck = new int[_basket.Length];

                for (int i = 0; i < _basket.Length; i++)
                {
                    int previousI = i;
                    if (booksCheck[i] == 0)
                    {
                        booksCheck[i] = 1;
                        int temp = 0;

                        for (int j = 1; j < _basket.Length; j++)
                        {
                            if (_basket[i] != _basket[j] && booksCheck[j] == 0)
                            {
                                booksCheck[j] = 1;
                                i = j;
                                temp++;
                            }
                        }
                        if ((temp + 1) == 2)
                            res[0] = res[0] + 1;
                        if ((temp + 1) == 3)
                            res[1] = res[1] + 1;
                        if ((temp + 1) == 4)
                            res[2] = res[2] + 1;
                        if ((temp + 1) == 5)
                            res[3] = res[3] + 1;
                    }
                    i = previousI;
                }
                Optimization(res);
                return res;
            }

            private void  Optimization(int[] res)
            {
                int totDiff = CountTotDiff(res);
                if (totDiff > 4 && totDiff % 4 == 0)
                {
                    Array.Clear(res, 0, 4);
                    res[2] = totDiff / 4;
                }
            }

            private  int CountTotDiff(int[] res)
            {
                int totDiff = 0;
                for (int i = 0; i < res.Length; i++)
                {
                    if (i == 0 && res[0] > 0)
                        totDiff = totDiff + (res[i] * 2);
                    if (i == 1 && res[1] > 0)
                        totDiff = totDiff + (res[i] * 3);
                    if (i == 2 && res[2] > 0)
                        totDiff = totDiff + (res[i] * 4);
                    if (i == 3 && res[3] > 0)
                        totDiff = totDiff + (res[i] * 5);
                }

                return totDiff;
            }
        }
    }
}