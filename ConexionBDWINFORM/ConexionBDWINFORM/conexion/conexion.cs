using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient; /* Proveedor de datos  -- Tiene una coleccion de clases utilizada para tener acceso a una base de datos */
using System.Data; /* Proporciona acceso a clases que representan la arquitectura ADO.NET */

namespace ConexionBDWINFORM.conexion
{
    class conexion
    {

        /* variable de conexion*/
        public static string ruta = "Data Source=.;Initial Catalog=COLEGIO;Integrated Security=True";

        public SqlConnection con; /* objeto de conexion */
        private SqlCommand cmd; /* comandos o (Instrucciones SQL) */

        /* creando funcion para conectarse a la BD */
        public void conectar()
        {
            // Inicializando la conexion
            con = new SqlConnection(ruta);
        }

        // Creando un Constructor para que se ejecute de primero la funcion conectar
        public conexion()
        {
            conectar();
        }

        // ELIMINAR
        public Boolean eliminar(string cadena)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = cadena;
                cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                con.Close();
                return false;
            }
        }

        // BUSCAR
        public DataTable buscar(string cadena)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da;
                DataTable dt;
                string consulta = cadena;
                con.Open();
                da = new SqlDataAdapter(consulta, con);
                da.Fill(ds);
                con.Close();
                dt = ds.Tables[0];
                return (dt);
            }
            catch
            {
                con.Close();
                return null;
            }
        }

        // MODIFICAR
        public Boolean actualizar(string cadena)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = cadena;
                cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                con.Close();
                return false;
            }
        }

        // insertar
        public Boolean insertar(string cadena)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = cadena;
                cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                con.Close();
                return false;
            }
        }
    }
}
