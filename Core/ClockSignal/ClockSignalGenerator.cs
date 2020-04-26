namespace Core.ClockSignal
{
    public class ClockSignalGenerator
    {
        public int LowestA = 0;

        public ClockSignalGenerator()
        {
            var index = 1;
            var output = "";

            while (output != "0101010101")
            {
                output = "";
                var a = index;
                var b = 0;

                var d = a;
                var c = 4;
                
                do
                {
                    b = 633;

                    do
                    {
                        d++;
                        b--;
                    } while (b != 0);
                    
                    c--;
                } while (c != 0);
                
                row9: a = d;
                row10:
                b = a;
                a = 0;
                row13: c = 2;
                row14: if (b != 0) 
                    goto row16;
                goto row21;
                row16: b--;
                c--;
                if (c != 0)
                    goto row14;
                a++;
                goto row13;
                row21: b = 2;
                row22: if (c != 0) 
                    goto row24;
                goto row27;
                row24: b--;
                c--;
                goto row22;
                row27:
                output += b;
                if (output.Length == 10)
                    goto row31;
                if (a != 0) 
                    goto row10;
                goto row9;
                row31:
                LowestA = index;
                index++;
            }
        }
    }
}