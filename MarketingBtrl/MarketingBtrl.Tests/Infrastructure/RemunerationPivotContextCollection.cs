using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MarketingBtrl.Tests.Infrastructure
{


    [CollectionDefinition("remuneration pivot collection")]
    public class RemunerationPivotContextCollection : ICollectionFixture<RemunerationPivotContextFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
