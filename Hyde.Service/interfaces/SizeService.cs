using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain.Model;
using Hyde.Repository;
using Hyde.Result.Operation;
using Hyde.Service;
using System.Data.Entity;
namespace Hyde.Service
{
    public class SizeService : ISizeService
    {
        IUnitOfWork unitofwork;
        IRepository<sizeDto> sizeRepo;

        public SizeService(IUnitOfWork UnitOfWork)
        {
            unitofwork = UnitOfWork;
            sizeRepo = UnitOfWork.GetRepository<sizeDto>();
        }

        public async Task<OperationResult> AddSizeAsync(IEnumerable<sizeDto> items)
        {
            sizeRepo.Add(items);

            await unitofwork.SaveAsync();

            return new OperationResult { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString() };

        }

        public async Task<OperationResult<List<sizeDto>>> GetSizeListAsync()
        {
            var result = await sizeRepo.Find().AsNoTracking().ToListAsync();

            return new OperationResult<List<sizeDto>>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = result };
        }
    }
}
