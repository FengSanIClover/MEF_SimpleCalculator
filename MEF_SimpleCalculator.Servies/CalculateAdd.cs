using System;
using System.Collections.Generic;
using System.Text;
// 引用名稱空間
using System.ComponentModel.Composition;

namespace MEF_SimpleCalculator
{
    /// <summary>
    /// 加法邏輯的實作類別
    /// </summary>
    [Export(typeof(ICalcLogic))]
    [ExportMetadata("Symbol", "+")] // 會將中繼資料 (以名稱/值組的形式) 附加至該匯出。
    public class CalculateAdd : ICalcLogic
    {
        /// <summary>
        /// 加法運算
        /// </summary>
        /// <param name="left">計算符號左邊的數字</param>
        /// <param name="right">計算符號右邊的數字</param>
        /// <returns></returns>
        public int Calculate(int left, int right)
        {
            return left + right;
        }
    }
}
