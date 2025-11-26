using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class MikeModel
    {
        public int Id {  get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string UnitName {  get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal VatPercent { get; set; }
        public decimal VatSum { get; set; }
        public decimal Sum { get; set; }

        public MikeModel() { }

        public List<MikeModel> Load()
        {
            List<MikeModel> list = new List<MikeModel>();
            Random  random = new Random();


            for(int i = 0; i<100; i++)
            {
                MikeModel model = new MikeModel()
                {
                    Id = i,
                    ProductName = "Товар " + i.ToString(),
                    UnitName = "шт.",
                    Qty = random.Next(10, 100),
                    Price = random.Next(100000, 300000),
                    VatPercent = 12
                };
                model.Amount = model.Qty * model.Price;
                model.VatSum = model.Amount * model.VatPercent / 100;
                model.Sum = model.Amount + model.VatSum;


                list.Add(model);
            }


            return list;

        }
    }
}
