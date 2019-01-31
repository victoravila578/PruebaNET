using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    public class UT_Algoritmos123
    {
        #region ChangeString 
        [Fact]
        public void SimpleTest()
        {
            string result = ChangeString.ChangeString.Build("abc");
            Assert.Equal("bcd", result.ToString());
        }
        [Fact]
        public void ComplexTest()
        {
            string result = ChangeString.ChangeString.Build("NariZ/ ñaTa/22/o°");
            Assert.Equal("ÑbsjA/ obUb/22/p°", result.ToString());
        }
        #endregion

        #region OrderRange 
        [Fact]
        public void SuccessfulTest()
        {
            int[] arrMyValues = new int[] { 1, 5, 100, 79, 23, 56 };
            List<int> lstInt = new List<int>(arrMyValues);
            string result = OrderRange.OrderRange.Build(lstInt);
            Assert.Equal("[1,5,23,79][56,100]", result);
        }
        #endregion

        #region MoneyParts 
        [Fact]
        public void ValidarExisteValores()
        {
            double[] denominaciones = { 1, 2 };
            double[] contador = new double[denominaciones.Length];
            int monto = 2;
            var lstCombinaciones = new List<List<double>>();

            var lst = new List<List<double>>();
            lst = MoneyParts.MoneyParts.Build(denominaciones, contador, 0, monto, lstCombinaciones);
            //Resultado:
            //1:[1,1]
            //2:[2]
            Assert.Equal(2,lst.Count());
        }
        #endregion

    }
}

