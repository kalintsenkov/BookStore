namespace BookStore.Application.Common.Mapping;

using AutoMapper;

public interface IMapFrom<T>
{
    void Mapping(Profile mapper) => mapper.CreateMapWithBaseRules(typeof(T), this.GetType());
}