using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ComercioEntities;

namespace ComercioDAL
{
    public class EmpleadoDAL
    {
        public static List<Empleado> ListarEmpleados(string NombreCompleto)
        {
            List<Empleado> list = new List<Empleado>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cnn"].ToString()))
            {
                conn.Open();

                string sql = @"ListarEmpleados";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NombreCompleto", SqlDbType.VarChar).Value = NombreCompleto;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(ObtenerEmpleado(reader));
                }
            }
            return list;
        }

        public static Empleado ObtenerEmpleado(int Id)
        {
            Empleado empleado = new Empleado();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cnn"].ToString()))
            {
                conn.Open();

                string sql = @"ObtenerEmpleado";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    empleado = ObtenerEmpleado(reader);
                }
            }
            return empleado;
        }

        public static Empleado ObtenerEmpleado(SqlDataReader reader)
        {
            Empleado empleado = new Empleado();

            empleado.Id = Convert.ToInt32(reader["Id"]);
            empleado.NombreCompleto = Convert.ToString(reader["NombreCompleto"]);
            empleado.DNI = Convert.ToInt32(reader["DNI"]);
            empleado.Edad = Convert.ToInt32(reader["Edad"]);
            empleado.Casado = Convert.ToBoolean(reader["Casado"]);
            empleado.Salario = Convert.ToDecimal(reader["Salario"]);

            return empleado;
        }

        public static Empleado AltaModEmpleado(Empleado empleado)
        {
            Empleado Empleado = empleado;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cnn"].ToString()))
                {
                    conn.Open();
                    string sql = string.Empty;
                    if(Empleado.Id > 0)
                    {
                        sql = @"ModificarEmpleado";
                    }
                    else
                    {
                        sql = @"AltaEmpleado";
                    }

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    if(Empleado.Id > 0)
                    {
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = empleado.Id;
                    }

                    cmd.Parameters.Add("@NombreCompleto", SqlDbType.VarChar).Value = empleado.NombreCompleto;
                    cmd.Parameters.Add("@DNI", SqlDbType.Int).Value = empleado.DNI;
                    cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = empleado.Edad;
                    cmd.Parameters.Add("@Casado", SqlDbType.Bit).Value = empleado.Casado;
                    cmd.Parameters.Add("@Salario", SqlDbType.Decimal).Value = empleado.Salario;

                    cmd.ExecuteNonQuery();

                    return Empleado;
                }
            }
            catch (Exception Ex)
            {
                return Empleado;
            }
        }

        public static void EliminarEmpleado(int Id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cnn"].ToString()))
                {
                    conn.Open();
                    string sql = @"EliminarEmpleado";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception Ex)
            {

            }
        }
    }
}
