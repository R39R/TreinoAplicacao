using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Treino_aplicacao_web.ViewModel.Empresa
{
    public class EmpresaDetalhesViewModel
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