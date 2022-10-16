using ControleDeFrotaWebApi.Models.Applications.Services;
using ControleDeFrotaWebApi.Models.Domain.Dto;
using ControleDeFrotaWebApi.Models.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeFrotaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }
        [HttpGet]
        [Route("listar")]
        public async Task<List<Veiculo>> Listar()
        {
            try
            {
                return await _veiculoService.Listar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<string> Cadastrar([FromBody] VeiculoDto veiculo)
        {
            try
            {
                var entidade = veiculo.ConverterParaEntidade();
                await _veiculoService.Cadastrar(entidade);
                return "Cadastro efetuado com sucesso!";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("listar2")]
        public async Task<List<Veiculo>> Listar2()
        {
            try
            {
                return await _veiculoService.Listar2();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<string> Atualizar([FromBody]VeiculoDto veiculo)
        {
            try
            {
                var entidade = veiculo.ConverterParaEntidade();
                await _veiculoService.Atualizar(entidade);
                return "Atualização efetuada com sucesso!";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [Route("pesquisar/{id}")]
        public async Task<Veiculo> Pesquisar(string id)
        {
            try
            {
                return await _veiculoService.Pesquisar(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<string> Excluir(string id)
        {
            try
            {
                 await _veiculoService.Excluir(id);
                return "Exlusão efetuada com sucesso!";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

