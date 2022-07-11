namespace BookStore.Application.Common.Mapping;

using System;
using AutoMapper;

public static class MappingExtensions
{
    public static IMappingExpression<TSource, TDestination> CreateMapWithBaseRules<TSource, TDestination>(
        this Profile mapper)
        => mapper
            .CreateMap<TSource, TDestination>()
            .IncludeAllDerived()
            .PreserveReferences();

    public static IMappingExpression CreateMapWithBaseRules(
        this Profile mapper,
        Type sourceType,
        Type destinationType)
        => mapper
            .CreateMap(sourceType, destinationType)
            .IncludeAllDerived()
            .PreserveReferences();

    public static IMappingExpression<TSource, TDestination> CreateMapAndReverseMapWithBaseRules<TSource, TDestination>(
        this Profile mapper)
    {
        var map = mapper
            .CreateMapWithBaseRules<TSource, TDestination>();

        map
            .ReverseMap()
            .IncludeAllDerived()
            .PreserveReferences();

        return map;
    }

    public static IMappingExpression CreateMapAndReverseMapWithBaseRules(
        this Profile mapper,
        Type sourceType,
        Type destinationType)
    {
        var map = mapper
            .CreateMapWithBaseRules(sourceType, destinationType);

        map
            .ReverseMap()
            .IncludeAllDerived()
            .PreserveReferences();

        return map;
    }
}