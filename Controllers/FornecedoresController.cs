using CadastroProdutos.Models;
using CadastroProdutos.Services.FornecedorServices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
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
                new InsertService().Execute(new Fornecedor() { Nome = nome, Status = true });
                return StatusCode(201, "Fornecedor salvo com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Fornecedor fornecedor)
        {
            try
            {
                new UpdateService().Execute(fornecedor);
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
                return StatusCode(200, "Fornecedor deletado com sucesso.");
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
