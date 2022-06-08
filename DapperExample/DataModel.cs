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
    internal class DataModel
    {
        IDbConnection dbConnection = new SqlConnection(ConnectionString.ConStr);

        #region [Kategori CRUD]
        public void KategoriListele()
        {
            try
            {
                dbConnection.Open();
                List<Category> kategoriler = dbConnection.Query<Category>("SELECT * FROM Categories").ToList();
                foreach (Category c in kategoriler)
                {
                    Console.WriteLine($"{c.CategoryID}{BoslukHizala(c.CategoryName, kategoriler)}{c.CategoryName}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Listeleme Hatası {ex.Message}");
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public bool KategoriEkle(Category kat)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Categories(CategoryName,Description) VALUES(@CategoryName,@Description)", kat);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { dbConnection.Close(); }
        }

        public bool KategoriGuncelle(Category kat)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Categories SET CategoryName = @CategoryName, Description = @Description WHERE CategoryID = @CategoryID", kat);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally { dbConnection.Close(); }
        }

        public bool KategoriSil(int CategoryID)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Categories WHERE CategoryID = @CategoryID", new { CategoryID });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally { dbConnection.Close(); }
        }
        #endregion

        #region [Urun CRUD]
        public void UrunListele()
        {

            try
            {
                dbConnection.Open();
                List<Product> urunler = dbConnection.Query<Product>("SELECT * FROM Products").ToList();
                foreach (Product p in urunler)
                {
                    Console.WriteLine($"{p.ProductID}{BoslukHizala(p.ProductName, urunler)}{p.ProductName}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Listeleme Hatası {ex.Message}");
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public bool UrunEkle(Product urun)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute(
                    "INSERT INTO Products(ProductName, CategoryID, UnitPrice,SupplierID,UnitsInStock,Discontinued) VALUES(@productName,@categoryID,@unitPrice,@supplierID,@unitsInStock,@discontinued)",
                    urun
                    );
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally { dbConnection.Close(); }
        }

        public bool UrunAdiGuncelle(Product urun)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Products SET ProductName = @ProductName WHERE ProductID = @ProductID", urun);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally { dbConnection.Close(); }
        }

        public bool UrunSil(int ProductID)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Products WHERE Product = @ProductID", new { ProductID });
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally { dbConnection.Close(); }
        }
        #endregion

        #region [Tedarikci CRUD]
        public void TedarikciListele()
        {

            try
            {
                dbConnection.Open();
                List<Supplier> tedarikciler = dbConnection.Query<Supplier>("SELECT * FROM Suppliers").ToList();
                foreach (Supplier s in tedarikciler)
                {
                    Console.WriteLine($"{s.CompanyName}{BoslukHizala(s.CompanyName, tedarikciler)}{s.City}-{s.Country}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Listeleme Hatası {ex.Message}");
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public bool TedarikciEkle(Supplier sup)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Suppliers(CompanyName,City,Country) VALUES(@CompanyName,@City,@Country)", sup);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata Mesajı . {ex.Message}");
                return false;
            }
            finally { dbConnection.Close(); }
        }

        public bool TedarikciGuncelle(Supplier sup)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("UPDATE Suppliers SET CompanyName = @CompanyName, City = @City, Country = @Country  WHERE SupplierID = @SupplierID",sup);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally { dbConnection.Close(); }
        }

        public bool TedarikciSil(int SupplierID)
        {
            try
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Categories WHERE SupplierID = @SupplierID",new{ SupplierID });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally { dbConnection.Close(); }
        }
        #endregion

        #region Diger Metotlar

        #region Boşluk Hizala & Overloads
        public string BoslukHizala(string input, List<Category> kategoriler)
        {
            string bosluk = "";
            List<string> kategoriIsimler = new List<string>();
            for (int i = 0; i < kategoriler.Count; i++)
            {
                kategoriIsimler.Add(kategoriler[i].CategoryName);
            }
            int enUzunluk = kategoriIsimler.OrderByDescending(s => s.Length).First().Length;
            for (int i = enUzunluk + 3; i >= input.Length; i--)
            {
                bosluk += " ";
            }
            return bosluk;
        }
        public string BoslukHizala(string input, List<Product> urunler)
        {
            string bosluk = "";
            List<string> urunIsimler = new List<string>();
            for (int i = 0; i < urunler.Count; i++)
            {
                urunIsimler.Add(urunler[i].ProductName);
            }
            int enUzunluk = urunIsimler.OrderByDescending(s => s.Length).First().Length;
            for (int i = enUzunluk; i >= input.Length; i--)
            {
                bosluk += " ";
            }
            return bosluk;
        }

        public string BoslukHizala(string input, List<Supplier> tedarikciler)
        {
            string bosluk = "";
            List<string> tedarikciIsimler = new List<string>();
            for (int i = 0; i < tedarikciler.Count; i++)
            {
                tedarikciIsimler.Add(tedarikciler[i].CompanyName);
            }
            int enUzunluk = tedarikciIsimler.OrderByDescending(s => s.Length).First().Length;
            for (int i = enUzunluk; i >= input.Length; i--)
            {
                bosluk += " ";
            }
            return bosluk;
        }
        #endregion

        // EXECUTE-SCALAR
        public string GetProductNameByID(int productID)
        {
            try
            {
                dbConnection.Open();
                string productName = dbConnection.ExecuteScalar<string>(
                            "SELECT ProductName FROM Products WHERE ProductID = @ProductID",
                            new Product
                            {
                                ProductID = productID
                            }
                            );
                return productName;

            }
            catch (Exception ex)
            {
                return $"Ürün Adı Getirilemedi, Hata : {ex.Message}";
            }
            finally
            {
                dbConnection.Close();
            }
        }

        //QUERY-FIRST   &   JOIN
        public void UrunDetayGetir(int productID)
        {
            try
            {
                dbConnection.Open();
                Product urun = dbConnection.QueryFirst<Product>("SELECT P.ProductID, P.ProductName, P.CategoryID, C.CategoryName, P.SupplierID, S.CompanyName, P.UnitPrice, P.UnitsInStock, P.Discontinued FROM Products AS P JOIN Categories AS C ON P.CategoryID = C.CategoryID JOIN Suppliers AS S ON P.SupplierID = S.SupplierID WHERE P.ProductID = @ProductID",
                    new Product
                    {
                        ProductID = productID
                    });
                Console.WriteLine($"{urun.ProductName}|{urun.CompanyName}");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Hata Mesajı :{ex.Message} ");
            }
            finally
            {
                dbConnection.Close();
            }
        }

        //QUERY-MULTIPLE
        public void MultiQuery(int productID, int categoryID)
        {
            string multiQuery = "SELECT * FROM Products WHERE ProductID = @ProductID; SELECT * FROM Categories";
            try
            {
                dbConnection.Open();
                var multi = dbConnection.QueryMultiple(multiQuery, new { ProductID = productID, categoryID = categoryID });
                Product urun = multi.Read<Product>().First();
                List<Category> kategoriler = multi.Read<Category>().ToList();
                foreach (Category item in kategoriler)
                {
                    Console.WriteLine($"{item.CategoryID}|\t{item.CategoryName}");
                }
                Console.WriteLine($"{urun.ProductName}\t{urun.CompanyName}");
            }
            catch (Exception ex)
            {

                Console.WriteLine($"HATA MESAJI : {ex.Message}");
            }
            finally
            {
                dbConnection.Close();
            }
        }
        #endregion

    }
}
