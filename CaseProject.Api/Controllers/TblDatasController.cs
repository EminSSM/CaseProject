using DataAccess.Abstract;
using Entitities;
using Microsoft.AspNetCore.Mvc;

namespace CaseProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblDatasController : ControllerBase
    {
        ITblDataRepository _tblData;

        public TblDatasController(ITblDataRepository tblData)
        {
            _tblData = tblData;
        }

        [HttpGet]
        public IActionResult GetAllData()
        {
            return Ok(_tblData.GetAllDatas());
        }

        [HttpGet("{id}")]
        public IActionResult GetData(int id) 
        {
            var data = _tblData.GetByIdData(id);
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateData(TblData tblData)
        {
           _tblData.Add(tblData);
            return Created();
        }

        [HttpPut]
        public IActionResult UpdateData(TblData tblData)
        {
            if (_tblData.GetByIdData(tblData.Id) != null)
            {
                
                return Ok();
            }
            return NotFound();
        }
    }
}
