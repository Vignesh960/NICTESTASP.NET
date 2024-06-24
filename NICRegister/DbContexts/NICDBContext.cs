using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NICRegister.Models;
using System.Data;

namespace NICRegister.DbContexts
{
    public class NICDBContext : DbContext
    {
        public NICDBContext(DbContextOptions<NICDBContext> options) : base(options)
        {
        }
        public DbSet<Register> MyRegistrations { get; set; }

        #region
        //private readonly string? ConnStr;

        //public NICDBContext(IConfiguration configuration)
        //{
        //    this.ConnStr = configuration.GetConnectionString("NICConn");
        //}

        //public async Task<List<Register>> getregistered()
        //{
        //    List<Register> List = new List<Register>();
        //    DataTable dt = new DataTable();
        //    using (SqlConnection conn = new SqlConnection(this.ConnStr))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(ConnStr, conn);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.CommandText = "GetRegistredusers";
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            Register reg = new Register();
        //            reg.Id = Convert.ToInt32(dr["Id"].ToString());
        //            reg.Name = dr["Name"].ToString();
        //            reg.FatherName = dr["FatherName"].ToString();
        //            reg.Email = dr["Email"].ToString();
        //            reg.Mobile = dr["Mobile"].ToString();
        //            reg.AdharNumber = dr["AdharNumber"].ToString();
        //            reg.District = dr["District"].ToString();
        //            reg.Mondal = dr["Mondal"].ToString();
        //            reg.Village = dr["Village"].ToString();
        //            reg.Address = dr["Address"].ToString();

        //            List.Add(reg);


        //        }
        //        conn.Close();
        //        return List;
        //    }

        //}


        //public bool Register(Register reg)
        //{
        //    int s = 0;
        //    using (SqlConnection conn = new SqlConnection(this.ConnStr))
        //    {
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(ConnStr, conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "usp_Insertusers";
        //        cmd.Parameters.AddWithValue("@Name", reg.Name);
        //        cmd.Parameters.AddWithValue("@FatherName", reg.FatherName);
        //        cmd.Parameters.AddWithValue("@Gender", reg.Gender);
        //        cmd.Parameters.AddWithValue("@Email", reg.Email);
        //        cmd.Parameters.AddWithValue("@Mobile", reg.Mobile);
        //        cmd.Parameters.AddWithValue("@AdharNumber", reg.AdharNumber);
        //        cmd.Parameters.AddWithValue("@District", reg.District);
        //        cmd.Parameters.AddWithValue("@Mondal", reg.Mondal);
        //        cmd.Parameters.AddWithValue("@Village", reg.Village);
        //        cmd.Parameters.AddWithValue("@Address", reg.Address);

        //        s = cmd.ExecuteNonQuery();
        //        return s > 0 ? true : false;



        //    }
        #endregion

    }
}

