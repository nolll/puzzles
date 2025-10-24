namespace Pzl.Aquaq.Puzzles.Aquaq17;

public class Aquaq17Tests
{
    private const string Input = """
                                 date,home_team,away_team,home_score,away_score,tournament,city,country,neutral
                                 1900-01-01,Somaliland,Other1,1,0,_,_,_,_
                                 1900-01-01,Formosa,Other2,0,1,_,_,_,_
                                 1900-01-01,Ganoa,Other3,1,0,_,_,_,_
                                 1900-01-02,Genoa,Other4,0,1,_,_,_,_
                                 1900-01-03,Somaliland,Other5,0,1,_,_,_,_
                                 1900-01-03,Genoa,Other6,0,1,_,_,_,_
                                 1900-01-06,Genoa,Other7,0,1,_,_,_,_
                                 1901-01-21,Other8,Genoa,0,1,_,_,_,_
                                 1902-01-01,Other9,Somaliland,0,1,_,_,_,_
                                 """;

    [Fact]
    public void FindShame()
    {
        var result = Aquaq17.RunInternal(Input);

        result.Should().Be("Somaliland 19000103 19020101");
    }
}