using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Demo.application.Interfaces;
using Demo.domain.Entities;
using Demo.mvc.ViewModels;

namespace Demo.mvc.Controllers
{
    public class AlumnosController : Controller
    {

        private readonly IAlumnoAppService _alumnoAppService;

        public AlumnosController(IAlumnoAppService alumnoAppService)
        {
            _alumnoAppService = alumnoAppService;
        }


        // GET: Alumnos
        public ActionResult Index()
        {
            var alumnoViewModel = Mapper.Map<List<Alumno>, List<AlumnoViewModel>>(_alumnoAppService.GetAll());
            return View(alumnoViewModel);
        }

        public ActionResult Aprobados()
        {
            var alumnoViewModel = Mapper.Map<List<Alumno>, List<AlumnoViewModel>>(_alumnoAppService.Aprobados(_alumnoAppService.GetAll()));
            return View(alumnoViewModel);
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int id)
        {
            var alumnoViewModel = Mapper.Map<Alumno, AlumnoViewModel>(_alumnoAppService.GetById(id));
            return View(alumnoViewModel);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            ViewBag.Cursos = new SelectList(_alumnoAppService.ListarCursos(), "IdCurso", "Descripcion");
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(AlumnoViewModel alumno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Mapper.CreateMap<AlumnoViewModel, Alumno>();
                    var alumnoViewModel = Mapper.Map<Alumno>(alumno);
                    _alumnoAppService.Add(alumnoViewModel);
                    return RedirectToAction("Index");
                }
                ViewBag.Cursos = new SelectList(_alumnoAppService.ListarCursos(), "IdCurso", "Descripcion", alumno.IdCurso);
                return View(alumno);
            }
            catch
            {
                return View();
            }
        }



        private IEnumerable<SelectListItem> GetCursos()
        {
            var cursos = _alumnoAppService.ListarCursos()
                        .Select(x =>
                                new SelectListItem
                                {
                                    Value = x.IdCurso.ToString(),
                                    Text = x.Descripcion
                                });

            return new SelectList(cursos, "Value", "Text");
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int id)
        {
            var cursos = Mapper.Map<List<Curso>, List<CursoViewModel>>(_alumnoAppService.ListarCursos());
            var alumnoViewModel = Mapper.Map<Alumno, AlumnoViewModel>(_alumnoAppService.GetById(id));
            alumnoViewModel.Cursos = GetCursos();
            return View(alumnoViewModel);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(AlumnoViewModel alumno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Mapper.CreateMap<AlumnoViewModel, Alumno>();
                    var alumnoViewModel = Mapper.Map<Alumno>(alumno);
                    _alumnoAppService.Update(alumnoViewModel);
                    return RedirectToAction("Index");
                }
                ViewBag.Cursos = new SelectList(_alumnoAppService.ListarCursos(), "IdCurso", "Descripcion", alumno.IdCurso);
                return View(alumno);
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
