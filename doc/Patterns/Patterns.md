Basic design patterns
==============

>   [Singleton pattern](#singleton-pattern)

>   [Wait for the end of a task running async and non-blocking in a sync running environment](#wait-for-the-end-of-a-task-running-async-and-non-blocking-in-a-sync-running-environment)

# Singleton pattern

The singleton pattern ensures that only one instance of a class can be created.

For more information see https://csharpindepth.com/articles/singleton

## Sample implementation

``` csharp

/// <summary>
/// Simple and thread-safe implementation of the singleton pattern
/// </summary>
public class GlobalValues
{
    
    private static readonly Lazy<GlobalValues> _instance = new Lazy<GlobalValues>(()=> new GlobalValues());

    public static GlobalValues Instance => _instance.Value;

    //// Same as:
    /*
    public static GlobalValues Instance 
    {
        get
        {
            return _instance.Value;
        }
    }
    */

    /// <summary>
    /// A private ctor prohibits direct instancing of the class
    /// </summary>
    private GlobalValues()
    {
        
    }

    /// <summary>
    /// Application name
    /// </summary>
    public const string AppName = "Coding basics application";

    /// <summary>
    /// Path for app data backups
    /// </summary>
    public string BackupPath { get; set; }

    
    // Add properties and methids as required

}

```

## Tests for the sample implementation

``` csharp

[TestFixture]
internal class PatternTests
{


    //[Test]
    //public void Ctor_NotPossible()
    //{
    //    // Arrange 


    //    // Act  
    //    var gv = new GlobalValues(); // Not allowed as ctor is private

    //    // Assert


    //}



    [Test]
    public void Instance_DefaultSetup_InstanceCreated()
    {
        // Arrange and act  
        var gv = GlobalValues.Instance;

        // Assert
        Assert.That(gv, Is.Not.Null);

    }

    [Test]
    public void Instance_RepeatedCall_OnlyOneInstanceCreated()
    {
        // Arrange and act 
        var gv1 = GlobalValues.Instance;
        var gv2 = GlobalValues.Instance;
        var gv3 = GlobalValues.Instance;

        // Assert
        Assert.That(gv1, Is.Not.Null);
        Assert.That(gv2, Is.Not.Null);
        Assert.That(gv3, Is.Not.Null);

        Assert.That(gv1, Is.EqualTo(gv2));
        Assert.That(gv1, Is.EqualTo(gv3));
    }

}

```

# Wait for the end of a task running async and non-blocking in a sync running environment

Long running jobs running in an sync environment may have blocking behaviour until the job is done. Especially in UI environments like WinForms this behaviour may be unwanted. Imagine a UI with a button the user clicks on and has to wait for 10 minutes until the called is done before the UI is reacting again. In such case it may be better if the uer can proceed with other work during the job is performed. If the job is done, maybe a information to the user is shown.

The waiting task should stay on the main thread. The workload should run in a separate task.

The example below shows the basic implemetation pattern.


``` csharp

    [Test]
    public void RunATaskNonBlockingAndWaitForBeingDone_LongRunningTaskNoTimeout_TaskFinishedSuccessful()
    {
        // Arrange 
        var timeout = 20000;

        // New task completion source for the requested type (here bool)
        var taskCompletionSourceWait = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        // If the task never stops a timeout should be defined. This is done by a CancellationTokenSource
        var ctsWait = new CancellationTokenSource(timeout);
        ctsWait.Token.Register(() =>
        {
            if (taskCompletionSourceWait is not
                {
                    Task:
                    {
                        IsCompleted: false, IsCanceled: false, IsFaulted: false, IsCompletedSuccessfully: false
                    }
                })
            {
                return;
            }

            taskCompletionSourceWait.SetResult(false);

        });

        var task = Task.Run(() =>
        {
            YourTaskDoDo(taskCompletionSourceWait, ctsWait.Token);
        });


        // Act  
        // run the waiting task until task is done or timeout
        var result = taskCompletionSourceWait.Task.GetAwaiter().GetResult();

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void RunATaskNonBlockingAndWaitForBeingDone_LongRunningTaskWithTimeout_TaskFinishedSuccessful()
    {
        // Arrange 
        var timeout = 5000;

        // New task completion source for the requested type (here bool)
        var taskCompletionSourceWait = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);

        // If the task never stops a timeout should be defined. This is done by a CancellationTokenSource
        var ctsWait = new CancellationTokenSource(timeout);
        ctsWait.Token.Register(() =>
        {
            if (taskCompletionSourceWait is not
                {
                    Task:
                    {
                        IsCompleted: false, IsCanceled: false, IsFaulted: false, IsCompletedSuccessfully: false
                    }
                })
            {
                return;
            }

            taskCompletionSourceWait.SetResult(false);

        });

        // Fire and forget your task (no return value from task needed in our sample)
        Task.Run(() =>
        {
            YourTaskDoDo(taskCompletionSourceWait, ctsWait.Token);
        });


        // Act  
        // run the waiting task until task is done or timeout
        var result = taskCompletionSourceWait.Task.GetAwaiter().GetResult();

        // Assert
        Assert.That(result, Is.False);
    }

    /// <summary>
    /// In this method you can process your workload
    /// </summary>
    private void YourTaskDoDo(TaskCompletionSource<bool> taskCompletionSourceWait, CancellationToken ctWait)
    {

        for (var i = 0; i <15; i++)
        {

            if (ctWait.IsCancellationRequested)
            {
                taskCompletionSourceWait.SetResult(false);
                return;
            }

            Debug.Print($"Do your workload {i}");
            Task.Delay(1000).Wait();
        }

        taskCompletionSourceWait.SetResult(true);
    }

``` charp
