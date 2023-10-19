using Microsoft.AspNetCore.Mvc;
using Proj.Manager.Application.DTO.RequestModels.Membro;
using Proj.Manager.Application.DTO.ViewModels;
using Proj.Manager.Application.Services.Interfaces;
using Proj.Manager.Core.Entities;

namespace Proj.Manager.API.Controllers
{
    [Route("api/membro")]
    [ApiController]
    public class MembroController : ControllerBase
    {
        private readonly IMembroService _service;
        private readonly ITarefaService _tarefaService;
        private readonly IProjetoService _projetoService;
        public MembroController(
            IMembroService membroService,
            ITarefaService tarefaService,
            IProjetoService projetoService)
        {
            _service = membroService;
            _tarefaService = tarefaService;
            _projetoService = projetoService;

        }

        [HttpGet]
        [Route("listar")]
        public IActionResult ListaMembros()
        {
            try
            {
                return Ok(MembroViewModel.ListaDeMembros(_service.ListaMembros().ToList()));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            
        }

        [HttpGet]
        [Route("{id}/buscar")]
        public IActionResult BuscarMembro(Guid id)
        {
            try
            {
                return Ok(new MembroViewModel(_service.BuscarMembro(id)));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}/tarefas")]
        public IActionResult ListaTarefasMembro(Guid id)
        {
            try
            {
                return Ok(TarefaViewModel.ListaDeTarefas(_tarefaService.ListaTarefasMembro(id).ToList()));
            }
            catch (Exception ex)
            {
                return Problem($"Houve um problema ao tentar listar as tarefas do membro: {ex.Message}");
            }
           
        }

        [HttpGet]
        [Route("{id}/projetos")]
        public IActionResult ListarProjetosMembro(Guid id)
        {
            try
            {
                return Ok(ProjetoViewModel.ListaDeProjetos(_projetoService.ListarProjetosMembro(id).ToList()));
            }
            catch (Exception ex)
            {
                return Problem($"Houve um problema ao tentar listar os projetos do membro: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("criar")]
        public IActionResult CriarMembro(CriarMembroRequest request)
        {
            var membro = new Membro(
                request.Nome, 
                request.Email, 
                request.Senha, 
                request.Cargo);

            try
            {
                return Ok(new MembroViewModel(_service.CriarMembro(membro)));
            }
            catch (Exception ex)
            {
                return Problem($"Houve um problema ao tentar criar um novo membro: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public IActionResult AtualizarMembro(AtualizarMembroRequest request)
        {
            try
            {
                var membro = _service.BuscarMembro(request.Id);

                membro.Atualizar(request.Nome, request.Email);

                _service.AtualizarMembro(membro);

                return Ok("Alteração realizada");
            }
            catch (Exception ex)
            {
                return Problem($"Houve um problema ao tentar realizar a alteração: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("cargo/alterar")]
        public IActionResult AlterarCargo(AlterarCargoRequest request)
        {
            try
            {
                var membro = _service.BuscarMembro(request.Id);

                membro.AlterarCargo(request.Cargo);

                _service.AlterarCargo(membro);

                return Ok("Alteração realizada");
            }
            catch (Exception ex)
            {
                return Problem($"Houve um problema ao alterar o cargo: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("senha/alterar")]
        public IActionResult AlterarSenha(AlterarSenhaRequest request)
        {
            try
            {
                var membro = _service.BuscarMembro(request.Id);

                membro.AlterarSenha(request.NovaSenha);

                _service.AlterarSenha(membro);

                return Ok("Alteração realizada");
            }
            catch (Exception ex)
            {
                return Problem($"Houve um problema ao alterar a senha: {ex.Message}");
            }
        }
    }
}
