using CadastroProdutos.Models;
using CadastroProdutos.Services.CategoriaServices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(new GetAllService().Execute());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{codigo}")]
        public IActionResult Get(int codigo)
        {
            try
            {
                return Ok(new GetService().Execute(codigo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] string nome)
        {
            try
            {
                new InsertService().Execute(new Categoria() { Nome = nome, Status = true });
                return StatusCode(201, "Categoria salva com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Categoria categoria)
        {
            try
            {
                new UpdateService().Execute(categoria);
                return StatusCode(200, "Atualizado com sucesso.");
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Código inválido.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            try
            {
                new DeleteService().Execute(codigo);
                return StatusCode(200, "Categoria deletada com sucesso.");
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Código inválido.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
