using AutoMapper;
using Store.API.Helpers;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Services.Mapping.Dto_s;

namespace Store.Services.Services.StoreTypeService
{
    public class StoreTypeService : IStoreTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<StoreTypeDto> CreateStoreTypeAsync(StoreTypeDto storeTypeDto)
        {
            if (storeTypeDto == null)
                throw new ArgumentNullException("Not Found");
            try
            {
                var type = _mapper.Map<StoreType>(storeTypeDto);
                type.Icon_path = UploadFiles.UploadFile(storeTypeDto.Image, "Icons");
                await _unitOfWork.StoreTypes.AddAsync(type);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<StoreTypeDto>(type);
            }
            catch (Exception ex)
            {

                throw new Exception("Creating Failed", ex);
            }
        }

        public async Task<StoreTypeDto> DeleteStoreTypeAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is null");
            try
            {
                var type = await _unitOfWork.StoreTypes.GetByIdAsync(Id);
                if (type == null)
                    throw new Exception("Type Not Found");
                await _unitOfWork.StoreTypes.DeleteAsync(type);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<StoreTypeDto>(type);
            }
            catch (Exception ex)
            {

                throw new Exception("Delete Failed", ex);
            }
        }

        public async Task<IEnumerable<StoreTypeDto>> GetAllStoreTypeAsync()
        {
            var type = await _unitOfWork.StoreTypes.GetAllAsync();
            return _mapper.Map<IEnumerable<StoreTypeDto>>(type);
        }

        public async Task<StoreTypeDto> GetStoreTypeByIdAsync(int? Id)
        {
            if (Id is null)
                throw new ArgumentNullException("Id is null");
            try
            {
                var type = await _unitOfWork.StoreTypes.GetByIdAsync(Id);
                if (type == null)
                    throw new Exception("Not Found");
                return _mapper.Map<StoreTypeDto>(type);
            }
            catch (Exception ex)
            {

                throw new Exception("Type Not Found", ex);
            }
        }

        public async Task<StoreTypeDto> UpdateStoreTypeAsync(int? id, StoreTypeDto storeTypeDto)
        {
            if (storeTypeDto == null)
                throw new ArgumentNullException(nameof(storeTypeDto), "StoreTypeDto cannot be null.");
            try
            {
                var type = await _unitOfWork.StoreTypes.GetByIdAsync(id);
                if (type == null)
                    throw new KeyNotFoundException($"StoreType with Id {id} not found.");
                _mapper.Map(storeTypeDto, type);
                await _unitOfWork.StoreTypes.UpdateAsync(type);
                await _unitOfWork.SaveChanges();
                return _mapper.Map<StoreTypeDto>(type);
            }
            catch (Exception ex)
            {
                throw new Exception("Update Failed", ex);
            }  
        }
    }
}
