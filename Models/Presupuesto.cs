public class Presupuesto
{
    public int IdPresupuesto { get; set; }
    public string NombreDestinatario { get; set; }
    public DateTime FechaCreacion { get; set; }
    public List<PresupuestoDetalle> Detalle { get; set; } = new List<PresupuestoDetalle>();

    public Presupuesto()
    {
        
    }
    public int MontoPresupuesto()
    {
        return 1;
    }
    
    public int MontoPresupuestoConIva()
    {
        return 1;
    }

    public int CantidadProductos()
    {
        return 1;
    }
}
