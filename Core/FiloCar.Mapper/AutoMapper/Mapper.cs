﻿
using AutoMapper;
using AutoMapper.Internal;

namespace FiloCar.Mapper.AutoMapper
{
    public class Mapper :  Application.Interface.AutoMapper.IMapper
    {
        public static List<TypePair> typePairs = new();

        private IMapper MapperContainer;
        public Mapper(IMapper mapper)
        {
            MapperContainer = mapper;
        }
        public TDestination Map<TDestination, TSource>(TSource source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);

            return MapperContainer.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null)
        {
            Config<TDestination, TSource>(5, ignore);

            return MapperContainer.Map<IList<TSource>, IList<TDestination>>(source);
        }

        public TDestination Map<TDestination>(object source, string? ignore = null)
        {
            var sourceType = source.GetType();
            var destinationType = typeof(TDestination);
            var typePair = new TypePair(sourceType, destinationType);

            if (typePairs.Any(x => x.SourceType == typePair.SourceType && x.DestinationType == typePair.DestinationType) && ignore is null)
                return MapperContainer.Map<TDestination>(source);

            typePairs.Add(typePair);

            var config = new MapperConfiguration(cfg => {
                foreach (var item in typePairs)
                {
                    if (ignore is not null)
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(5).ForMember(ignore, x => x.Ignore()).ReverseMap();
                    else
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(5).ReverseMap();
                }
            });

            MapperContainer = config.CreateMapper();
            return MapperContainer.Map<TDestination>(source);
        }

        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            Config<TDestination, TSource>();
            MapperContainer.Map(source, destination);
        }


        public IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null)
        {
            Config<TDestination, IList<object>>(5, ignore);

            return MapperContainer.Map<IList<TDestination>>(source);
        }


        protected void Config<TDestination, TSource>(int dept = 5, string? ignore = null)
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestination));

            if (typePairs.Any(x => x.DestinationType == typePair.DestinationType && x.SourceType == typePair.SourceType) && ignore is null)
                return;

            typePairs.Add(typePair);

            var config = new MapperConfiguration(cfg => {
                foreach (var item in typePairs)
                {
                    if (ignore is not null)
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(dept).ForMember(ignore, x => x.Ignore()).ReverseMap();
                    else
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(dept).ReverseMap();
                }
            });

            MapperContainer = config.CreateMapper();
        }
    }
}
