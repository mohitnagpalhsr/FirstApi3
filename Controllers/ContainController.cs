using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstApi2.Models;
using FirstApi2.ServiceLayer;

namespace FirstApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainController : ControllerBase
    {
        public static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ContainController));

        public static IContainService<Contain> containService;

        public ContainController(IContainService<Contain> _containService)
        {
            containService = _containService;
        }

        // GET: api/Contain
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contain>>> GetContains()
        {
            _log4net.Info("Get Contains method is called");
            return Ok(containService.GetAllContains());
        }

        // GET: api/Contain/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contain>> GetContain(int id)
        {
            _log4net.Info("Get Contain by id with" + id + "id is called");
            var contain = containService.GetContainById(id);
            if (contain == null)
            {
                _log4net.Info("No product is found with id:" + id);
            }
            return contain;
        }

        // PUT: api/Contain/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContain(int id, Contain contain)
        {
            containService.UpdateContain(id,contain);
            _log4net.Info("Product id" + id + "is updated");

            return Ok();
        }

        // POST: api/Contain
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contain>> PostContain(Contain contain)
        {
            containService.AddContain(contain);
            _log4net.Info("Product id" + contain.Pid + "is added");
            return Ok();
        }

        // DELETE: api/Contain/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContain(int id)
        {
            containService.RemoveContain(id);
            _log4net.Info("Product id" + id + "is removed");
            return Ok();
        }
    }
}
