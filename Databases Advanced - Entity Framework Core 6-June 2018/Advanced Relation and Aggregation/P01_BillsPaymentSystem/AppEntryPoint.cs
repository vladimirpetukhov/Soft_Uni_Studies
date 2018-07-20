namespace P01_BillsPaymentSystem
{
    using Microsoft.EntityFrameworkCore.SqlServer;
    using Data;
    using Data.IO;
    using P01_BillsPaymentSystemInitializer;
    
    
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    public class AppEntryPoint
    {

       
        public static void Main()
        {


            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies().ToArray();
            List<Assembly> myAssemblies = new List<Assembly>();

            foreach (Assembly assembly in assemblies)
            {
                if (assembly.GetName().Name.Contains("P01"))
                {
                    myAssemblies.Add(assembly);
                }
            }



            using (var context=new BillsPaymentSystemContext())
            {
                var populateData = new Initialize(context);
            }
          
        }
    }
}
