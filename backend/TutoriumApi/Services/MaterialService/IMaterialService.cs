using tutorium.Dtos.MaterialDto;

namespace tutorium.Services.MaterialService
{
    public interface IMaterialService
    {
        Task<GetMaterialDto> CreateMaterial(CreateMaterialDto createMaterialEndDto);
        Task DeleteMaterial(int materialId);
        Task<GetMaterialDto> UpdateMaterial(int materialId, UpdateMaterialDto updateMaterialEndDto);
    }
}
