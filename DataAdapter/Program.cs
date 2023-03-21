using System.Data;
using System.Data;
using System.Data.SqlClient;
namespace DataAdapter {

    public class Program {
        static public void Main() {
            SqlConnection nwindConn = new SqlConnection("Data Source=(localdb)\\LocalServer;" +
                "Initial Catalog=Northwind;"
                + "Integrated Security=true");
            SqlCommand selectCMD = new SqlCommand("SELECT * FROM Categories", nwindConn);
            selectCMD.CommandTimeout = 30;
            SqlDataAdapter customerDA = new SqlDataAdapter();
            customerDA.SelectCommand = selectCMD;
            nwindConn.Open();
            DataSet customerDS = new DataSet();
            customerDA.Fill(customerDS, "Categories");
            nwindConn.Close();

            Console.WriteLine("Tabela Categories:");
            foreach (DataRow row in customerDS.Tables["Categories"].Rows)
            {
                Console.WriteLine($"{row["CategoryID"]} {row["CategoryName"]} {row["Description"]}");
            }

        }
    }
}