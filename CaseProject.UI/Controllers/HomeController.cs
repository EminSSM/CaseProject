using CaseProject.UI.Models;
using DataAccess.Abstract;
using Entitities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CaseProject.UI.Controllers
{
    public class HomeController : Controller
    {

        private readonly ITblDataRepository _tblDataRepository;

        public HomeController(ITblDataRepository tblDataRepository)
        {
            _tblDataRepository = tblDataRepository;
        }

        public IActionResult Index()
        {
           var data = _tblDataRepository.GetAllDatas();
            return View(data);
        }
        
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(TblData data)
        {
            _tblDataRepository.Add(data);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var data = _tblDataRepository.GetByData(x=>x.Id==id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(TblData data)
        {
            _tblDataRepository.Update(data);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            _tblDataRepository.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult BirthDatePersonCount()
        {
            var model = _tblDataRepository.GetAllDatas(); 
            return View(model);
        }
        public IActionResult CreatedDateFilter(DateTime? date)
        {
            IEnumerable<TblData> data;

            if (date.HasValue)
            {
                data = _tblDataRepository.GetAllDatas().Where(x => x.CreatedDate.Date == date.Value.Date);
            }
            else
            {
                data = _tblDataRepository.GetAllDatas();
            }

            return View(data);
        }

    }
}
