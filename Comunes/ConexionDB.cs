using examen_samuel.Model;
using System.Data;
using System.Data.SqlClient;

namespace examen_samuel.Comunes
{
    public class ConexionDB
    {
        public static SqlConnection conexion;

        public static SqlConnection abrirconexion()
        {
            conexion = new SqlConnection("Server=DESKTOP-HB58NUH\\SQLEXPRESS;Database=Examen;Trusted_Connection=True;");
            conexion.Open();
            return conexion;
        }

        public static List<Futbolista> GetFutbolistas()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirconexion();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_GET_FUTBOLISTAS";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return fillFutbolista(ds);
        }

        public static Futbolista GetFutbolista(string cedula)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirconexion();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_GET_FUTBOLISTA";
            cmd.Parameters.AddWithValue("@PI_CEDULA", cedula);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return fillFutbolista(ds)[0];
        }

        public static void PostFutbolista(Futbolista objJugador)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirconexion();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_INS_FUTBOLISTA";
            cmd.Parameters.AddWithValue("@PV_CEDULA", objJugador.cedula);
            cmd.Parameters.AddWithValue("@PV_NOMBRES", objJugador.nombres);
            cmd.Parameters.AddWithValue("@PV_APELLIDOS", objJugador.apellidos);
            cmd.Parameters.AddWithValue("@PV_FECHA_NACIMIENTO", objJugador.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@PV_PAIS", objJugador.pais);
            cmd.Parameters.AddWithValue("@PV_DIRECCION", objJugador.direccion);
            cmd.Parameters.AddWithValue("@PV_DESCRIPCION", objJugador.descripcion);

            cmd.ExecuteNonQuery();
        }

        public static void PutFutbolista(string cedula, Futbolista objJugador)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirconexion();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_UPD_FUTBOLISTA";
            cmd.Parameters.AddWithValue("@PV_NOMBRES", objJugador.nombres);
            cmd.Parameters.AddWithValue("@PV_APELLIDOS", objJugador.apellidos);
            cmd.Parameters.AddWithValue("@PV_FECHA_NACIMIENTO", objJugador.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@PV_PAIS", objJugador.pais);
            cmd.Parameters.AddWithValue("@PV_DIRECCION", objJugador.direccion);
            cmd.Parameters.AddWithValue("@PV_DESCRIPCION", objJugador.descripcion);



            cmd.ExecuteNonQuery();
        }

        public static void DeleteFutbolista(string cedula)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirconexion();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_DEL_FUTBOLISTA";
            cmd.Parameters.AddWithValue("PI_CEDULA", cedula);
            cmd.ExecuteNonQuery();
        }

        private static List<Futbolista> fillFutbolista(DataSet ds)
        {
            List<Futbolista> jugador = new List<Futbolista>();
            Futbolista objJugador = new Futbolista();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                objJugador = new Futbolista();
                objJugador.cedula = ds.Tables[0].Rows[i]["CEDULA"].ToString();
                objJugador.nombres = ds.Tables[0].Rows[i]["NOMBRES"].ToString();
                objJugador.apellidos = ds.Tables[0].Rows[i]["APELLIDOS"].ToString();
                objJugador.fecha_nacimiento = Convert.ToDateTime(ds.Tables[0].Rows[i]["FECHA_NACIMIENTO"].ToString());
                objJugador.pais = ds.Tables[0].Rows[i]["PAIS"].ToString();
                objJugador.direccion = ds.Tables[0].Rows[i]["DIRECCION"].ToString();
                objJugador.descripcion = ds.Tables[0].Rows[i]["DESCRIPCION"].ToString();
                jugador.Add(objJugador);
            }
            return jugador;
        }

        public static List<Historico> GetHistorico(string cedula)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirconexion();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_GET_HISTORICO_EQUIPOS";
            cmd.Parameters.AddWithValue("@PV_CEDULA", cedula);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return fillHistorico(ds);
        }

        private static List<Historico> fillHistorico(DataSet ds)
        {
            List<Historico> historico = new List<Historico>();
            Historico objHistorico = new Historico();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                objHistorico = new Historico();
                objHistorico.nombres = ds.Tables[0].Rows[i]["NOMBRES"].ToString();
                objHistorico.nombre_equipo = ds.Tables[0].Rows[i]["NOMBRE_EQUIPO"].ToString();
                objHistorico.fecha_inicio = ds.Tables[0].Rows[i]["FECHA_INICIO"].ToString();
                objHistorico.fecha_fin = ds.Tables[0].Rows[i]["FECHA_FIN"].ToString();
                historico.Add(objHistorico);
            }
            return historico;
        }
    }
}
