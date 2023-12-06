using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;
using DAL;
using DTO;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI
{
    public partial class Form1 : Form
    {
        
        QLLKDTDataContext qllk = new QLLKDTDataContext();   
        public Form1()
        {
            InitializeComponent();
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSanPhamBanChamTheoSL();
        }

        private void LoadSanPhamBanChamTheoSL()
        {
            // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
            string connectionString = "Data Source=YOUR_SERVER_NAME;Initial Catalog=YOUR_DATABASE_NAME;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Mở kết nối
                    connection.Open();

                    // Truy vấn dữ liệu từ bảng sản phẩm
                    string query = "SELECT Price, Views, Inventory, IsSlowSelling FROM Products";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Đọc dữ liệu từ SQL Server vào DataTable
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Chuẩn bị dữ liệu đầu vào và đầu ra cho mô hình
                    double[][] inputs = new double[dataTable.Rows.Count][];
                    int[] outputs = new int[dataTable.Rows.Count];

                    // Đọc dữ liệu từ DataTable vào mảng inputs và outputs
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        inputs[i] = new double[]
                        {
                            Convert.ToDouble(dataTable.Rows[i]["Price"]),
                            Convert.ToDouble(dataTable.Rows[i]["Views"]),
                            Convert.ToDouble(dataTable.Rows[i]["Inventory"])
                        };

                        outputs[i] = Convert.ToInt32(dataTable.Rows[i]["IsSlowSelling"]);
                    }

                    // Tạo mô hình Decision Tree
                    var tree = new DecisionTree();
                    var id3Learning = new ID3Learning();

                    // Huấn luyện mô hình
                    DecisionTreeModel model = id3Learning.Learn(inputs, outputs);

                    // Dự đoán cho sản phẩm mới (Giả sử: sản phẩm mới có giá, lượt xem, số lượng tồn kho là price, views, inventory)
                    double[] newProduct = { price, views, inventory };
                    int predictedClass = model.Decide(newProduct);

                    if (predictedClass == 1)
                    {
                        Console.WriteLine("Sản phẩm có khả năng bán chậm.");
                    }
                    else
                    {
                        Console.WriteLine("Sản phẩm không có khả năng bán chậm.");
                    }

                    // Đóng kết nối
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }

        }

    }

}
