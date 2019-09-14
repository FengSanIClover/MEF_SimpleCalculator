using System;
using System.Collections.Generic;
using System.Text;

namespace MEF_SimpleCalculator
{
    /// <summary>
    /// 運算符號介面(作為中繼資料用)
    /// </summary>
    public interface ICalcSymbol
    {
        /// <summary>
        /// 運算符號
        /// </summary>
        string Symbol { get; }
    }
}
