using machine_api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace machine_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        public static IList<Machine> machineList = new List<Machine>{
            new Machine { Id = 1, Name = "Machine1" },
            new Machine { Id = 2, Name = "Machine2" },
            new Machine { Id = 3, Name = "Machine3" },
            new Machine { Id = 4, Name = "Machine4" },
            };
        [HttpGet]
        public IEnumerable<Machine> Get()
        {
            return machineList;
        }

        [HttpGet("{id:int}")]
        public Machine GetById(int id)
        {
            return machineList.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Create(Machine input)
        {
            machineList.Add(new Machine
            {
                Id = input.Id,
                Name = input.Name
            });
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(Machine input)
        {
            var item = machineList.Where(x => x.Id == input.Id).FirstOrDefault();
            machineList.Remove(item);
            machineList.Add(input);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var item = machineList.Where(x => x.Id == id).FirstOrDefault();
            machineList.Remove(item);
            return Ok();
        }

    }
}
