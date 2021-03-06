using Aula08_crud_people_ef.Models;
using crud_people.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud_people.Controllers
{
    public class PersonController : Controller
    {
        private IPersonRepository _repository;    

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var people = _repository.GetAll();
            return View(people);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            _repository.Create(person);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {
            _repository.Update(person);
            return RedirectToAction("Index");
        }
       
    }
}