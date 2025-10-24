public class Presupuesto
{
    public int IdPresupuesto { get; set; }
    public string nombreDestinatario { get; set; }
    public DateTime FechaCreacion { get; set; }
    public List<PresupuestoDetalle> detalle { get; set; }

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
