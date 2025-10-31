using Microsoft.AspNetCore.Mvc;

namespace tl2_tp7_2025_fabricioclaudio1.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductoController : ControllerBase
{
    private ProductoRepository productoRepository;

    public ProductoController()
    {
        productoRepository = new ProductoRepository();

    }

    //endpoints, Action Methods (Get, Post,etc.)

    [HttpPost]
    [Route("/api/CrearProducto")]
    public IActionResult CrearProducto([FromBody] Producto nuevoProducto)
    {

        productoRepository.Crear(nuevoProducto);
        return Ok("Producto dado de alta exitosamente");
    }

    [HttpGet]
    [Route("/api/ObtenerProductoId/{id}")]
    public IActionResult ObtenerProductoId(int id)
    {
        Producto producto = productoRepository.ObtenerID(id);

        return Ok(producto);
    }

    [HttpGet]
    [Route("/api/ListarProductos")]
    public IActionResult ListarProducto()
    {
        List<Producto> listaProductos = productoRepository.Listar();
        return Ok(listaProductos);
    }

    [HttpPut]
    [Route("/api/ActualizarProducto")]
    public IActionResult ActualizarProducto([FromBody] Producto p)
    {
        productoRepository.Modificar(p.idProducto, p);
        return Ok("Producto Modificado Exitosamente");
    }

    [HttpDelete]
    [Route("/api/EliminarProducto/{id}")]
    public IActionResult EliminarProducto(int id)
    {
        bool eliminado = productoRepository.EliminarID(id);

        if (eliminado)
        {
            return NoContent();// HTTP 204 (Eliminación exitosa)
        }
        else
        {
            return NotFound($"No se encontró el producto con ID {id} para eliminar.");
        }

    }

    /* [HttpDelete]
    [Route("eliminarProducto/{id}")]
    public IActionResult EliminarTarea(int id)
    {
        if (gestorPrograma.EliminarPrograma(id))
        {
            ADatos.Guardar(gestorPrograma.ListarTodosLosProgramas(), @"Data/data.json");
            return Ok("Programa eliminado con exito");
        }

        return BadRequest("No se pudo eliminar el programa");
    } */


}

