﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using CA.Blocks.Application.Common.Dtos;


namespace CA.Blocks.Application.Common.Mappings;
//public static class MappingExtensions
//{
//    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
//        => PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);

//    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration) where TDestination : class
//        => queryable.ProjectTo<TDestination>(configuration).ToList();
//}