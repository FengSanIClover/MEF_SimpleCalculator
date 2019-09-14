1.安裝 NuGet 套件 System.ComponentModel.Composition

2.新增 計算器介面(ICalculator) 與實作類別(Calculator)

3.在 Program.cs 加入 組合容器 欄位屬性，並於建構子內 建立目錄(catelog)與組件(parts)，建立組合容器

4.建立指定合約類型(ContractType)的匯出與匯入的 Attribute 

5.建立 運算邏輯(ICalcLogic)、運算符號(ICalcSymbol)介面，實作加法運算的類別(CalculateAdd)

6.使用 ImportMany 的 Attribute 並實作 Calculator 的運算方法

7.新增 減(CalculateSub)、乘(CalculateMultiplication)、除(CalculateDivision) 計算邏輯類別實作

8.新增 MEF_Interfaces、MEF_Services 類別庫專案，
  並在 MEF_Services 安裝 NuGet 套件 System.ComponentModel.Composition

9.將 介面移入 MEF_Interfaces ， 實作類別移入 MEF_Services，
  修改 Program.cs 建構子，將原本 AssemblyCatalog 改為使用 DirectoryCatalog，並寫入組件路徑與篩選條件
