using FiloCar.Application.Features.Vehicles.Commands.CreateVehicle;
using FiloCar.Application.Features.Vehicles.Commands.RemoveVehicle;
using FiloCar.Application.Features.Vehicles.Commands.UpdateVehicle;
using FiloCar.Application.Features.Vehicles.Queries.GetAllVehicle;
using FiloCar.Application.Features.Vehicles.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiloCar.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-vehicle")]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("remove-vehicle/{id}")]
        public async Task<IActionResult> RemoveVehicle(int id)
        {
            var request = new RemoveVehicleCommandRequest { VehicleId = id };
            await _mediator.Send(request);
            return Ok(new { Message = "Vehicle removed successfully." });
        }

        [HttpPut("update-vehicle")]
        public async Task<IActionResult> UpdateVehicle([FromBody] UpdateVehicleCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok(new { Message = "Vehicle updated successfully." });
        }

        [HttpGet("get-all-vehicle")]
        public async Task<IActionResult> GetAllVehicle(
           
            [FromQuery] int? departmanId,
            [FromQuery] string? fuelType,
             [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 3
            )
        {
            var query = new GetAllVehicleQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                DepartmanId = departmanId,
                FuelType = fuelType
            };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("get-vehiclebyId/{id}")]
        public async Task<IActionResult> GetVehicleById([FromRoute] int id)
        {
            var query = new GetVehicleByIdQuery { VehicleId = id };
            var response = await _mediator.Send(query);
            return Ok(response);
        }

    }
}
