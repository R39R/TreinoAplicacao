using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Treino_aplicacao_web.ViewModel.Empresa
{
    public class EmpresaFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public int CNPJ { get; set; }

        [Required]
        [StringLength(30)]
        public string Pais { get; set; }

        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }

        [Required]
        public int NumeroDoEndereco { get; set; }

        [Required]
        public int CEP { get; set; }
    }
}