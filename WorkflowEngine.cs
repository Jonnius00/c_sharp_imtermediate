using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Design a workflow engine that takes a workflow object and runs it. 
 * A workflow is a series of steps or activities. 
 * The workflow engine class should have one method Run() that takes a workflow, 
 * then iterates over each activity in the workflow and runs it.
 * 
 * implementation sholud show good design principles:
 * 1.Single Responsibility: WorkflowEngine runs workflows, Workflow stores activities
 * 2.Open-Closed Principle: New activities can be added without changing existing code
 * 3.Interface Segregation: Clean interfaces with focused responsibilities
 * 4.Error Handling: Null checks and exceptions where appropriate via try-catch
 */
namespace MoshHamedani_C__imtermediate
{
    // this class is ONLY responsible for the workflow's ACTIONS
    // not for STORING the workflow's DATA
    public class WorkflowEngine
    {
        public void Run(IWorkflow workflow)
        {
            foreach (var item in workflow.GetItems())
            { item.Execute(); }
        }
    }

    // interface defines a design of a workflow 
    public interface IWorkflow
    {
        // the reason for using an interface is to allow
        // different implementations of the workflow,
        // f.ex. a workflow that stores activities in a DB or in memory, 
        // or uses a different data structure under the hood.
        void Add(IActivity _activity); void Remove(IActivity _activity);
        IEnumerable<IActivity> GetItems(); void Clear();
        string Name { get; set; } 
        // possibly other common properties: Count, IsEmpty
    }
    // this class is only for STORING the workflow's DATA
    public class Workflow : IWorkflow
    {
        // PROPERTIES
        private readonly List<IActivity> _activities;
        private string _name;
        public string Name { get => _name; set => _name = value; }
        public Workflow(string name) { 
            _name = name;
            _activities = new List<IActivity>();
            Console.WriteLine($"workflow \"{name}\" created");
        }
        
        // METHODS 
        public void Add(IActivity _activity) {
            if (_activity == null)
                throw new ArgumentNullException(nameof(_activity));

            _activities.Add(_activity); 
        }  
        public void Remove(IActivity _activity) {
            if (_activity == null)
                throw new ArgumentNullException(nameof(_activity));

            _activities.Remove(_activity); 
        }
        public IEnumerable<IActivity> GetItems() => _activities;
        public void Clear() { _activities.Clear(); }
    }


    // interface defines ONLY activities in the workflow 
    public interface IActivity { void Execute(); }
    public class Start : IActivity
    {
        public void Execute() { Console.WriteLine("\tStarted..."); }
    }
    public class DoSomeAction : IActivity
    {
        public void Execute() { Console.WriteLine("\taction executed..."); }
    }
    public class Stop : IActivity
    {
        public void Execute() { Console.WriteLine("\tStopped..."); }
    }

    public class LogActivity : IActivity {
        private readonly string _message;
        public LogActivity(string message) { _message = message; }
        public void Execute() {
            Console.WriteLine($"[LOG]: {_message}");
        }
    }

    public class WorkflowEngine_Program
    {
        public static void Run() {
            try {
                // Create a workflow with a series of activities
                IWorkflow workflow = new Workflow("backing a SIMPLE cake");
                workflow.Add(new Start());
                workflow.Add(new DoSomeAction());
                workflow.Add(new Stop());

                // Create a workflow engine and run the workflow
                WorkflowEngine engine = new WorkflowEngine();
                engine.Run(workflow); 
                Console.WriteLine("---------------------------"); 
                Console.WriteLine();
            }
            catch (Exception) { throw; }

            try {
                // Create a more complex workflow with logging
                IWorkflow workflow = new Workflow("backing a LOGGING cake");
                workflow.Add(new LogActivity("Starting cake baking process"));
                workflow.Add(new Start());
                workflow.Add(new LogActivity("Preparing ingredients"));
                workflow.Add(new DoSomeAction());
                workflow.Add(new LogActivity("Finishing up"));
                workflow.Add(new Stop());

                WorkflowEngine engine = new WorkflowEngine();
                engine.Run(workflow);
            }
            catch (Exception)  { throw; }

            Console.WriteLine("Workflows completed successfully.");
        }
    }
}
