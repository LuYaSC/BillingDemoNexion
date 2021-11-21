using AutoMapper;
using BasicBilling.API.Context.Entities;
using BasicBilling.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BasicBilling.API.Business.Parameters
{
    public class ParameterBusiness<CONTEXT, ENTITY> : IParameterBusiness<ENTITY>
        where ENTITY : BaseLogicalDelete, IDescription, new()
        where CONTEXT : DbContext
    {
        CONTEXT context;
        IMapper mapper;

        public ParameterBusiness(CONTEXT context)
        {
            this.context = context;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ENTITY, ParameterResult>()
                    .ForMember(d => d.State, o => o.MapFrom(s => s.IsDeleted))
                    .ForMember(d => d.StateDescription, o => o.MapFrom(s => s.IsDeleted ? "Disabled" : "Enabled"))
                    .ForMember(d => d.Code, o => o.MapFrom(s => s.Id));
            });
            mapper = new Mapper(config);
        }

        public Result<string> Create(ParameterDto dto)
        {
            var parameter = GetList().Where(x => x.Name == dto.Name.ToUpper()).FirstOrDefault();
            if (parameter != null) return Result<string>.SetError("Exists, Please Check");

            context.Set<ENTITY>().Add(new ENTITY() { Name = dto.Name.ToUpper(), DateCreation = DateTime.Now, IsDeleted = false });
            context.SaveChanges();
            return Result<string>.SetOk("Success");
        }

        public Result<string> Update(ParameterDto dto)
        {
            var parameter = GetList().Where(x => x.Id == dto.Code).FirstOrDefault();
            if (parameter == null) return Result<string>.SetError("No records found");
            if (parameter.Name == dto.Name.ToUpper()) return Result<string>.SetError("Same Name please check");
            parameter.Name = dto.Name.ToUpper();
            parameter.DateModification = DateTime.Now;
            context.SaveChanges();
            return Result<string>.SetOk("Success");
        }

        public Result<string> Delete(ParameterDto dto)
        {
            var parameter = GetList().Where(x => x.Id == dto.Code).FirstOrDefault();
            if (parameter == null) return Result<string>.SetError("No records found");
            parameter.IsDeleted = dto.State;
            parameter.DateModification = DateTime.Now;
            context.SaveChanges();
            return Result<string>.SetOk($"{(!dto.State ? "Enabled" : "Disabled")} Success"); ;
        }

        public Result<List<ParameterResult>> Get()
        {
            var list = GetList().ToList();
            return list.Any() ? Result<List<ParameterResult>>.SetOk(mapper.Map<List<ParameterResult>>(list)) : Result<List<ParameterResult>>.SetError("No records found");
        }

        private IEnumerable<ENTITY> GetList() => context.Set<ENTITY>();
    }
}
