using CadastroProdutos.Models;
using CadastroProdutos.Services.ProdutoServices;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
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
        public IActionResult Insert(Produto produto)
        {
            try
            {
                produto.Codigo = 0;
                new InsertService().Execute(produto);
                return StatusCode(201, "Produto salvo com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(Produto produto)
        {
            try
            {
                new UpdateService().Execute(produto);
                return StatusCode(200, "Atualizado com sucesso.");
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
                return StatusCode(200, "Produto deletado com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
