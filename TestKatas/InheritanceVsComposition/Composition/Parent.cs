namespace TestKatas.InheritanceVsComposition.Composition
{
    public  class Parent : ILivingBeing
    {
        private readonly ILivingBeing _child;

        public Parent(ILivingBeing child)
        {
            _child = child;
        }
        public void eat()
        {
            useFork();
        }

        public void useFork()
        {
            useKnife();
        }

        public void useKnife()
        {
            _child.useKnife();
        }
    }
}
