using ControleDeFrotaWebApi.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeFrotaWebApi.Models.Applications.Services
{
   public interface IVeiculoService
    {
        Task Cadastrar(Veiculo veiculo);
        Task Atualizar(Veiculo veiculo);
        Task Excluir(string veiculoId);
        Task<Veiculo> Pesquisar(string veiculoId);
        Task<List<Veiculo>> Listar();
        Task<List<Veiculo>> Listar2();
    }
}
