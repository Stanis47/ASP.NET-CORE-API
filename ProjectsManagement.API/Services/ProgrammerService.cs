using ProjectsManagement.API.Domain.Models;
using ProjectsManagement.API.Domain.Repositories;
using ProjectsManagement.API.Domain.Services;
using ProjectsManagement.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectsManagement.API.Services
{
    public class ProgrammerService : IProgrammerService
    {
        protected readonly IProgrammerRepository _programmerRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public ProgrammerService(IProgrammerRepository programmerRepository, IUnitOfWork unitOfWork)
        {
            _programmerRepository = programmerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Programmer>> ListAsync()
        {
            return await _programmerRepository.ListAsync();
        }

        public async Task<Programmer> GetOneAsync(int id)
        {
            return await _programmerRepository.FindByIdAsync(id);
        }

        public async Task<ProgrammerResponse> SaveAsync(Programmer programmer)
        {
            try
            {
                await _programmerRepository.AddAsync(programmer);
                await _unitOfWork.CompleteAsync();

                return new ProgrammerResponse(programmer);
            }
            catch (Exception ex)
            {
                return new ProgrammerResponse($"An error occurred when saving the programmer: {ex.Message}");
            }
        }

        public async Task<ProgrammerResponse> UpdateAsync(int id, Programmer programmer)
        {
            Programmer existingProgrammer = await _programmerRepository.FindByIdAsync(id);

            if (existingProgrammer == null)
            {
                return new ProgrammerResponse("Programmer not found.");
            }

            existingProgrammer.FirstName = programmer.FirstName;
            existingProgrammer.LastName = programmer.LastName;
            existingProgrammer.Email = programmer.Email;
            existingProgrammer.Phone = programmer.Phone;
            existingProgrammer.ImageUrl = programmer.ImageUrl;

            try
            {
                _programmerRepository.Update(existingProgrammer);
                await _unitOfWork.CompleteAsync();

                return new ProgrammerResponse(existingProgrammer);
            }
            catch (Exception ex)
            {
                return new ProgrammerResponse($"An error occurred when updating the programmer: {ex.Message}");
            }
        }

        public async Task<ProgrammerResponse> DeleteAsync(int id)
        {
            Programmer existingProgrammer = await _programmerRepository.FindByIdAsync(id);

            if (existingProgrammer == null)
            {
                return new ProgrammerResponse("Programmer not found");
            }

            try
            {
                _programmerRepository.Remove(existingProgrammer);
                await _unitOfWork.CompleteAsync();

                return new ProgrammerResponse(existingProgrammer);
            }
            catch (Exception ex)
            {
                return new ProgrammerResponse($"An error occurred when deleting the programmer: {ex.Message}");
            }
        }
    }
}
