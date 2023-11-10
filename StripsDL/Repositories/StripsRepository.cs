using StripsBL.Interfaces;
using StripsBL.Model;
using StripsDL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StripsDL.Repositories
{
    public class StripsRepository : IStripsRepository
    {
        private string connectionString;

        public StripsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Reeks GeefReeks(int reeksID)
        {
            string sql = "SELECT * FROM Reeks WHERE Id=@reeksID";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@reeksID", reeksID);
                    IDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    Reeks s = new Reeks((int)dr["Id"], (string)dr["Naam"]);
                    dr.Close();
                    return s;
                }
                catch (Exception ex)
                {
                    throw new StripsRepositoryException("GeefReeks", ex);
                }
            }
        }

        public List<Strip> GeefStripsVanReeks(int id)
        {
            string sql = "SELECT * FROM Strip WHERE Reeks=@id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    List<Strip> strips = new List<Strip>();
                    conn.Open();
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id", id);
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Strip strip = new Strip(
                            Convert.ToInt32(reader["Id"]),
                            reader["Titel"] as string,
                            Convert.ToInt32(reader["Nr"])
                        );
                        strips.Add(strip);
                    }
                    reader.Close();
                    return strips;
                }
                catch (Exception ex)
                {
                    throw new StripsRepositoryException("GeefStripsVanReeks", ex);
                }
            }
        }
    }
}
