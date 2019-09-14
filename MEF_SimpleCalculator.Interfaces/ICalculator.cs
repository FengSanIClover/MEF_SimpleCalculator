using System;
using System.Collections.Generic;
using System.Text;

namespace MEF_SimpleCalculator
{
    /// <summary>
    /// 計算機介面
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// 計算機方法
        /// </summary>
        /// <param name="inputStr">輸入的計算</param>
        /// <returns></returns>
        string Calculate(string inputStr);
    }
}
