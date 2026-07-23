using Sense.Application.DomainEntities;
using Sense.Application.DTOs.ApplicationUserDTOs;
using Sense.Application.DTOs.ProductDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sense.Application.UseCases.ApplicationUser.Commands.UploadUserImageCommand
{
    public class UploadUserImageCommand : IRequest<ResponseResult<string>>
    {
        public UploadUserImageDto? Dto { get; set; }

    }
}
