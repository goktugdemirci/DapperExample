
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            DataModel dm = new DataModel();
            //dm.UrunDetayGetir(55);
            //dm.MultiQuery(1, 1);
            //
            //Product urun = new Product();
            //urun.ProductName = "DapperDemo";
            //urun.CategoryID = 1;
            //urun.SupplierID = 1;
            //urun.Discontinued = false;
            //urun.UnitPrice = 12.99m;
            //urun.UnitsInStock = 11;
            //if (dm.UrunEkle(urun))
            //{
            //    dm.UrunListele();
            //}
            //else
            //{
            //    Console.WriteLine("Hata");
            //}
            //
            //Category kat = new Category();
            //kat.CategoryID = 1;
            //kat.CategoryName = "Icecekler";
            //kat.Description = "Icecegin Her Turlusu";
            //if (dm.KategoriGuncelle(kat))
            //{
            //    dm.KategoriListele();
            //}
            //else
            //{
            //    Console.WriteLine("Hata");
            //}
            //
            //Category kat = new Category();
            //kat.CategoryName = "Takım/Avadanlık";
            //kat.Description = "Ivır/Zıvır";
            //if (dm.KategoriEkle(kat))
            //{
            //    dm.KategoriListele();
            //}
            //else
            //{
            //    Console.WriteLine("Hata");
            //}
            //
            //if (dm.KategoriSil(45))
            //{
            //    dm.KategoriListele();
            //}
            //else
            //{
            //    Console.WriteLine("Hata");
            //}

            //
            //Supplier supplier = new Supplier();
            //supplier.CompanyName = "Jupiter Kuruyemis";
            //supplier.City = "Adiyaman";
            //supplier.Country = "Turkiye";
            //if (dm.TedarikciEkle(supplier))
            //{
            //    dm.TedarikciListele();
            //}
            //else
            //{
            //    Console.WriteLine("Hata");
            //}
            //
            //if (dm.TedarikciSil(30))
            //{
            //    dm.TedarikciListele();
            //}
            //else
            //{
            //    Console.WriteLine("Hata");
            //}
        }
    }
}
