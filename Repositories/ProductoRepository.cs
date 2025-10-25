using System.ComponentModel;
using Microsoft.Data.Sqlite;
public class ProductoRepository : IProductoRepository
{
    string cadenaConexion = "Data Source=Tienda_final.db";

    public bool Crear(Producto producto)
    {
        using var conexion = new SqliteConnection(cadenaConexion);
        conexion.Open();
        string sql = "INSERT INTO Productos (descripcion, precio) VALUES(@descripcion, @precio)";
        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.Add(new SqliteParameter("@descripcion", producto.descripcion));
        comando.Parameters.Add(new SqliteParameter("@precio", producto.precio));
        comando.ExecuteNonQuery();

        return true;
    }
    public List<Producto> Listar()
    {
        List<Producto> productos = new List<Producto>();
        string queryString = "SELECT descripcion, precio FROM Productos";
        
        using SqliteConnection connection = new SqliteConnection(cadenaConexion);
        SqliteCommand command = new SqliteCommand(queryString, connection);
        connection.Open();
        using (SqliteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read()) // si encontró un registro
            {
                var producto = new Producto
                {
                    idProducto = reader.GetInt32(0),
                    descripcion = reader.GetString(1),
                    precio = reader.GetInt32(2),
                };
                productos.Add(producto);
            }
            connection.Close();
        }

        return productos;
    }
    public Producto ObtenerProductoID(int id)
    {
        string sql = "SELECT nombre, dni, telefono FROM Paciente WHERE Id = @Id";
        
        using SqliteConnection conexion = new SqliteConnection(cadenaConexion);
        conexion.Open();
        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.Add(new SqliteParameter("@Id", id));
        using var reader = comando.ExecuteReader();
        if (reader.Read()) // si encontró un registro
        {
            var paciente = new Producto
            {
                idProducto = reader.GetInt32(0),
                descripcion = reader.GetString(1),
                precio = reader.GetInt32(2),
            };
            return paciente;
        }
        return null;
    }
    public bool Modificar(int id, Producto producto)
    {
        using var conexion = new SqliteConnection(cadenaConexion);
        conexion.Open();
        string sql = "UPDATE Producto SET Precio = @Precio WHERE Id = @Id";
        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.Add(new SqliteParameter("@Precio", producto.precio));
        comando.Parameters.Add(new SqliteParameter("@Id", id));
        comando.ExecuteNonQuery();

        return true;
    }
    public bool EliminarProductoID(int id)
    {
        using var conexion = new SqliteConnection(cadenaConexion);
        conexion.Open();
        string sql = "DELETE FROM Producto WHERE Id = @Id";
        using var comando = new SqliteCommand(sql, conexion);
        comando.Parameters.Add(new SqliteParameter("@Id", id));
        comando.ExecuteNonQuery();

        return true;
    }

}