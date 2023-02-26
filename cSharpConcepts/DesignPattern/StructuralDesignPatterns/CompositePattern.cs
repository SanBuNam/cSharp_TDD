using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts.DesignPattern.StructuralDesignPatterns
{
    // Composite is a structural design pattern that allows composing objects into a tree-like structure and work with the it as if it was a singular object.
    // Lets you compose objects into tree structures and then work with these structures as if they were individual objects.
    /*
     Composite becomes a pretty popular solution for the most problems that require building a tree structure. 
    Composite's great feature is the ability to run methods recursively over the whole tree structure and sum up the results.
    Usage examples: The Composite pattern is pretty common in C# code. It's often used to represent hierarchies of user interface components or the code that works with graphs.
    Identification: If you have an object tree, and each object of a tree is a part of the same class hierarchy, this is most likely a composite.
    If methods of these classes delegate the work to child objects of the tree and do it via the base class/interface of the hierarchy, this is definitely a composite.
     */

    // The base Component class declares common operations for both simple and complex objects of a composition.
    abstract class CompositeComponent
    {
        public CompositeComponent() { }
        
        // The base Component may implement some default behavior or leave it to concrete classes (by declaring the method containing the behavior as "abstract").
        public abstract string Operation();

        // In some cases, it would be beneficial to define the child-management operations right in the base Component class.
        // This way, you won't need to expose any concrete component classes to the client code, even during the object tree assembly.
        // The downside is that these methods will be empty for the leaf-level components.
        public virtual void Add(CompositeComponent component)
        {
            throw new NotImplementedException();
        }
        public virtual void Remove(CompositeComponent component)
        {
            throw new NotImplementedException();
        }

        // You can provide a method that lets the client code figure out whether a component can bear children.
        public virtual bool IsComposite()
        {
            return true;
        }
    }

    // The Leaf class represents the end objects of a composition. A leaf can't have any children.
    // Usually, it's the Leaf objects that do the actual work, whereas Composite objects only delegate to their sub-comnents.
    class Leaf : CompositeComponent
    {
        public override string Operation()
        {
            return "Leaf";
        }

        public override bool IsComposite()
        {
            return false;
        }
    }

    // The Composite class represents the complex components that may have children.
    // Usually, the Composite objects delegate the actual work to their children and then "sum-up" the result.
    class Composite : CompositeComponent
    {
        protected List<CompositeComponent> _children = new List<CompositeComponent>();

        public override void Add(CompositeComponent component)
        {
            this._children.Add(component);
        }

        public override void Remove(CompositeComponent component)
        {
            this._children.Remove(component);
        }

        // The Composite executes its primary logic in a particular way.
        // It traverses recursively through all its children, collecting and summing their results.
        // Since the composite's children pass these calls to their children and so forth, the whole object tree is traversed as a result.



    }

}
