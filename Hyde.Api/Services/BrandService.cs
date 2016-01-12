﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.Api.Models.RequestModels;
using PagedList;
using Hyde.Repository;
using Hyde.Domain.Model;
using Hyde.Api.Models.ResultModels;
using System.Xml.Serialization;


namespace Hyde.Api.Services
{
    public class BrandService : IBrandService
    {
        IRepository<brandDto> _BrandRepo;
        public BrandService(IRepository<brandDto> BrandRepo)
        {
            _BrandRepo = BrandRepo;
        }

        public OperationResult<brandDto> Add(brandDto Item)
        {

            _BrandRepo.Add(Item);

            _BrandRepo.UnitOfWork.Save();

            return new OperationResult<brandDto>(errstate.success, errstate.success.ToString()) { Entity = Item };

        }

        public OperationResult<brandDto> Edit(brandDto Item)
        {
            var Dto = FindSingleAsync(Item.key).Result;

            if (Dto == null)
            {
                return new OperationResult<brandDto>(errstate.key_not_found, errstate.key_not_found.ToString()) { Entity = Item };
            }

            Dto.enname = Item.enname;
            Dto.imgpath = Item.imgpath;
            Dto.shutout = Item.shutout;
            Dto.name = Item.name;
            _BrandRepo.UnitOfWork.Save();

            return new OperationResult<brandDto>(errstate.success, errstate.success.ToString()) { Entity = Dto };
        }

        public IPagedList<brandDto> Find(int PageIndex, int PageSize, bool? ShutOut = default(bool?))
        {
            var query = _BrandRepo.Find();

            if (ShutOut.HasValue)
                query = query.Where(t => t.shutout == ShutOut.Value);

            return query.OrderBy(t => t.key).ToPagedList(PageIndex, PageSize);

        }

        public async Task<brandDto> FindSingleAsync(int Key)
        {
            return await Task.Factory.StartNew(() => _BrandRepo.FindSingle(Key));
        }


    }
}
