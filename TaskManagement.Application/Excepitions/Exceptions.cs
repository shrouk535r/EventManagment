using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Excepitions
{
    public abstract class AppException : Exception
    {
        public abstract int SatusCode { get; }

        protected AppException(string message) : base(message) { }
    }




    public sealed class BadRequestException : AppException
    {
        public BadRequestException(string message) : base(message) { }
        public override int SatusCode => 400;
    }


    public sealed class UnauthorizedException : AppException
    {
        public UnauthorizedException(string message) : base(message) { }
        public override int SatusCode => 401;
    }

    public sealed class ForbiddenException : AppException
    {
        public ForbiddenException(string operation) : base($"This User Not Allowed To {operation}") { }
        public override int SatusCode => 403;
    }
    public sealed class NotFoundException : AppException
    {
        public override int SatusCode => 404;
        public NotFoundException(string entity,Guid id ) : base($"The {entity} with this {id} Not Found") { }
        public NotFoundException(string message) : base(message) { }

    }


    public sealed class ConflictException : AppException
    {
        public ConflictException(string message) : base(message) { }
        public override int SatusCode => 409;
    }

    public sealed class InternalServerException : AppException
    {
        public InternalServerException() : base("An unhandled Internal Server Excepition") { }
        public override int SatusCode => 500;
    }

}
