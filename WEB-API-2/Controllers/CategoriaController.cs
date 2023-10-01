using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WEB_API_2.DTOs;
using WEB_API_2.Responses;
using WEB_API_2.Services;

namespace WEB_API_2.Controllers
{
    [Route("api/v1/categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaResponse>> ObtenerCategoriaPorId(int id)
        {
            try
            {
                var response = await _categoriaService.ObtenerCategoriaPorId(id);
                if (response.Status)
                    return Ok(response);
                else
                    return NotFound(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CategoriaResponse
                {
                    Status = false,
                    Code = 500,
                    Message = "Error: " + ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult<CategoriasResponse>> ListarCategorias()
        {
            try
            {
                var response = await _categoriaService.ListarCategorias();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CategoriaResponse
                {
                    Status = false,
                    Code = 500,
                    Message = "Error: " + ex.Message
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaResponse>> CrearCategoria([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                var response = await _categoriaService.CrearCategoria(categoriaDTO);
                if (response.Status)
                    return CreatedAtAction(nameof(ObtenerCategoriaPorId), new { id = response.Data.Id }, response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CategoriaResponse
                {
                    Status = false,
                    Code = 500,
                    Message = "Error: " + ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriaResponse>> ActualizarCategoria(int id, [FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                var response = await _categoriaService.ActualizarCategoria(id, categoriaDTO);
                if (response.Status)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CategoriaResponse
                {
                    Status = false,
                    Code = 500,
                    Message = "Error interno al actualizar la categoría: " + ex.Message,
                    Data = null
                });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoriaResponse>> EliminarCategoria(int id)
        {
            try
            {
                var response = await _categoriaService.EliminarCategoria(id);
                if (response.Status)
                    return Ok(response);
                else
                    return NotFound(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CategoriaResponse
                {
                    Status = false,
                    Code = 500,
                    Message = "Error: " + ex.Message
                });
            }
        }
    }
}
