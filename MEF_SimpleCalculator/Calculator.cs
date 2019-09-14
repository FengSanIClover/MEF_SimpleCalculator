using System;
using System.Collections.Generic;
using System.Text;
// 引用名稱空間
using System.ComponentModel.Composition;

namespace MEF_SimpleCalculator
{
    /// <summary>
    /// 計算機的實作類別
    /// </summary>
    [Export(typeof(ICalculator))] // 指定匯出(契約類型為 ICalculator)
    public class Calculator : ICalculator
    {
        /// <summary>
        /// 匯入運算邏輯與運算符號
        /// </summary>
        /// <remarks>
        /// 除了匯出的物件本身之外，也會取得 匯出中繼資料 或描述所匯出物件的資訊
        /// </remarks>
        /// <remarks>
        /// Lazy<T,TMetadata>
        /// </remarks>
        [ImportMany]
        private IEnumerable<Lazy<ICalcLogic, ICalcSymbol>> calculates;

        /// <summary>
        /// 計算機方法
        /// </summary>
        /// <param name="inputStr">輸入的計算式</param>
        /// <returns></returns>
        public string Calculate(string inputStr)
        {
            // 取得運算符號的位置
            var symbolIndex = this.GetSymbolIndex(inputStr);
            if (symbolIndex < 0)
                return "輸入錯誤，請重新輸入!!";

            int left; // 運算符號左邊數字
            int right; // 運算符號右邊數字

            try
            {
                // 取得 運算符號左右邊數字
                left = int.Parse(inputStr.Substring(0, symbolIndex));
                right = int.Parse(inputStr.Substring(symbolIndex + 1));
            }
            catch
            {
                return "輸入錯誤，請重新輸入!!";
            }

            // 運算符號
            string symbol = inputStr[symbolIndex].ToString();

            // 讀取匯入的運算邏輯與運算符號，執行運算
            foreach (Lazy<ICalcLogic, ICalcSymbol> calculate in calculates)
            {
                // 在 foreach 迴圈中，會檢查 operations 集合的每個成員。 
                // 分別可以使用 Metadata 屬性和 Value 屬性來存取它們的中繼資料值和所匯出的物件。 
                if (calculate.Metadata.Symbol.Equals(symbol))
                    return calculate.Value.Calculate(left, right).ToString();
            }

            return "此計算機無此運算方法";
        }

        /// <summary>
        /// 取得運算符號的位置
        /// </summary>
        /// <param name="inputStr">輸入的計算</param>
        /// <returns></returns>
        private int GetSymbolIndex(string inputStr)
        {
            for (int i = 0; i < inputStr.Length; i += 1)
            {
                // 判斷為非數值的位置，就是運算符號位置
                if (!char.IsDigit(inputStr[i]))
                    return i;
            }

            return -1;
        }
    }
}
