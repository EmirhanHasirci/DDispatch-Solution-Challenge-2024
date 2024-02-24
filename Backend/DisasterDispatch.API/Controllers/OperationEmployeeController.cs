using DisasterDispatch.Core.Dtos.CustomOperationDtos;

using DisasterDispatch.Core.Dtos.OperationEmployeeDtos;
using DisasterDispatch.Core.Services;
using DisasterDispatch.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisasterDispatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationEmployeeController : CustomBaseController
    {
        private readonly IOperationEmployeeService _operationEmployeeService;

        public OperationEmployeeController(IOperationEmployeeService operationEmployeeService)
        {
            _operationEmployeeService = operationEmployeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetOperationEmployees()
        {
            return ActionResultInstance(await _operationEmployeeService.GetAllAsync());
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOperationEmployeesWithUser()
        {
            return ActionResultInstance(await _operationEmployeeService.GetOperationEmployeesWithCustomOperationAndUserAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOperationEmployeeById(string id)
        {
            return ActionResultInstance(await _operationEmployeeService.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddOperationEmployee(OperationEmployeeCreateDto createDto)
        {
            return ActionResultInstance(await _operationEmployeeService.AddOperationEmployeeAsync(createDto));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOperationEmployee(OperationEmployeeUpdateDto updateDto)
        {
            return ActionResultInstance(await _operationEmployeeService.UpdateOperationEmployeeAsync(updateDto));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOperationEmployee(string id)
        {
            return ActionResultInstance(await _operationEmployeeService.RemoveAsync(id));
        }
        [HttpGet("[action]/{userid}")]
        public async Task<IActionResult> ActiveOperation(string userid)
        {
            return ActionResultInstance(await _operationEmployeeService.ActiveOperation(userid));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> AddRange(List<OperationEmployeeCreateDto> operations)
        {
            return ActionResultInstance(await _operationEmployeeService.AddRange(operations));
        }
        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> OnMissionUsers(string id)
        {
            return ActionResultInstance(await _operationEmployeeService.OnMissionUsers(id));
        }
        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> GetOperationsByUser(string id)
        {
            return ActionResultInstance(await _operationEmployeeService.GetOperationsByUser(id));
        }
        


    }
}
