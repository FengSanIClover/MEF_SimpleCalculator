using System;
// 引用名稱空間
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEF_SimpleCalculator
{
    class Program
    {
        // 組合容器
        private CompositionContainer compositionContainer;

        private Program()
        {
            // 建立目錄集合
            var aggregateCatalog = new AggregateCatalog();

            // 將此類別內的組件加入目錄內
            aggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));

            // 將包含所有 組件 的 目錄 建立 組合容器
            this.compositionContainer = new CompositionContainer(aggregateCatalog);

            try
            {
                // 告知組合容器撰寫一組特定的組件，在此情況下是目前的 Program 執行個體。
                this.compositionContainer.ComposeParts(this);
            }
            catch (CompositionException ex)
            {
                Console.WriteLine($"ErrorMessage:{ex}");
            }
        }

        [Import(typeof(ICalculator))] // 指定匯入(契約類型為 ICalculator)
        public ICalculator calculator { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("MEF_SimpleCalculator");

            Console.WriteLine("Input Example:1+1");
            var program = new Program();

            while (true)
            {
                Console.Write("Input:");

                // 輸入值
                var inputStr = Console.ReadLine();

                // 顯示計算結果
                Console.WriteLine($"計算結果:{ program.calculator.Calculate(inputStr)}");
            }
        }
    }
}
