using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace MEF_SimpleCalculator
{
    /// <summary>
    /// 減法邏輯的實作類別
    /// </summary>
    [Export(typeof(ICalcLogic))]
    [ExportMetadata("Symbol", "-")]
    public class CalculateSub : ICalcLogic
    {
        /// <summary>
        /// 減法運算
        /// </summary>
        /// <param name="left">計算符號左邊的數字</param>
        /// <param name="right">計算符號右邊的數字</param>
        /// <returns></returns>
        public int Calculate(int left, int right)
        {
            return left - right;
        }
    }
}
