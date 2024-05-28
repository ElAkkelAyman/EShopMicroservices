using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    public interface ICommand : ICommand<Unit> // Unit represents void or empty type of the command in mediatR
    {
        
    }
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}
