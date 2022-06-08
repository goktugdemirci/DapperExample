using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionString.ConStr);
            cmd = con.CreateCommand();
        }
        #region[Kategori CRUD]
        public List<Category> kategoriler = dbConnection.Query<Category>("SELECT * FROM Categories").ToList();
        #endregion

        #region[Ürün CRUD]

        #endregion

        #region[Tedarikçi CRUD]

        #endregion
    }
}
