using System;
using System.Collections.Generic;
using System.Text;

namespace MEF_SimpleCalculator
{
    /// <summary>
    /// 計算機的實作類別
    /// </summary>
    public class Calculator : ICalculator
    {
        /// <summary>
        /// 計算機方法
        /// </summary>
        /// <param name="inputStr">輸入的計算式</param>
        /// <returns></returns>
        public string Calculate(string inputStr)
        {
            return $"輸入的計算式:{inputStr}";
        }
    }
}
