//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using NICRegister.Models;
//using System.Data;

//namespace NICRegister.DbContexts
//{
//    public class DbContexts : DbContext
//    {
//        private readonly DbContextOptions option;
//        #region
//        //public DbContexts(DbContextOptions<DbContexts> options) : base(options)
//        //{
//        //    this.option = options;
//        //}
//        //public DbSet<Register> Registrations { get; set; }
//        #endregion
//        private readonly string? ConnStr;

//        public DbContexts(IConfiguration configuration)
//        {
//            this.ConnStr = configuration.GetConnectionString("NICConn");
//        }

//        public async Task<List<Register>> RegisteredListAsync()
//        {
//            List<Register> empList = new List<Register>();
//            DataTable dt = new DataTable();
//            using (SqlConnection conn = new SqlConnection(this.ConnStr))
//            {
//                conn.Open();
//                SqlCommand cmd = new SqlCommand(ConnStr, conn);
//                cmd.CommandType = System.Data.CommandType.StoredProcedure;
//                cmd.CommandText = "GetRegisteredList";
//                SqlDataReader dr = cmd.ExecuteReader();
//                while (dr.Read())
//                {
//                    Register reg = new Register();
//                    reg.Id = Convert.ToInt32(dr["Id"].ToString());
//                    reg.Name = dr["Name"].ToString();
//                    reg.FatherName = dr["FatherName"].ToString();
//                    reg.Email = dr["Email"].ToString();
//                    reg.Mobile = dr["Mobile"].ToString();
//                    reg.AdharNumber = dr["AdharNumber"].ToString();
//                    reg.District = dr["District"].ToString();
//                    reg.Mondal = dr["Mondal"].ToString();
//                    reg.Village = dr["Village"].ToString();
//                    reg.Address = dr["Address"].ToString();

//                    empList.Add(reg);


//                }
//                conn.Close();
//                return empList;
//            }

//        }
//    }
//}

