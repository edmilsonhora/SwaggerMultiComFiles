using ESH_MultiVersionSwagger.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESH_MultiVersionSwagger.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Produtos Index");
        }

        [HttpGet, Route("getAll")]
        [ProducesResponseType(typeof(List<Produto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Produto>> ObterProdutos()
        {
            var lista = new List<Produto>()
            {
                new Produto{ Id=1, Descricao="Produto 1", Preco=10.00m, Ativo=true},
                new Produto{ Id=2, Descricao="Produto 2", Preco=15.00m, Ativo=true}
            };

            return Ok(lista);
        }

        [HttpGet, Route("getbyid/{id:int}")]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status500InternalServerError)]
        public ActionResult<Produto> ObterProdutoById(int id)
        {

            var obj = new Produto { Id = 1, Descricao = "Produto 1", Preco = 10.00m, Ativo = true };


            return Ok(obj);
        }

        [HttpPost, Route("salvar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status400BadRequest)]        
        [ProducesResponseType(typeof(Erro), StatusCodes.Status500InternalServerError)]
        public IActionResult Salvar(Produto produto)
        {
            try
            {
                produto.Validar();
                return Ok();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }


            
        }

        [HttpPost, Route("salvarArquivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status500InternalServerError)]
        public IActionResult SalvarArquivo(IFormFile file)
        {
            try
            {
                var p = file;
                return Ok();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }



        }

        [HttpPost, Route("salvarArquivos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Erro), StatusCodes.Status500InternalServerError)]
        public IActionResult SalvarArquivos(IFormCollection files)
        {
            try
            {
                var p = files;
                return Ok();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }



        }
    }
}
