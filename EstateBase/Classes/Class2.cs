namespace makler_qlav
{
    class Class2
    {
      
        public static string Un;

        /// <summary>
        /// Присвоение получченного ID
        /// </summary>
       
        public static void PR1(string UN)
        {
            Un = UN;
        }

        /// <summary>
        /// Для сравнения с ключем(ID) в БД
        /// </summary>
       
        public static string PR2()
        {
            return Un;
        }
            
    }
}

    

