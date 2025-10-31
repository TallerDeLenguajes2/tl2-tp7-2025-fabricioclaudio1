using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

namespace tl2_tp7_2025_fabricioclaudio1.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestoController : ControllerBase
{
    private PresupuestoRepository presupuestoRepository;
    private ProductoRepository productoRepository;

    public PresupuestoController()
    {
        presupuestoRepository = new PresupuestoRepository();
        productoRepository = new ProductoRepository();
    }

    //endpoints, Action Methods (Get, Post,etc.)

    [HttpPost]
    [Route("CrearPresupuesto")]
    public IActionResult CrearPresupuesto([FromBody] Presupuesto nuevoPresupuesto)
    {

        presupuestoRepository.Crear(nuevoPresupuesto);
        return Ok("Presupuesto dado de alta exitosamente");
    }

    [HttpPost]
    [Route("/api/PresupuestoCompletar/{idPresupuesto}/ProductoDetalle")]
    public IActionResult CompletarPresupuesto(int idPresupuesto, [FromBody] PresupuestoDetalle presupuestoDetalle)
    {
        List<Producto> productos = productoRepository.Listar();

        Presupuesto presupuesto = presupuestoRepository.ObtenerID(idPresupuesto);

        Presupuesto nuevoPresupuesto = new Presupuesto();
        nuevoPresupuesto.Detalle.Add(presupuestoDetalle);


        if (productos.Exists(p => p == presupuestoDetalle.producto))
        {
            presupuestoRepository.Modificar(presupuesto.IdPresupuesto, nuevoPresupuesto);
        }

        
        return Ok("Presupuesto completado exitosamente");
    }

    [HttpGet]
    [Route("ObtenerPresupuestoId/{id}")]
    public IActionResult ObtenerPresupuestoId(int id)
    {
        Presupuesto presupuesto = presupuestoRepository.ObtenerID(id);

        return Ok(presupuesto);
    }

     /* /api/Presupuesto/{id}/ProductoDetalle: Permite agregar un Producto existente
y una cantidad al presupuesto. */


    [HttpGet]
    [Route("ListarPresupuesto")]
    public IActionResult ListarPresupuesto()
    {
        List<Presupuesto> listarPresupuesto = presupuestoRepository.Listar();
        return Ok(listarPresupuesto);
    }

    [HttpPut]
    [Route("ActualizarPresupuesto")]
    public IActionResult ActualizarPresupuesto([FromBody] Presupuesto p)
    {
        presupuestoRepository.Modificar(p.IdPresupuesto, p);
        return Ok("Presupuesto Modificado Exitosamente");
    }

    [HttpDelete]
    [Route("EliminarPresupuesto/{id}")]
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

