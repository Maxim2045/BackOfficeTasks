using FirstTask.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите необходимое действие: 1 - добавить лекарство, 2 - удалить лекарство, 3 - выгрузить в xml");

            int i = int.Parse(Console.ReadLine());
            switch(i)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Medicine;Integrated Security=True;";
                    string sql = "SELECT * FROM Preparats"; 
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

                        DataSet ds = new DataSet("Preparats");
                        DataTable dt = new DataTable("Preparat");
                        ds.Tables.Add(dt);
                        adapter.Fill(ds.Tables["Preparat"]);


                        ds.WriteXml("countrysdb.xml");
                        Console.WriteLine("Данные сохранены в файл");
                    }
                    break;
                default:
                    break;
            }


          /*   using (MedicineContext db = new MedicineContext())
            {
                Company vel = new Company { Name = "Велфарм" };
                Company izm = new Company { Name = "Измалино" };
                db.Companys.Add(vel);
                db.Companys.Add(izm);


                Country rus = new Country { Name = "Россия" };
                Country eng = new Country { Name = "Великобритания" };
                db.Countrys.Add(rus);
                db.Countrys.Add(eng);

                Kind pp = new Kind { Name = "табл. п.п.о." };
                Kind pr = new Kind { Name = "табл. пролонг." };
                db.Kinds.Add(pp);
                db.Kinds.Add(pr);

                Preparat velk = new Preparat { Name = "Велкардио" };
                Preparat pom = new Preparat { Name = "Помелан" };
                db.Preparats.Add(velk);
                db.Preparats.Add(pom);


                Product p1 = new Product { CompanyId=1, PreparatId=2, KindId = 2, CountryId = 2,Weight= 10};
                Product p2 = new Product { CompanyId = 2, PreparatId = 1, KindId = 2, CountryId = 1, Weight = 220 };

                db.Products.Add(p1);
                db.Products.Add(p2);
                
                db.SaveChanges();               
            }*/
        }
    }
}
