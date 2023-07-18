using System;
using System.Collections.Generic;
using System.Text;

namespace cSharpConcepts.DesignPattern.BehavioralPatterns
{
    interface IObserver{
        void Update(object update);
    }
    
    interface ISubject{
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }
    
    class Subject: ISubject{
        private List<IObserver> _subjectObservers;
    
        public Subject(){
            _subjectObservers = new List<IObserver>();
        }
    
        void Attach(IObserver observer){
            _subjectObservers.Add(observer);
        }
    
        void Detach(IObserver observer){
            _subjectObservers.Remove(observer);
        }
    
        void Notify(){
            foreach(var observer in _subjectObservers){
                observer.Update("Some state");
            }
        }
    
        /*
            Some logic that calls to Notify when needed
        */
    }
    
    class ObserverA: IObserver{
        void Update(object update){
    
        }
    }
    
    class ObserverB: IObserver{
        void Update(object update){
    
        }
    }
    
    class SomeClass{
        public void Init(){
            var observerA = new ObserverA();
            var observerB = new ObserverB();
            var subject = new Subject();
            subject.Attach(observerA);
    
        }
    }

}
