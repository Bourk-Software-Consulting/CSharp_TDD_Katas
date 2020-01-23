namespace TestKatas.InheritanceVsComposition.Inheritance
{
    //this class cannot be instantiated directly. 
    //This class will be like a signature, used just like an "inteface" so we can use Object Oriented benefits.
    //The classes that will consume this abstract class, they won't know which child are they going to receive directly, 
    //a programmer will have to use the debugger, follow the code and reveal the source of the problem.
    abstract class Parent
    {
        //the keyword virtual is not needed for composition
        public virtual void eat()
        {
            useFork();
        }

        protected virtual void useFork()
        {
            useKnife(); // a call for a child.
        }

        protected abstract void useKnife();

    }
}
