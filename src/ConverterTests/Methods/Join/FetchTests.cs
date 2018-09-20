using NHibernate.Cfg.MappingSchema;
using NHibernateHbmToFluent.Converter;
using NHibernateHbmToFluent.Converter.Methods.Join;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConverterTests.Methods.Join
{
    public class FetchTests
    {
        [TestFixture]
        public class When_asked_for_a_FluentNHibernate_name
        {
            [Test]
            public void Should_return_the_correct_value_for_Fetch()
            {
                Fetch.FluentNHibernateNames.Fetch.ShouldBeEqualTo("Fetch");
            }

            [Test]
            public void Should_return_the_correct_value_for_Subselect()
            {
                Fetch.FluentNHibernateNames.Subselect.ShouldBeEqualTo("Subselect");
            }

            [Test]
            public void Should_return_the_correct_value_for_Join()
            {
                Fetch.FluentNHibernateNames.Join.ShouldBeEqualTo("Join");
            }

            [Test]
            public void Should_return_the_correct_value_for_Select()
            {
                Fetch.FluentNHibernateNames.Select.ShouldBeEqualTo("Select");
            }
        }

        [TestFixture]
        public class When_asked_to_Add_a_fetch_type
        {
            private CodeFileBuilder _builder;
            private Fetch _fetch;

            [SetUp]
            public void BeforEachTest()
            {
                _builder = new CodeFileBuilder();
                _fetch = new Fetch(_builder);
            }

            [Test]
            public void Should_generate_correct_code_given__subselect()
            {
                _fetch.Add(HbmCollectionFetchMode.Subselect);
                string result = _builder.ToString();
                result.ShouldBeEqualTo($".{Fetch.FluentNHibernateNames.Fetch}.{Fetch.FluentNHibernateNames.Subselect}");
            }

            [Test]
            public void Should_generate_correct_code_given__join()
            {
                _fetch.Add(HbmCollectionFetchMode.Join);
                string result = _builder.ToString();
                result.ShouldBeEqualTo($".{Fetch.FluentNHibernateNames.Fetch}.{Fetch.FluentNHibernateNames.Join}");
            }

            [Test]
            public void Should_generate_empty_code_given__selet()
            {
                _fetch.Add(HbmCollectionFetchMode.Select);
                string result = _builder.ToString();
                result.ShouldBeEqualTo(string.Empty);
            }
        }
    }
}
