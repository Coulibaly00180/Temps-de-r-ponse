using Microsoft.AspNetCore.Mvc;
using Temps.DTO;
using Temps.SRV;

namespace Temps.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachineController : Controller
    {
        private IMachine_SRV<Machine_DTO> srv;

        public MachineController(IMachine_SRV<Machine_DTO> service)
        {
            srv = service;
        }

        [HttpPost("create")]
        public Machine_DTO Ajouter([FromBody]Machine_DTO machine_DTO) 
        { 
            return srv.Ajouter(machine_DTO);
        }

        [HttpPut("update/{id}")]
        public Machine_DTO Modifier([FromBody] Machine_DTO machine_DTO, int id)
        {
            return srv.Modifier(machine_DTO);
        }

        [HttpPatch("updateSignal/{id}")]
        public Machine_DTO UpdateSignal([FromBody] Machine_DTO machine_DTO, int id)
        {
            return srv.ModifierSignal(machine_DTO);
        }

        [HttpGet("show/{id}")]
        public Machine_DTO GetById(int id)
        {
            return srv.GetById(id);
        }

        [HttpGet("showAll")]
        public IEnumerable<Machine_DTO> GetAll()
        {
            return srv.GetAll();
        }

        [HttpDelete("delete/{id}")]
        public void Supprimer(int id)
        {
            srv.Supprimer(id);
        }
    }
}
