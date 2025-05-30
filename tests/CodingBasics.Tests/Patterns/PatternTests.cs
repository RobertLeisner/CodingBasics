// Copyright (c) Bodoconsult EDV-Dienstleistungen. All rights reserved.

using System.Diagnostics;
using CodingBasics.Patterns;

namespace CodingBasics.Tests.Patterns;

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

    //    Assert.That(gv, Is.Not.Null);
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

        // Fire and forget your workload task (no return value from task needed in our sample)
        Task.Run(() =>
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

        // Fire and forget your workload task (no return value from task needed in our sample)
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
}