
namespace TestKatas.InheritanceVsComposition.Composition
{
    class Child : ILivingBeing
    {
        private readonly Parent _parent;

        public Child(Parent parent )
        {
            _parent = parent;
        }

        public void eat()
        {
            _parent.eat();
        }

        public void useFork()
        {
            _parent.useFork();
        }

        public void useKnife()
        {
            //using a safe knife here.
        }
    }
}
