using tutorium.Dtos.WhiteboardSaveDto;

namespace tutorium.Services.WhiteboardSaveService
{
    public interface IWhitebaordSaveService
    {
        Task<GetWhiteboardSaveDto> CreateWhiteboardSave(CreateWhiteboardSaveDto createWhiteboardSaveDto);
        Task DeleteWhiteboardSave(int whiteboardSaveId);
    }
}
