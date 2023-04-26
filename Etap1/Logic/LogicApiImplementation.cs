using Data;
using System.Threading;

namespace Logic;

public class LogicApiImplementation : LogicApi
{
    private DataApi _dataApi;

    public LogicApiImplementation(DataApi dataApi)
    {
        _dataApi = dataApi;
        Cancel = new CancellationTokenSource();
    }
    
    public override List<Circle> GetCircles()
    {
        return _dataApi.GetCircles();
    }

    public override double GetCanvasWidth()
    {
        return _dataApi.GetCanvasWidth();
    }

    public override double GetCanvasHeight()
    {
        return _dataApi.GetCanvasHeight();
    }

    public override void AddCircles(int count)
    {
        try
        {
            _dataApi.AddCircles(count);
        }
        catch (ArgumentException)
        {
            _dataApi.AddCircles(3);
        }
    }
    
    public override void Update()
    {
        foreach (Circle circle in GetCircles())
        {
            Task task = Task.Run(() =>
            {
                while (!Cancel.Token.IsCancellationRequested)
                {
                    try
                    {
                        ManualResetEvent.WaitOne();
                        lock (circle)
                        {
                            _dataApi.Canvas.Move(circle);
                        }
                        Thread.Sleep(1);
                    }
                    catch (OperationCanceledException)
                    {
                        return;
                    }
                }
            }, Cancel.Token);
            Tasks.Add(task);
        }
    }
    
    public override void Reset()
    {
        foreach (var task in Tasks)
        {
            if (!task.IsCompleted)
            {
                Cancel.Cancel();
                task.Wait();
            }
        }
        Tasks.Clear();
        GetCircles().Clear();
    }
    
    public override void AddCircle(Circle circle)
    {
        _dataApi.AddCircle(circle);
    }
    
    public override void Stop()
    {
        if (!Cancel.IsCancellationRequested)
            Cancel.Cancel();
    }
    
    public override void Start()
    {
        if (Cancel.IsCancellationRequested)
            Cancel = new CancellationTokenSource();
    }
}
