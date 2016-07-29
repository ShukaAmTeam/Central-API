using System;
using System.Collections.Generic;

namespace API.Services.Assembler
{
    public abstract class Assembler<TDto, TEntity> where TEntity : class
    {
        public abstract TEntity DtoToDomainEntity(TDto dto);
        public abstract TDto DomainEntityToDto(TEntity tenancyDomainEntity);

        public List<TDto> DomainEntitiesToDtos(IEnumerable<TEntity> domainEntityList)
        {
            List<TDto> dtos = Activator.CreateInstance<List<TDto>>();
            foreach (TEntity domainEntity in domainEntityList)
            {
                dtos.Add(DomainEntityToDto(domainEntity));
            }
            return dtos;
        }

        //public MetaDataListEntity<TDto> DomainEntitiesToDtos(MetaDataList<TEntity> domainEntityList)
        //{
        //    var dtos = Activator.CreateInstance<MetaDataListEntity<TDto>>();
        //    dtos.Offset = domainEntityList.Offset;
        //    dtos.Limit = domainEntityList.Limit;
        //    dtos.TotalCount = domainEntityList.TotalCount;
        //    dtos.DataList = new List<TDto>();

        //    if (domainEntityList.DataList == null) return dtos;

        //    foreach (TEntity domainEntity in domainEntityList.DataList)
        //    {
        //        dtos.DataList.Add(DomainEntityToDto(domainEntity));
        //    }

        //    return dtos;
        //}

        public List<TEntity> DtosToDomainEntities(IEnumerable<TDto> dtoList)
        {
            List<TEntity> domainEntities = Activator.CreateInstance<List<TEntity>>();
            foreach (TDto dto in dtoList)
            {
                domainEntities.Add(DtoToDomainEntity(dto));
            }
            return domainEntities;
        }
    }
}
