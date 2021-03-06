using CarDealership.Data.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADO
{
    public class MakeRepositoryADO : IMakeRepository
    {
        public IEnumerable<Make> GetAll()
        {
            List<Make> makes = new List<Make>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Make currentRow = new Make();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.UserID = dr["UserID"].ToString();

                        makes.Add(currentRow);
                    }
                }
            }
            return makes;
        }

        public IEnumerable<MakeListItem> GetMakeList()
        {
            List<MakeListItem> makes = new List<MakeListItem>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeListSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MakeListItem currentRow = new MakeListItem();
                        currentRow.MakeID = (int)dr["MakeID"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.UserID = dr["UserID"].ToString();

                        makes.Add(currentRow);
                    }
                }
            }
            return makes;
        }

        public void Insert(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("MakeID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                cmd.Parameters.AddWithValue("@UserID", make.UserID);

                cn.Open();

                cmd.ExecuteNonQuery();

                make.MakeID = (int)param.Value;
            }
        }
    }
}
