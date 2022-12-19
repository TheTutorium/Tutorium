using AutoMapper;
using Microsoft.EntityFrameworkCore;
using tutorium.Models;
using tutorium.Exceptions;
using tutorium.Utils;
using tutorium.Data;
using tutorium.Dtos.WhiteboardSaveDto;
using tutorium.Services.FileService;

namespace tutorium.Services.WhiteboardSaveService
{
    public class WhiteboardSaveService : IWhitebaordSaveService
    {
        private readonly TutoriumContext _context;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public WhiteboardSaveService(TutoriumContext context, IFileService fileService, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<GetWhiteboardSaveDto> CreateWhiteboardSave(CreateWhiteboardSaveDto createWhiteboardSaveDto)
        {

            Booking? booking = await _context.Bookings
                .Include(b => b.AffilatedCourse)
                .Where(b => b.Id == createWhiteboardSaveDto.AffilatedBookingId)
                .FirstOrDefaultAsync();

            if (booking == null)
            {
                throw new NotFoundException("There is no such booking.");
            }
            if (booking.AffilatedCourse.AffilatedTutorId != Auth.GetUserId(_httpContextAccessor))
            {
                throw new UnauthorizedException("Tutor does not own the booking.");
            }
            if (Calculation.ConvertBytesToMegabytes(createWhiteboardSaveDto.File.Length) > 15)
            {
                throw new BadRequestException("A file above 15MB cannot be uploaded.");
            }

            string filePath = await _fileService.SaveFileAsync(booking.Id, createWhiteboardSaveDto.File, FileType.WhiteboardSave);
            WhiteboardSave newWhiteboardSave = new WhiteboardSave
            {
                SavePath = filePath,
                SaveTime = DateTime.UtcNow,
                AffilatedBookingId = createWhiteboardSaveDto.AffilatedBookingId
            };


            await _context.WhiteboardSaves.AddAsync(newWhiteboardSave);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetWhiteboardSaveDto>(newWhiteboardSave);
        }


        public async Task DeleteWhiteboardSave(int whiteboardSaveId)
        {
            WhiteboardSave? whiteboardSave = await _context.WhiteboardSaves
                .Include(w => w.AffilatedBooking)
                .ThenInclude(b => b.AffilatedCourse)
                .FirstOrDefaultAsync(w => w.Id == whiteboardSaveId);

            if (whiteboardSave == null)
            {
                throw new NotFoundException("No such whiteboard save.");
            }
            if (whiteboardSave.AffilatedBooking.AffilatedCourse.AffilatedTutorId != Auth.GetUserId(_httpContextAccessor))
            {
                throw new UnauthorizedException("The tutor does not have right to delete this whiteboard save");
            }

            _fileService.DeleteFile(whiteboardSave.SavePath);

            _context.WhiteboardSaves.Remove(whiteboardSave);
            await _context.SaveChangesAsync();
        }
    }
}
