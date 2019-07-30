using ProjectsManagement.API.Domain.Models;

namespace ProjectsManagement.API.Domain.Services.Communication
{
    public class ProgrammerResponse : BaseResponse
    {
        public Programmer Programmer { get; private set; }

        private ProgrammerResponse(bool success, string message, Programmer programmer) : base(success, message)
        {
            Programmer = programmer;
        }

        public ProgrammerResponse(Programmer programmer) : this(true, string.Empty, programmer) { }

        public ProgrammerResponse(string message) : this(false, message, null) { }
    }
}
   