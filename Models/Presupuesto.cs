public class Presupuesto
{
    public int IdPresupuesto { get; set; }
    public string NombreDestinatario { get; set; }
    public DateTime FechaCreacion { get; set; }
    public List<PresupuestoDetalle> ListaDetalle { get; set; } = new List<PresupuestoDetalle>();

    public Presupuesto()
    {
        
    }
    public double MontoPresupuesto()
    {
        double montoPresupuesto = 0;
        foreach (var detalles in ListaDetalle)
        {
            montoPresupuesto += detalles.producto.precio;
        }

        return montoPresupuesto;
    }
    
    public double MontoPresupuestoConIva()
    {
        double montoPresupuesto = MontoPresupuesto();
        montoPresupuesto *= 1.21;

        return montoPresupuesto;
    }

    public int CantidadProductos()
    {
        int cantidadProductos = 0;
        foreach (var detalles in ListaDetalle)
        {
            cantidadProductos += detalles.cantidad;
        }

        return cantidadProductos;
    }
}
