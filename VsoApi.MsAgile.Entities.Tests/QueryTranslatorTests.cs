using VsoApi.MsAgile.Entities.Mappings;

namespace VsoApi.MsAgile.Entities.Tests
{
    using System;
    using System.Linq.Expressions;
    using NUnit.Framework;
    using VsoApi.MsAgile.Entities.Linq;

    [TestFixture]
    public class QueryTranslatorTests
    {
        [Test]
        public void Translate_Simple_Where_Clause()
        {
            Mapping.Configure();

            QueryTranslator translator = new QueryTranslator();
            Expression<Func<UserStory, bool>> expression = story => story.Id == 1;
            
            string result = translator.Translate(expression);
            Assert.That(result, Is.Not.Null);
        }
    }
}