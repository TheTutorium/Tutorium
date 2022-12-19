using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tutorium.Models;
using tutorium.Exceptions;
using tutorium.Utils;
using tutorium.Services.FileService;
using tutorium.Data;
using tutorium.Dtos.MaterialDto;

namespace tutorium.Services.MaterialService
{
    public class MaterialService : IMaterialService
    {
        private readonly TutoriumContext _context;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public MaterialService(TutoriumContext context, IFileService fileService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<GetMaterialDto> CreateMaterial(CreateMaterialDto createMaterialDto)
        {

            Course? course = await _context.Courses
                .Include(c => c.Materials)
                .Where(c => c.Id == createMaterialDto.AffilatedCourseId)
                .FirstOrDefaultAsync();

            if (course == null)
            {
                throw new NotFoundException("There is no such course.");
            }
            if (course.AffilatedTutorId != Auth.GetUserId(_httpContextAccessor))
            {
                throw new UnauthorizedException("Tutor does not own the course.");
            }
            if (course.Materials.Any(material => material.FilePath == createMaterialDto.File.FileName))
            {
                throw new BadRequestException("Course has another material with the same file name.");
            }
            if (course.Materials.Any(material => material.DisplayName == createMaterialDto.DisplayName))
            {
                throw new BadRequestException("Course has another material with the same display name.");
            }
            if (Calculation.ConvertBytesToMegabytes(createMaterialDto.File.Length) > 15)
            {
                throw new BadRequestException("A file above 15MB cannot be uploaded.");
            }
            if (createMaterialDto.File.FileName.Length < 5)
            {
                throw new BadRequestException("File name cannot be smaller than 5.");
            }
            if (createMaterialDto.DisplayName.Length < 5)
            {
                throw new BadRequestException("Display name cannot be smaller than 5.");
            }


            string filePath = await _fileService.SaveFileAsync(course.Id, createMaterialDto.File, FileType.Material);

            Material newMaterial = new Material
            {
                CreatedAt = DateTime.UtcNow,
                Description = createMaterialDto.Description,
                DisplayName = createMaterialDto.DisplayName,
                FilePath = filePath,
                AffilatedCourseId = createMaterialDto.AffilatedCourseId
            };


            await _context.Materials.AddAsync(newMaterial);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetMaterialDto>(newMaterial);
        }


        public async Task DeleteMaterial(int materialId)
        {
            Material? material = await _context.Materials
                .Include(m => m.AffilatedCourse)
                .FirstOrDefaultAsync(m => m.Id == materialId);

            if (material == null)
            {
                throw new NotFoundException("No such material.");
            }
            if (material.AffilatedCourse.AffilatedTutorId != Auth.GetUserId(_httpContextAccessor))
            {
                throw new UnauthorizedException("The tutor does not have right to delete this material");
            }

            _fileService.DeleteFile(material.FilePath);

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
        }

        public async Task<GetMaterialDto> UpdateMaterial(int materialId, UpdateMaterialDto updateMaterialDto)
        {
            Material? material = await _context.Materials
                .Include(m => m.AffilatedCourse)
                .FirstOrDefaultAsync(m => m.Id == materialId);

            if (material == null)
                throw new NotFoundException("There is no such material.");
            if (material.AffilatedCourse.AffilatedTutorId != Auth.GetUserId(_httpContextAccessor))
                throw new BadRequestException("The tutor does not have right to update this material");
            if (material.AffilatedCourse.Materials.Any(material => (material.DisplayName == updateMaterialDto.DisplayName && material.Id != materialId)))
            {
                throw new BadRequestException("Course has another material with the same display name.");
            }
            if (updateMaterialDto.DisplayName != null && updateMaterialDto.DisplayName.Length < 5)
            {
                throw new BadRequestException("Display name cannot be smaller than 5.");
            }


            Patcher.Patch(material, updateMaterialDto);
            material.UpdatedAt = DateTime.UtcNow;

            _context.Materials.Update(material);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetMaterialDto>(material);
        }
    }
}
