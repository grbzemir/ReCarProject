using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.GuidHelpers
{
    public class GuidHelpers
    {

         // Guid benzersiz bir kimlik oluşturmak için kullanılır.
        public static string CreatGuid()
        {
            return Guid.NewGuid().ToString();
        }

        // Alt taraftaki sistem oluşturulduğunda her seferinde yeni bir guid oluşturur.

        internal static string CreateGuid()
        {
            throw new NotImplementedException();
        }
    }
}