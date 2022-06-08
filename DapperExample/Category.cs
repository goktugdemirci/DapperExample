using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExample
{
    internal class Category
    {
        //Dapper kullanırken dikkat etmemiz gereken tek nokta veri tabanı kolonları ile aynı isimde proplarımızı oluşturmamız olacaktır. Bunun sebebi Dapper otomatik olarak Map yani eşleştirme işlemi yapar.
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

        
    }
}
