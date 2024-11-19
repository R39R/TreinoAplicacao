using System;
using System.Numerics;

namespace Treino_aplicacao_web.Models.Empresa
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CNPJ { get; set; }
        public string Pais { get; set; }
        public string Endereco { get; set; }
        public int NumeroDoEndereco { get; set; }
        public int CEP { get; set; }
    }
}