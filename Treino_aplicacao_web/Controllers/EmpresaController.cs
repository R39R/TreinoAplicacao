using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Treino_aplicacao_web.Database;
using System.Data.Entity;
using Treino_aplicacao_web.ViewModel.Empresa;
using Treino_aplicacao_web.Models.Empresa;

namespace Treino_aplicacao_web.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        private readonly EmpresaDbContext _context;

        public EmpresaController() 
        {
            _context = new EmpresaDbContext();
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

        public async Task<ActionResult> Detalhes(int id) 
        {
            var empresa = await _context.Empresa.FirstOrDefaultAsync(i => i.Id == id);
            if (empresa == null) return HttpNotFound();

            var viewModel = new EmpresaDetalhesViewModel
            {
                Id = empresa.Id,
                Nome = empresa.Nome,
                CNPJ = empresa.CNPJ,
                Pais = empresa.Pais,
                Endereco = empresa.Endereco,
                NumeroDoEndereco = empresa.NumeroDoEndereco,
                CEP = empresa.CEP
            };

            return View(viewModel);
        }

        public ActionResult Criar()
        {
            return View(new EmpresaFormViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Criar(EmpresaFormViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var empresa = new Empresa
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                CNPJ = viewModel.CNPJ,
                Pais = viewModel.Pais,
                Endereco = viewModel.Endereco,
                NumeroDoEndereco= viewModel.NumeroDoEndereco,
                CEP = viewModel.CEP
            };

            _context.Empresa.Add(empresa);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Editar(int id)
        {
            var empresa = await _context.Empresa.FirstOrDefaultAsync(i => i.Id == id);
            if (empresa == null) return HttpNotFound();

            var viewModel = new EmpresaFormViewModel
            {
                Id = empresa.Id,
                Nome = empresa.Nome,
                CNPJ = empresa.CNPJ,
                Pais = empresa.Pais,
                Endereco = empresa.Endereco,
                NumeroDoEndereco = empresa.NumeroDoEndereco,
                CEP = empresa.CEP
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Editar(EmpresaFormViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var empresa = await _context.Empresa.SingleOrDefaultAsync(i => i.Id == viewModel.Id);
            if (empresa == null) return HttpNotFound();

            empresa.Nome = viewModel.Nome;
            empresa.CNPJ = viewModel.CNPJ;
            empresa.Pais = viewModel.Pais;
            empresa.Endereco = viewModel.Endereco;
            empresa.NumeroDoEndereco= viewModel.NumeroDoEndereco;
            empresa.CEP = viewModel.CEP;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Deletar(int id)
        {
            var empresa = await _context.Empresa.FirstOrDefaultAsync(i => i.Id == id);
            if (empresa == null) return HttpNotFound();

            var viewModel = new EmpresaDeletaViewModel
            {
                Id = id,
                Nome = empresa.Nome,
                CNPJ = empresa.CNPJ
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletarConfirmado(int id)
        {
            var empresa = await _context.Empresa.FirstOrDefaultAsync(i => i.Id == id);
            if (empresa == null) return HttpNotFound();

            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) 
        {
            if (disposing) 
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}