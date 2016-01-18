using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain.Model;
using Hyde.Result.Operation;
using System.Data.Entity;
using Hyde.Repository;
namespace Hyde.Service.interfaces
{
    public class CategoryService : ICategroyService
    {
        IUnitOfWork unitofwork;
        IRepository<categoryDto> categoryRepo;

        public CategoryService(IUnitOfWork UnitOfWork)
        {
            unitofwork = UnitOfWork;
            categoryRepo = unitofwork.GetRepository<categoryDto>();
        }

        public async Task<OperationResult> AddCategoryAsync(IEnumerable<categoryDto> items)
        {
            categoryRepo.Add(items);

            await unitofwork.SaveAsync();

            return new OperationResult() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString() };
        }

        public async Task<OperationResult<List<categoryDto>>> GetCategoryAsync()
        {
            var result = await categoryRepo.Find().AsNoTracking().ToListAsync();

            return new OperationResult<List<categoryDto>>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = result };
        }
    }
}
