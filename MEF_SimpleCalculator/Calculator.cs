using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace MEF_SimpleCalculator
{
    /// <summary>
    /// 計算機的實作類別
    /// </summary>
    [Export(typeof(ICalculator))] // 指定匯出(契約類型為 ICalculator)
    public class Calculator : ICalculator
    {
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

            switch (symbol)
            {
                case "+":
                    return $"{left + right}";
                case "-":
                    return $"{left - right}";
                case "*":
                    return $"{left * right}";
                case "/":
                    return $"{left / right}";
                default:
                    return "此計算機無此運算方法";
            }
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
