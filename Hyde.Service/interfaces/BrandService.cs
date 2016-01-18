using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Domain.Model;
using Hyde.Result.Operation;
using Hyde.Repository;
using System.Data.Entity;
namespace Hyde.Service
{
    public class BrandService : IBrandService
    {
        IUnitOfWork unitofwork;
        IRepository<brandDto> brandRepo;

        public BrandService(IUnitOfWork UnitOfWork)
        {
            unitofwork = UnitOfWork;
            brandRepo = unitofwork.GetRepository<brandDto>();
        }

        public async Task<OperationResult> AddBrandAsync(IEnumerable<brandDto> items)
        {
            brandRepo.Add(items);

            await unitofwork.SaveAsync();

            return new OperationResult() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString() };
        }

        public async Task<OperationResult<List<brandDto>>> GerBrandListAsync()
        {
            var result = await brandRepo.Find().AsNoTracking().ToListAsync();

            return new OperationResult<List<brandDto>>() { err_code = ErrorEnum.success, err_info = ErrorEnum.success.ToString(), entity = result };

        }
    }
}
