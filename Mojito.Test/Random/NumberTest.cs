using System.Collections;

namespace Mojito.Test.Random;

public class NumberTest
{
    [Test]
    public void TestCreate()
    {
        var value = Mojito.Random.Number.Create(0, 10);
        var expectedMember = new ArrayList { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Assert.That(expectedMember, Has.Member(value));
    }
}
