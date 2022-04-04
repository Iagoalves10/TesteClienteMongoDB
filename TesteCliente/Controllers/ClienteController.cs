using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteCliente.Model;
using TesteCliente.Service;

namespace TesteCliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]

        public async Task<List<Cliente>> GetClientes() =>
            await _clienteService.GetAsync();

       
        [HttpPost]

        public async Task<Cliente> PostClientes(Cliente cliente)
        {
            await _clienteService.CreateAsync(cliente);

            return cliente;
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var cliente = await _clienteService.GetAsync(id);

            if (cliente is null)
            {
                return NotFound("cliente não encontrado");
            }

            await _clienteService.DeleteAsync(cliente);

            return Ok("Cliente Exluido ");
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Cliente cliente)
        {
            var clientenovo = await _clienteService.GetAsync(id);

            if (cliente is null)
            {
                return NotFound();
            }

            cliente.Id = cliente.Id;

            await _clienteService.UpdateAsync(id, cliente);

            return Ok("Cliente atualizado");
        }
    }

}

