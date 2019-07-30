using ProjectsManagement.API.Domain.Models;
using ProjectsManagement.API.Domain.Repositories;
using ProjectsManagement.API.Domain.Services;
using ProjectsManagement.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectsManagement.API.Services
{
    public class ProjectService : IProjectService
    {
        protected readonly IProjectRepository _projectRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Project>> ListAsync()
        {
            return await _projectRepository.ListAsync();
        }

        public async Task<Project> GetOneAsync(int id)
        {
            return await _projectRepository.FindByIdAsync(id);
        }

        public async Task<ProjectResponse> SaveAsync(Project project)
        {
            try
            {
                await _projectRepository.AddAsync(project);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(project);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error occurred when saving the project: {ex.Message}");
            }
        }

        public async Task<ProjectResponse> UpdateAsync(int id, Project project)
        {
            Project existingProject = await _projectRepository.FindByIdAsync(id);

            if (existingProject == null)
            {
                return new ProjectResponse("Project not found.");
            }

            existingProject.Name = project.Name;
            existingProject.Description = project.Description;
            existingProject.FullDescription = project.FullDescription;
            existingProject.IsCompleted = project.IsCompleted;
            if (project.Programmers.Count > 0)
            {
                existingProject.Programmers = project.Programmers;
            }

            try
            {
                _projectRepository.Update(existingProject);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(existingProject);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error occurred when updating the project: {ex.Message}");
            }
        }

        public async Task<ProjectResponse> DeleteAsync(int id)
        {
            Project existingProject = await _projectRepository.FindByIdAsync(id);

            if (existingProject == null)
            {
                return new ProjectResponse("Project not found");
            }

            try
            {
                _projectRepository.Remove(existingProject);
                await _unitOfWork.CompleteAsync();

                return new ProjectResponse(existingProject);
            }
            catch (Exception ex)
            {
                return new ProjectResponse($"An error occurred when deleting the project: {ex.Message}");
            }
        }
    }


}
