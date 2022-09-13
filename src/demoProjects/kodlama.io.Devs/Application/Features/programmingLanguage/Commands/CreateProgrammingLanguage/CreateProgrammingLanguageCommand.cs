using Application.Features.programmingLanguage.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.programmingLanguage.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand:IRequest<CreatedProgrammingLanguageDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingLanguageCommandHandler: IRequestHandler<CreateProgrammingLanguageCommand,CreatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public CreateProgrammingLanguageCommandHandler( IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository= programmingLanguageRepository;
                _mapper=mapper; 
            }

            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {

                ProgrammingLanguage mappedProgramminLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createdProgrammingLanguage = await _programmingLanguageRepository.AddAsync(mappedProgramminLanguage) ;
                CreatedProgrammingLanguageDto createdSomeFeatureEntityDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdProgrammingLanguage);
                return createdSomeFeatureEntityDto;
            }
        }
    }
}
