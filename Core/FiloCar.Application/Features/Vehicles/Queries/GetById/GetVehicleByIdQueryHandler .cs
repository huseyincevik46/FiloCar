﻿using FiloCar.Application.Exceptions;
using FiloCar.Application.Features.Vehicles.Rules;
using FiloCar.Application.Interface.AutoMapper;
using FiloCar.Application.Interface.Repositories;
using FiloCar.Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace FiloCar.Application.Features.Vehicles.Queries.GetById
{

    public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, GetVehicleByIdQueryResponse>
    {
        private readonly IReadRepository<Vehicle> _vehicleReadRepository;
        private readonly IMapper _mapper;
        private readonly VehicleRules _vehicleRules;

        public GetVehicleByIdQueryHandler(
            IReadRepository<Vehicle> vehicleReadRepository,
            IMapper mapper,
            VehicleRules vehicleRules)
        {
            _vehicleReadRepository = vehicleReadRepository ?? throw new ArgumentNullException(nameof(vehicleReadRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _vehicleRules = vehicleRules ?? throw new ArgumentNullException(nameof(vehicleRules));
        }

        public async Task<GetVehicleByIdQueryResponse> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
        {
            // Doğrulama
            request.Validate();

            // İptal kontrolü
            cancellationToken.ThrowIfCancellationRequested();

            try
            {
                var vehicle = await _vehicleReadRepository.GetAsync(
                    predicate: x => x.VehicleId == request.VehicleId,
                    include: source => source.Include(x => x.Departman));

                await _vehicleRules.VehicleShouldExistWhenSelected(vehicle);

                return _mapper.Map<GetVehicleByIdQueryResponse>(vehicle);
            }
            catch (Exception ex)
            {
                throw new BadRequestException("İşlem sırasında hata oluştu: " + ex.Message);
            }
        }
    }
}