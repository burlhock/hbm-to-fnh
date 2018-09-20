using NHibernate.Cfg.MappingSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NHibernateHbmToFluent.Converter.Methods.Join
{
    public class Fetch
    {
        private readonly CodeFileBuilder _builder;

        public Fetch(CodeFileBuilder builder)
        {
            _builder = builder;
        }

        public void Add(HbmCollectionFetchMode? fetchType)
        {
            if (fetchType != null)
            {
                switch (fetchType)
                {
                    case HbmCollectionFetchMode.Subselect:
                        _builder.AddLine($".{FluentNHibernateNames.Fetch}.{FluentNHibernateNames.Subselect}()");
                        break;
                    case HbmCollectionFetchMode.Select:
                        // _builder.AddLine($".{FluentNHibernateNames.Fetch}.{FluentNHibernateNames.Select}()");
                        break;
                    case HbmCollectionFetchMode.Join:
                        _builder.AddLine($".{FluentNHibernateNames.Fetch}.{FluentNHibernateNames.Join}()");
                        break;
                }
            }
        }

        public static class FluentNHibernateNames
        {
            public static string Fetch
                => ReflectionUtility.GetPropertyName((FakeMap f) => f.HasMany<string>(x => x.ToLower()).Fetch);

            public static string Select
                => ReflectionUtility.GetMethodName((FakeMap f) => f.HasMany<string>(x => x.ToLower()).Fetch.Select());

            public static string Subselect
                => ReflectionUtility.GetMethodName((FakeMap f) => f.HasMany<string>(x => x.ToLower()).Fetch.Subselect());

            public static string Join
                => ReflectionUtility.GetMethodName((FakeMap f) => f.HasMany<string>(x => x.ToLower()).Fetch.Join());

        }
    }
}
