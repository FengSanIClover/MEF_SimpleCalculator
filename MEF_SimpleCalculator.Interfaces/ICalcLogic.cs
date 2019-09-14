using System;
using System.Collections.Generic;
using System.Text;

namespace MEF_SimpleCalculator
{
    /// <summary>
    /// 運算邏輯介面
    /// </summary>
    public interface ICalcLogic
    {
        /// <summary>
        /// 運算方法
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        int Calculate(int left, int right);
    }
}
