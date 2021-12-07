namespace makler_qlav
{
    class Class1
    {
        public static bool Otvet;


        public static void Prinal(bool x)
        {
            Otvet = x;
        }

        public static bool Vernul(int y)
        {
           return Otvet;
        }
    }
}

