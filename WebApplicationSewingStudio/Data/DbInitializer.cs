using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationSewingStudio.Models;

namespace WebApplicationSewingStudio.Data
{
    public class DbInitializer
    {
        public static void Initialize(SewingStudioContext db)
        {
            db.Database.EnsureCreated();

            if (db.Materials.Any()) { return; }

            int materialsNumber = 100;
            int productsNumber = 100;
            int productCompositionNumber = 1000;
            int supplyNumber = 1000;
            int employersNumber = 300;
            int ordersNumber = 1000;
            string voc = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            Random random = new Random(1);

            for(int id = 1; id <= materialsNumber; id++)
            {
                db.Materials.Add(
                    new Material
                    {
                        Name = GenRandomString(voc,10),
                        Type = GenRandomString(voc,10)
                    } );
            }

            db.SaveChanges();

            for (int id = 1; id <= productsNumber; id++)
            {
                db.Products.Add(
                    new Product
                    {
                        Name = GenRandomString(voc, 10),
                        Price = random.Next(10,1000)
                    });
            }

            db.SaveChanges();

            for (int id = 1; id <= productCompositionNumber; id++)
            {
                db.ProductCompositions.Add(
                    new ProductComposition
                    {
                        MaterialId = random.Next(1,materialsNumber-1),
                        ProductId = random.Next(1,productsNumber-1),
                        Quantity = random.Next(10,1000)
                    });
            }
            db.SaveChanges();

            for (int id = 1; id <= supplyNumber; id++)
            {
                db.Supplies.Add(
                    new Supply
                    {
                        MaterialId = random.Next(1, materialsNumber - 1),
                        Price = random.Next(10, 1000),
                        Quantity = random.Next(10, 1000),
                        Supplier = GenRandomString(voc,10),
                        Delivery_date = DateTime.Now.Date.AddDays(-id)
                    });
            }
            db.SaveChanges();

            for (int id = 1; id <= ordersNumber; id++)
            {
                db.Orders.Add(
                    new Order
                    {
                        ProductId = random.Next(1,productsNumber-1),
                        Price = random.Next(10, 1000),
                        Quantity = random.Next(10, 1000),
                        Date_of_order = DateTime.Now.Date.AddDays(-id),
                        Date_of_sale = DateTime.Now.Date.AddDays(30)
                    });
            }
            db.SaveChanges();

            for (int id = 1; id <= employersNumber; id++)
            {
                db.Employees.Add(
                    new Employee
                    {
                        Name = GenRandomString(voc,10),
                        Surname = GenRandomString(voc, 15),
                        Patronymic = GenRandomString(voc, 15),
                        OrderId = random.Next(1,ordersNumber-1),
                        Date_of_delivery = DateTime.Now.Date.AddDays(30),
                        Execution_start_date = DateTime.Now.Date.AddDays(-id)
                    });
            }
            db.SaveChanges();

        }
        static string GenRandomString(string Alphabet, int Length)
        {
            Random rnd = new Random();
            //объект StringBuilder с заранее заданным размером буфера под результирующую строку
            StringBuilder sb = new StringBuilder(Length - 1);
            //переменную для хранения случайной позиции символа из строки Alphabet
            int Position = 0;
            string ret = "";
            for (int i = 0; i < Length; i++)
            {
                //получаем случайное число от 0 до последнего
                //символа в строке Alphabet
                Position = rnd.Next(0, Alphabet.Length - 1);
                //добавляем выбранный символ в объект
                //StringBuilder
                ret = ret + Alphabet[Position];
            }
            return ret;
        }
    }
}
