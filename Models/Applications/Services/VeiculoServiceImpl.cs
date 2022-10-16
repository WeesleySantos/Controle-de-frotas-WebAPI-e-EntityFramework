using ControleDeFrotaWebApi.Models.Domain.Entities;
using ControleDeFrotaWebApi.Models.infrastructure.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeFrotaWebApi.Models.Applications.Services
{
    public class VeiculoServiceImpl : IVeiculoService
    {
        private readonly VeiculoRepositorio _veiculoRepositorio;
        public VeiculoServiceImpl(VeiculoRepositorio veiculoRepositorio)
        {
            _veiculoRepositorio = veiculoRepositorio;
        }
        public async Task Atualizar(Veiculo veiculo)
        {
            try
            {
               await _veiculoRepositorio.Atualizar(veiculo);
            }
            catch (Exception ex)
            {   

                throw ex;
            }
        }

        public async Task Cadastrar(Veiculo veiculo)
        {
            try
            {
                await _veiculoRepositorio.Cadastrar(veiculo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Excluir(string veiculoId)
        {
            try
            {
                await _veiculoRepositorio.Exlucir(veiculoId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<Veiculo>> Listar()
        {
            try
            {
               return await _veiculoRepositorio.Listar();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<List<Veiculo>> Listar2()
        {
          
            try
            {
               return await _veiculoRepositorio.Listar2();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Veiculo> Pesquisar(string veiculoId)
        {
            try
            {
              return  await _veiculoRepositorio.Pesquisar(veiculoId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
