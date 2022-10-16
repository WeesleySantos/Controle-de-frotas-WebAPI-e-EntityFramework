using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeFrotaWebApi.Models.Domain.Entities
{
    [Table("tbl_veicl")]
    public class Veiculo
    {
        [Column("veicl_id", TypeName = "varchar(50)")]
        public string VeiculoId { get; set; }

        [Column("modelo", TypeName = "varchar(100)")]
        public string Modelo { get; set; }

        [Column("placa", TypeName = "varchar(20)")]
        public string Placa { get; set; }

        [Column("ano", TypeName = "int")]
        public int Ano { get; set; }

        public IList<MotoristaVeiculo> Motoristas { get; set; }

        public Veiculo()
        {
            VeiculoId = string.IsNullOrEmpty(VeiculoId) ? BaseEntity.GenerateId() : string.Empty;
        }

    }
}
