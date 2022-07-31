using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplicationBlog.Models
{
    public class MainInitializer : DropCreateDatabaseAlways<MainContext>
    {
        protected override void Seed(MainContext db)
        {
            var carlistNum = 100;
            var carCategoryNum = 6; //kategori item miktarları
            //var carSupplierNum = 5; //tedarikçi sayısı



            //List<CarSupplier> carSuppliersListAdd = new List<CarSupplier>() { };

            //for (int i = 1; i < carSupplierNum; i++)
            //{
            //    carSuppliersListAdd.Add(new CarSupplier { SupplierName = $"Tedarikci{i}" });
            //}

            //foreach (var item in carSuppliersListAdd)
            //{
            //    db.CarSuppliers.Add(item);
            //}
            //db.SaveChanges();

            List<CarCategory> carCategoryList = new List<CarCategory>() { };

            for (int i = 1; i < carCategoryNum; i++)
            {
                var generatedCarCategoriItem = new CarCategory() { CategoryName = $"kategori{i}" };
                carCategoryList.Add(generatedCarCategoriItem);
            }
            foreach (var item in carCategoryList)
            {
                db.CarCategories.Add(item);
            }
            db.SaveChanges();

            string[] rndCarBrand = { "ferrari", "lamborghini", "maserati", "mercedes", "ford", "mazda", };
            string[] rndCarUnicIdLetter = { "A", "B", "C", "D", "E" };
            string[] rndCarColor = { "red", "green", "blue", "yellow", "black", "gray", "white" };
            string[] rndCarPicture = { "1.jpg", "2.jpg", "3.jpg", "4.jpg" };
            bool[] rndCarState = { true, false };

            List<CarList> carLists = new List<CarList>() { };
            var rndnum = new Random();

            for (int i = 0; i < carlistNum; i++)
            {
                CarList generatedCarItem = new CarList()
                {
                    CarBrand = rndCarBrand[rndnum.Next(rndCarBrand.Count())],
                    CarUnicId = (rndCarUnicIdLetter[rndnum.Next(rndCarUnicIdLetter.Count())]) + (rndCarUnicIdLetter[rndnum.Next(rndCarUnicIdLetter.Count())]) + rndnum.Next().ToString(),
                    ModelYear = rndnum.Next(1970, 2022).ToString(),
                    CarColor = rndCarColor[rndnum.Next(rndCarColor.Count())],
                    CarPicture = rndCarPicture[rndnum.Next(rndCarPicture.Count())],
                    CarState = rndCarState[rndnum.Next(rndCarState.Count())],
                    CarCategoryId = rndnum.Next(1, 6)
                };
                carLists.Add(generatedCarItem);
            }

            foreach (var item in carLists)
            {
                db.CarLists.Add(item);
            }
            db.SaveChanges();


            base.Seed(db);
        }
    }
}