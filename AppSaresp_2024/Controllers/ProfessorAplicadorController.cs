using AppSaresp_2024.Models;
using AppSaresp_2024.Repository;
using AppSaresp_2024.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AppSaresp_2024.Controllers
{
    public class ProfessorAplicadorController : Controller
    {
        private IProfessorAplicador _professorAplicador;

        public ProfessorAplicadorController (IProfessorAplicador professorAplicador)
        {
            _professorAplicador = professorAplicador;
        }
        public IActionResult Index()
        {
            return View(_professorAplicador.ObterTodosProfessores());
        }
        [HttpGet]
        public IActionResult CadastrarProfessor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarProfessor(ProfessorAplicador professorAplicador)
        {
            if (ModelState.IsValid)
            {
                _professorAplicador.Cadastrar(professorAplicador);
            }
            return View();
        }
    }
}
