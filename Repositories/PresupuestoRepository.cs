
using Microsoft.Data.Sqlite;
public class PresupuestoRepository
{
    string cadenaConexion = "Data Source=Tienda.db";

    public bool Crear(Presupuesto presupuesto)
    {
        using var conexion = new SqliteConnection(cadenaConexion);
        conexion.Open();
        string sql = "INSERT INTO Presupuesto (NombreDestinatario) VALUES(@nombreDestinario)";
        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.Add(new SqliteParameter("@nombreDestinario", presupuesto.NombreDestinatario));
        comando.ExecuteNonQuery();

        return true;
    }
    public List<Presupuesto> Listar()
    {
        List<Presupuesto> presupuestos = new();
        string queryString = "SELECT * FROM Productos;";
        using (SqliteConnection connection = new SqliteConnection(cadenaConexion))
        {
            SqliteCommand command = new SqliteCommand(queryString, connection);
            connection.Open();
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read()) // si encontró un registro
                {
                    var presupuesto = new Presupuesto
                    {
                        IdPresupuesto = reader.GetInt32(0),
                        NombreDestinatario = reader.GetString(1),
                        FechaCreacion = reader.GetDateTime(2),
                    };
                    presupuestos.Add(presupuesto);
                }
                connection.Close();
            }

            return presupuestos;
        }
    }
    public Presupuesto ObtenerID(int id)
    {
        using var conexion = new SqliteConnection(cadenaConexion);
        conexion.Open();
        string sql = "SELECT NombreDestinatario, FechaCreacion FROM Presupuesto WHERE Id = @Id";
        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.Add(new SqliteParameter("@Id", id));
        using var reader = comando.ExecuteReader();
        if (reader.Read()) // si encontró un registro
        {
            var presupuesto = new Presupuesto
            {
                NombreDestinatario = reader.GetString(1),
                FechaCreacion = reader.GetDateTime(2),
            };
            return presupuesto;
        }
        return null;
    }
    public bool Modificar(int id, Presupuesto presupuesto)
    {
        using var conexion = new SqliteConnection(cadenaConexion);
        conexion.Open();
        string sql = "UPDATE Producto SET NombreDestinatario = @NombreDestinatario WHERE Id = @Id";
        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.Add(new SqliteParameter("@NombreDestinatario", presupuesto.NombreDestinatario));
        comando.Parameters.Add(new SqliteParameter("@Id", id));
        comando.ExecuteNonQuery();

        return true;
    }
    public bool EliminarID(int id)
    {
        using var conexion = new SqliteConnection(cadenaConexion);
        conexion.Open();
        string sql = "DELETE FROM Presupuesto WHERE Id = @Id";
        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.Add(new SqliteParameter("@Id", id));
        comando.ExecuteNonQuery();

        return true;
    }

}