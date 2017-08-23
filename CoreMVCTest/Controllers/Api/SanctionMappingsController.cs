using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreMVCTest.Models.Repository.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreMVCTest.Controllers.API
{
    //[Authorize]
    [Route("api/SanctionMappings")]
    public class SanctionMappingsController : Controller
    {
        private readonly ISanctionMappingsRepository _repository;

        public SanctionMappingsController(ISanctionMappingsRepository repository)//, IDataProtectionProvider provider)
        {
            _repository = repository;
           // _protector = provider.CreateProtector(GetType().FullName);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetSubListDropdown")]
        public IActionResult GetSubListDropdown()
        {
            var result = _repository.GetSubLists();

            var returnObj = result.Select(item => new ViewModels.vmDowJonesSubList
            {
                ListCode = item.ListCode,
                Description = item.Description
            }).ToList();

            return Ok(returnObj);
        }

        [HttpGet("GetSanctions/{listcode}")]
        public IActionResult GetSubListSanctions(string listCode)
        {
            var result = _repository.SubListSanctionMappings(listCode);

            var returnObj = result.Select(item => new ViewModels.vmSanctionMappings
            {
                SanctionCode = item.SanctionCode,
                SanctionName = item.SanctionName,
                ListCode = listCode
            }).ToList();

            return Ok(returnObj);
        }

        [HttpDelete("DeleteSanction/{listcode}/{sanctionid}")]
        public IActionResult DeleteSanction(string listCode, int sanctionID)
        {
             _repository.DeleteSanctionFromSubList(listCode, sanctionID);
            return Ok();
        }
    }
}
