using CarQuery__Test.Authentication.Services;
using CarQuery__Test.Domain.Models;
using CarQuery__Test.Domain.Services;
using CarQuery__Test.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarQuery__Test.Controllers
{
    [Route("Sale")]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        /// <summary>
        /// Filtra as 10 maiores vendas.
        /// </summary>
        /// <returns>Uma lista das 10 maiores vendas.</returns>
        /// <response code="200">Retorna a lista de maiores vendas.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Nenhuma venda encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [ProducesResponseType(typeof(IEnumerable<TopSales>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [HttpGet("TopSales")]
        public async Task<IActionResult> GetTopSales()
        {
            try
            {
                var sales = await _saleService.GetTopSalesAsync();
                return Ok(sales);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }


        /// <summary>
        /// Filtra as vendas com base nos critérios fornecidos.
        /// </summary>
        /// <param name="dthRegistroINI">Data de início do registro.</param>
        /// <param name="dthRegistroFIM">Data de fim do registro.</param>
        /// <param name="marcaCarro">Marca do carro.</param>
        /// <param name="idVendedor">ID do vendedor.</param>
        /// <param name="precoINI">Preço mínimo.</param>
        /// <param name="precoFIM">Preço máximo.</param>
        /// <returns>Uma lista de vendas que correspondem aos critérios.</returns>
        /// <response code="200">Retorna a lista de vendas.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Nenhuma venda encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("filter")]
        [ProducesResponseType(typeof(IEnumerable<Sale>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetSalesBy(DateTime? dthRegistroINI, DateTime? dthRegistroFIM, string? marcaCarro, int? idVendedor, decimal? precoINI, decimal? precoFIM)
        {
            try
            {
                var sales = await _saleService.GetSalesByAsync(dthRegistroINI, dthRegistroFIM, marcaCarro, idVendedor, precoINI, precoFIM);
                if (sales == null || !sales.Any())
                {
                    return NotFound("No sales found.");
                }
                return Ok(sales);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtém todas as vendas.
        /// </summary>
        /// <returns>Uma lista de todas as vendas.</returns>
        /// <response code="200">Retorna a lista de vendas.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Nenhuma venda encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Sale>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllSales()
        {
            try
            {
                var sales = await _saleService.GetAllSalesAsync();
                if (sales == null || !sales.Any())
                {
                    return NotFound("No sales found.");
                }
                return Ok(sales);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        /// Obtém uma venda pelo ID.
        /// </summary>
        /// <param name="id">ID da venda.</param>
        /// <returns>A venda correspondente ao ID.</returns>
        /// <response code="200">Retorna a venda solicitada.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Venda não encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Sale), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetSale(int id)
        {
            try
            {
                var sale = await _saleService.GetSaleByIdAsync(id);
                if (sale == null)
                {
                    return NotFound($"Sale not found.");
                }
                return Ok(sale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Cria uma nova venda.
        /// </summary>
        /// <param name="sale">O objeto venda a ser criado.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        /// <response code="200">Venda criada com sucesso.</response>
        /// <response code="400">Formato JSON inválido.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateSale([FromBody] Sale sale)
        {
            string role = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role);

            if (role.Equals("U"))
            {
                return BadRequest($"User without access");
            }

            try
            {
                var createdSale = await _saleService.CreateSaleAsync(sale);
                if (createdSale == null)
                {
                    return BadRequest("Invalid JSON format");
                }
                else
                {
                    return Ok($"Sale created successfully.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza uma venda existente.
        /// </summary>
        /// <param name="id">ID da venda a ser atualizada.</param>
        /// <param name="sale">O objeto venda com as novas informações.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        /// <response code="200">Venda atualizada com sucesso.</response>
        /// <response code="400">Formato JSON inválido.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Venda não encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateSale(int id, [FromBody] Sale sale)
        {
            string role = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role);

            if (role.Equals("U"))
            {
                return BadRequest($"User without access");
            }

            try
            {
                var updatedSale = await _saleService.UpdateSaleAsync(id, sale);
                if (updatedSale == null)
                {
                    return NotFound($"Failed to update sale.");
                }
                return Ok($"Sale updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui uma venda pelo ID.
        /// </summary>
        /// <param name="id">ID da venda a ser excluída.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        /// <response code="200">Venda excluída com sucesso.</response>
        /// <response code="400">Formato JSON inválido.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Venda não encontrada.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteSale(int id)
        {
            string role = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.Role);

            if (role.Equals("S") || role.Equals("U"))
            {
                return BadRequest($"User without access");
            }

            try
            {
                var result = await _saleService.DeleteSaleAsync(id);
                if (result == false)
                {
                    return NotFound($"Sale not found.");
                }
                return Ok($"Sale ID ({id}) deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
