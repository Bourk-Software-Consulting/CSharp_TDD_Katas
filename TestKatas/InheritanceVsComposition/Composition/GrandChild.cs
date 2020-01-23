namespace TestKatas.InheritanceVsComposition.Composition
{
    class GrandChild : ILivingBeing
    {
        private readonly Parent _parent;
        private readonly Child _child;

        GrandChild(Parent parent, Child child)
        {
            _parent = parent;
            _child = child;
        }

        public void eat()
        {

        }

        public void useFork()
        {
            _parent.useFork();
        }

        public void useKnife()
        {
            _child.useKnife();
            useFork();
        }
    }
}
