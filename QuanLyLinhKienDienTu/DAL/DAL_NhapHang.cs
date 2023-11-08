using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
   public class DAL_NhapHang :DbConnect
    {

        //Thêm hóa đơn
        public bool ThemPhieuNhap(DTO_NhapHang nhanhang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ThemPhieuNhap";
                cmd.Parameters.AddWithValue("manhanvien", nhanhang.Nhanhanvien);
                cmd.Parameters.AddWithValue("manhacungcap", nhanhang.Manhacungcap);
                cmd.Parameters.AddWithValue("totalPrice", nhanhang.Thanhtien);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }
    }
}
