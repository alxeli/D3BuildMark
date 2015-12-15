using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ApiManager
    {
        //TODO: add ZTN D3 API object here

        public ApiManager()
        {
            throw new NotImplementedException("API not implemented");
        }

        public bool RetrieveProfile(out Profile profile)
        {
            profile = new Profile();

            //TODO: use API to check for profile existence
            if(false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
