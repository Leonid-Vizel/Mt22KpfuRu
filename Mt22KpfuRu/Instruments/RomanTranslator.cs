using System.Text;

namespace Mt22KpfuRu.Instruments
{
    public static class RomanTranslator
    {
        static RomanTranslator()
        {
            Numerals = new (int, string)[]
            {
                (1000, "M"),
                (900, "CM"),
                (500, "D"),
                (400, "CD"),
                (100, "C"),
                (90, "XC"),
                (50, "L"),
                (40, "XL"),   
                (10, "X"),
                (9, "IX"),
                (5, "V"),    
                (4, "IV"),
                (1, "I")
            };
        }
        private static  (int, string)[] Numerals { get; set; }
        public static string ToRoman(int number)
        {
            if (number == 0)
            {
                return "N";
            }
            StringBuilder romanBuulder = new StringBuilder();
            for (int i = 0; i < Numerals.Length; i++)
            {
                (int, string) numeralInfo = Numerals[i];
                while (number >= numeralInfo.Item1)
                {
                    number -= numeralInfo.Item1;
                    romanBuulder.Append(numeralInfo.Item2);
                }
            }
            return romanBuulder.ToString();
        }
    }
}
