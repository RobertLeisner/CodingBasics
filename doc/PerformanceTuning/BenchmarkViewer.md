Using Benchmark Viewer to identify bottlenecks
==============

Benchmark Viewer is an open source tool to visualize processes running in app on a timeline. See https://github.com/crep4ever/benchmark-viewer. The tool needs a CSV file filled with data written from the app as input.

In C# a class Bench based on IBench in the Bodoconsult.App nuget package can be used to populate the Benchmark Viewer CSV input file with data.

Use Benchmark Viewer to visualize order running, transaction or other longer running operations especially in multithreaded environments. Start Benchmark Viewer app and load your CSV file to show the logged data.



``` csharp

[Test]
public void CreateABench_DefaultSetup_FileWritten()
{
    var path = Path.Combine(Path.GetTempPath(), "BenchmarkViewer.csv");

    if (File.Exists(path))
    {
        File.Delete(path);
    }

    // Arrange 
    var loggerfactory = new BenchLoggerFactory(path);

    var benchLogger = new AppBenchProxy(loggerfactory, Globals.Instance.LogDataFactory);

    var bench = new Bench(benchLogger, "Identifying key");

    // Act  
    bench.Start("Starts");

    Task.Delay(500).Wait();

    bench.AddStep("Do something 1");

    Task.Delay(500).Wait();

    bench.AddStep("Do something 2");

    Task.Delay(500).Wait();

    bench.Stop("Stops");

    bench.Dispose();

    // Assert
    Assert.That(File.Exists(path));

}

``` 

For apps making heavy usages off Bench it is recommend to switch to BenchReusable based on IBench too. The following example shows a typical use case having only one Benchmark Viewer CSV file:

``` csharp

[Test]
public void CreateABenchReusable_TypicalSetupForAnApp_FileWritten()
{
    var path = Path.Combine(Path.GetTempPath(), "BenchmarkViewer3.csv");

    if (File.Exists(path))
    {
        File.Delete(path);
    }

    // Arrange 
    var loggerfactory = new BenchLoggerFactory(path);

    var centralLogDataFactory = Globals.Instance.LogDataFactory;

    var benchReusableFactory = new AppBenchReusableFactory(loggerfactory, centralLogDataFactory); // Load this instance into DI container to be available via ctor injection!

    var bench = benchReusableFactory.CreateInstance( "Identifying key");

    // Act  
    bench.Start("Starts");

    Task.Delay(500).Wait();

    bench.AddStep("Do something 1");

    Task.Delay(500).Wait();

    bench.AddStep("Do something 2");

    Task.Delay(500).Wait();

    bench.Stop("Stops");

    bench.Dispose();

    benchReusableFactory.Enqueue(bench);

    // Assert
    Assert.That(File.Exists(path));

}

``` 
