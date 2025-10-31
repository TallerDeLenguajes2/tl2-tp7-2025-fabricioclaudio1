using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

namespace tl2_tp7_2025_fabricioclaudio1.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    private readonly PresupuestoRepository presupuestoRepository;
    private readonly ProductoRepository productoRepository;

    public PresupuestoController()
    {
        presupuestoRepository = new PresupuestoRepository();
        productoRepository = new ProductoRepository();
    }

    //endpoints, Action Methods (Get, Post,etc.)

    [HttpPost]
    [Route("/api/CrearPresupuesto")]
    public IActionResult CrearPresupuesto([FromBody] Presupuesto nuevoPresupuesto)
    {

        presupuestoRepository.Crear(nuevoPresupuesto);
        return Ok("Presupuesto dado de alta exitosamente");
    }

    [HttpPost]
    [Route("/api/PresupuestoCompletar/{idPresupuesto}")]
    public IActionResult CompletarPresupuesto(int idPresupuesto, [FromBody] PresupuestoDetalle presupuestoDetalle)
    {
        List<Producto> productos = productoRepository.Listar();

        Presupuesto presupuesto = presupuestoRepository.ObtenerID(idPresupuesto);

        Presupuesto nuevoPresupuesto = new Presupuesto();
        nuevoPresupuesto.ListaDetalle.Add(presupuestoDetalle);


        if (productos.Exists(p => p == presupuestoDetalle.producto))
        {
            presupuestoRepository.Modificar(presupuesto.IdPresupuesto, nuevoPresupuesto);
        }

        
        return Ok("Presupuesto completado exitosamente");
    }

    [HttpGet]
    [Route("/api/ObtenerPresupuesto/{id}")]
    public IActionResult ObtenerPresupuestoId(int id)
    {
        Presupuesto presupuesto = presupuestoRepository.ObtenerID(id);

        return Ok(presupuesto);
    }

     /* /api/Presupuesto/{id}/ProductoDetalle: Permite agregar un Producto existente
y una cantidad al presupuesto. */


    [HttpGet]
    [Route("/api/ListarPresupuesto/")]
    public IActionResult ListarPresupuesto()
    {
        List<Presupuesto> listarPresupuesto = presupuestoRepository.Listar();
        return Ok(listarPresupuesto);
    }

    [HttpDelete]
    [Route("/api/EliminarPresupuesto/{id}")]
    public IActionResult EliminarPresupuesto(int id)
    {
        bool eliminado = presupuestoRepository.EliminarID(id);

        if (eliminado)
        {
            return NoContent();// HTTP 204 (Eliminación exitosa)
        }
        else
        {
            return NotFound($"No se encontró el Presupuesto con ID {id} para eliminar.");
        }

    }



}

