using System.Text;

namespace MyClassicGame
{
    abstract class IOModule
    {
        public Encoding encoding { get; private set; }

        protected IOModule(CharacterSet set)
        {
            encoding = Encoding.GetEncoding((int)set);
        }
    }
}