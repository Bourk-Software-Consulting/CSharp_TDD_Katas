namespace TestKatas.InheritanceVsComposition.Inheritance
{
    class GrandChild : Child
    {
        //this class has overriden the parent's methods, changing the way it eats.
        // While debuging, you will receive a Type of Parent
        public override void eat()
        {
            // not calling parent, which therefore not calling the other functions 
        }

        protected override void useKnife()
        {
            base.useKnife();
            useFork();
        }
    }
}
