using ControleDeFrotaWebApi.Models.Domain.Entities;
using ControleDeFrotaWebApi.Models.infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeFrotaWebApi.Models.infrastructure.repositories
{
    public class VeiculoRepositorioImpl : VeiculoRepositorio
    {
        private readonly ControleFrotaContext _context;
        public VeiculoRepositorioImpl(ControleFrotaContext contex)
        {
            _context = contex;
        }

        public async Task Cadastrar(Veiculo veiculo)
        {
            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Veiculo veiculo)
        {
            var atualizado = await Pesquisar(veiculo.VeiculoId);
            if (veiculo != null && !string.IsNullOrEmpty(veiculo.VeiculoId) && veiculo.VeiculoId.Equals(veiculo.VeiculoId))
            {
                atualizado.Modelo = veiculo.Modelo;
                atualizado.Ano = veiculo.Ano;
                atualizado.Placa = veiculo.Placa;

                _context.Veiculos.Update(atualizado);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Exlucir(string veiculoId)
        {
            var veiculo = await Pesquisar(veiculoId);
            if (veiculo != null && !string.IsNullOrEmpty(veiculo.VeiculoId) && veiculo.VeiculoId.Equals(veiculoId))
                _context.Veiculos.Remove(veiculo);
                 await _context.SaveChangesAsync();
        }

        public async Task<List<Veiculo>> Listar()
        {
            return await _context.Veiculos.ToListAsync();
        }

        public async Task<List<Veiculo>> Listar2()
        {
            var resultado = await _context.Veiculos
                .Include(m => m.Motoristas)
                .ThenInclude(v => v.Veiculo)
                .ToListAsync();

            foreach (var item in resultado)
            {
                foreach (var subitem in item.Motoristas)
                {
                    subitem.Motorista = _context.Motoristas.FirstOrDefault(m => m.MotoristaId.Equals(subitem.MotoristaId));
                }
            }

            return resultado;
        }

        public async Task<Veiculo> Pesquisar(string veiculoId)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(v => v.VeiculoId.Equals(veiculoId));
        }
    }
}
