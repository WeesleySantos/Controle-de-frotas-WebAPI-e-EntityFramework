using ControleDeFrotaWebApi.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeFrotaWebApi.Models.Domain.Dto
{
    public class VeiculoDto
    {
        public string VeiculoId { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public VeiculoDto()
        {

        }

        public Veiculo ConverterParaEntidade()
        {
            var novoVeiculo = new Veiculo();
            novoVeiculo.VeiculoId = !string.IsNullOrEmpty(this.VeiculoId) ? this.VeiculoId : BaseEntity.GenerateId();
            novoVeiculo.Modelo = this.Modelo;
            novoVeiculo.Placa = this.Placa;
            novoVeiculo.Ano = this.Ano;

            return novoVeiculo;
        }
    }
}
