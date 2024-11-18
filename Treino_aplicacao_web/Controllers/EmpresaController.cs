using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Treino_aplicacao_web.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        private readonly EmpresaDbContext _context;

        public EmpresaController() 
        {
            _context = new EmpresaDbContext;
        }

        public async Task<ActionResult> Index()
        {
            return View(
                await _context.Empresa
                .Select(i => new EmpresaIndexViewModel
                {
                    Id = i.Id,
                    Nome = i.Nome,
                    CNPJ = i.CNPJ,
                    Pais = i.Pais,
                    Endereco = i.Endereco,
                    NumeroDoEndereco = i.NumeroDoEndereco,
                    CEP = i.CEP
                })
                .ToListAsync()
            );
        }
    }
}