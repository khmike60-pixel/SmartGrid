using SmartGrid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MyModel : ITreeData
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public int IsLeaf { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }
        public decimal Decimal { get; set; }
        public decimal Double { get; set; }
        public string String1 { get; set; }
        public string String2 { get; set; }
        public DateTime Date { get; set; }

        public MyModel() { }

        public ObservableCollection<MyModel> GetData()
        {
            return new ObservableCollection<MyModel>()
            {
                new MyModel() { Id = 1, ParentId = 0, Name = "Узел", Number = 1000, Decimal = 1000.0000M, Double = 1000.00M, String1 = "Тест1", String2 = "Test2", Date = DateTime.Now.AddDays(1) },
                new MyModel() { Id = 2, ParentId = 1, Name = "Потомок_1", Number = 30000, Decimal = 30000.0000M, Double = 30000.00M, String1 = "Тест5", String2 = "Test6", Date = DateTime.Now.AddDays(3) },
                new MyModel() { Id = 3, ParentId = 1, Name = "Потомок_2", Number = 2000000, Decimal = 2000000.0000M, Double = 2000000.00M, String1 = "Тест3", String2 = "Test4", Date = DateTime.Now.AddDays(2) }
            };
        }

        public IEnumerable<MyModel> GetTreeData()
        {
            var list = new List<MyModel>()
            {
                new MyModel() { Id = 1, ParentId = 0, IsLeaf = 0, Name = "Узел1", Number = 1000, Decimal = 1000.0000M, Double = 1000.00M, String1 = "Тест1", String2 = "Test2", Date = DateTime.Now.AddDays(1) },
                new MyModel() { Id = 2, ParentId = 1, IsLeaf = 1, Name = "Потомок_1", Number = 30000, Decimal = 30000.0000M, Double = 30000.00M, String1 = "Тест5", String2 = "Test6", Date = DateTime.Now.AddDays(3) },
                new MyModel() { Id = 3, ParentId = 1, IsLeaf = 1, Name = "Потомок_2", Number = 2000000, Decimal = 2000000.0000M, Double = 2000000.00M, String1 = "Тест3", String2 = "Test4", Date = DateTime.Now.AddDays(2) },
                new MyModel() { Id = 4, ParentId = 0, IsLeaf = 0, Name = "Узел2", Number = 1000, Decimal = 1000.0000M, Double = 1000.00M, String1 = "Тест1", String2 = "Test2", Date = DateTime.Now.AddDays(1) },
                new MyModel() { Id = 5, ParentId = 4, IsLeaf = 1, Name = "Потомок_3", Number = 30000, Decimal = 30000.0000M, Double = 30000.00M, String1 = "Тест5", String2 = "Test6", Date = DateTime.Now.AddDays(3) },
                new MyModel() { Id = 6, ParentId = 4, IsLeaf = 1, Name = "Потомок_4", Number = 2000000, Decimal = 2000000.0000M, Double = 2000000.00M, String1 = "Тест3", String2 = "Test4", Date = DateTime.Now.AddDays(2) }
            };

            return list.AsEnumerable().Select(m => m);

        }
    }
}
