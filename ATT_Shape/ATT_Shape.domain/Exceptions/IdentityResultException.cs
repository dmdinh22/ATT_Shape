using Microsoft.AspNet.Identity;

namespace ATT_Shape.domain.Exceptions
{
    public class IdentityResultException : System.Exception
    {
        public IdentityResultException(IdentityResult result)
        {
            this.Result = result;
        }

        public IdentityResult Result { get; set; }
    }
}
