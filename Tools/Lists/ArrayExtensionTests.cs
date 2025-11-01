namespace Pzl.Tools.Lists;

public class ArrayExtensionTests
{
    [Fact]
    public void IndexOf()
    {
        int[] list = [1, 2, 3];
        list.IndexOf(2).Should().Be(1);
    }
    
    [Fact]
    public void DeconstructWrongSize()
    {
        int[] list = [1, 2];
        Assert.Throws<ArgumentException>(() => {
            var (_, _, _) = list;
        });
    }
    
    [Fact]
    public void Deconstruct2Item()
    {
        int[] list = [1, 2];
        var (a, b) = list;
        (a, b).Should().Be((1, 2));
    }
    
    [Fact]
    public void Deconstruct3Items()
    {
        int[] list = [1, 2, 3];
        var (a, b, c) = list;
        (a, b, c).Should().Be((1, 2, 3));
    }

    [Fact]
    public void Deconstruct4Items()
    {
        int[] list = [1, 2, 3, 4];
        var (a, b, c, d) = list;
        (a, b, c, d).Should().Be((1, 2, 3, 4));
    }

    [Fact]
    public void Deconstruct5Items()
    {
        int[] list = [1, 2, 3, 4, 5];
        var (a, b, c, d, e) = list;
        (a, b, c, d, e).Should().Be((1, 2, 3, 4, 5));
    }
    
    [Fact]
    public void Deconstruct6Items()
    {
        int[] list = [1, 2, 3, 4, 5, 6];
        var (a, b, c, d, e, f) = list;
        (a, b, c, d, e, f).Should().Be((1, 2, 3, 4, 5, 6));
    }
    
    [Fact]
    public void Deconstruct7Items()
    {
        int[] list = [1, 2, 3, 4, 5, 6, 7];
        var (a, b, c, d, e, f, g) = list;
        (a, b, c, d, e, f, g).Should().Be((1, 2, 3, 4, 5, 6, 7));
    }
    
    [Fact]
    public void Deconstruct8Items()
    {
        int[] list = [1, 2, 3, 4, 5, 6, 7, 8];
        var (a, b, c, d, e, f, g, h) = list;
        (a, b, c, d, e, f, g, h).Should().Be((1, 2, 3, 4, 5, 6, 7, 8));
    }
    
    [Fact]
    public void Deconstruct9Items()
    {
        int[] list = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        var (a, b, c, d, e, f, g, h, i) = list;
        (a, b, c, d, e, f, g, h, i).Should().Be((1, 2, 3, 4, 5, 6, 7, 8, 9));
    }
    
    [Fact]
    public void Deconstruct10Items()
    {
        int[] list = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        var (a, b, c, d, e, f, g, h, i, j) = list;
        (a, b, c, d, e, f, g, h, i, j).Should().Be((1, 2, 3, 4, 5, 6, 7, 8, 9, 10));
    }
    
    [Fact]
    public void Deconstruct11Items()
    {
        int[] list = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11];
        var (a, b, c, d, e, f, g, h, i, j, k) = list;
        (a, b, c, d, e, f, g, h, i, j, k).Should().Be((1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11));
    }
}