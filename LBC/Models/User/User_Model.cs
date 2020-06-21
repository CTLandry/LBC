
using LBC.Models.Base.BaseModel;

namespace LBC.Models.User
{
    public class User_Model : BaseModel
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
            
        public User_Model()
        {
        }
    }
}
